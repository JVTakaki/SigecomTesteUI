﻿using System;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class PagarValorParcialDaContaAPagarPage:PageObjectModel 
    {
        public PagarValorParcialDaContaAPagarPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDePagarValorParcialNaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);

            // Act
            RealizarFluxoDeGerarContaAPagar();
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$22,11");
            ClicarBotaoName(ContaAPagarModel.BotaoDePagar);
            DriverService.SelecionarItensDoDropDown(1);
            DriverService.RealizarSelecaoDaFormaDePagamentoSemEnter(ContaAPagarModel.ElementoDeFormaDePagamento, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(ContaAPagarModel.ElementoDoTotalPago, "10,11", Keys.Enter);
            ClicarBotaoName(ContaAPagarModel.ParcialDoPagarConta);
            ClicarBotaoName(ContaAPagarModel.Sim);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Saldo", "R$12,00"), true);
            FecharTelaDeContaAPagarComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor pago", "R$10,11"), true);
            FecharTelaDeContasRecebidasComEsc();
        }

        private void RealizarFluxoDeGerarContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAPagar("22,11");
        }

        private void FecharTelaDeContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagas);
    }
}

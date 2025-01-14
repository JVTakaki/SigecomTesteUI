﻿using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using SigecomTestesUI.Sigecom.Vendas.Base.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Page
{
    public class ContasPagarNaDevolucaoPage: PageObjectModel
    {
        public ContasPagarNaDevolucaoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(DevolucaoModel.BotaoMenuVendas);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(DevolucaoModel.BotaoSubMenu);

        public void RealizarFluxoDeContasAPagarNaDevolucao()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto();
            AvancarNaDevolucao();
            DriverService.EditarItensNaGrid(DevolucaoModel.CampoDaGridDeQuantidadeParaDevolver, DriverService.PegarValorDaColunaDaGrid(DevolucaoModel.CampoDaGridDeQuantidadeVendida));
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(DevolucaoModel.CampoDaGridDeSituacaoParaDevolver), "Devolução total");
            AvancarNaDevolucao();
            DriverService.RealizarSelecaoDaAcao(DevolucaoModel.AcoesDaDevolucao, 3);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, "CLIENTE TESTE PESQUISA", Keys.Enter);
            ClicarBotaoName(DevolucaoModel.ElementoNameDoNao);
            FecharTelaDeDevolucaoComEsc();
        }

        private void LancarProduto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var vendasBasePage = beginLifetimeScope.Resolve<Func<DriverService, IVendasBasePage>>()(DriverService);
            vendasBasePage.LancarProdutoPadraoNaVenda(DevolucaoModel.ElementoTelaDeDevolucao);
        }

        private void AvancarNaDevolucao()
            => ClicarBotaoName(DevolucaoModel.ElementoNameDoAvancar);

        private void FecharTelaDeDevolucaoComEsc() =>
            DriverService.FecharJanelaComEsc(DevolucaoModel.ElementoTelaDeDevolucao);
    }
}

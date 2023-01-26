﻿using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Condicional.LancarCondicional.Page
{
    public class AplicarDescontoNaCondicionalPage: PageObjectModel
    {
        public AplicarDescontoNaCondicionalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CondicionalModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CondicionalModel.BotaoSubMenu);

        public void RealizarFluxoDeAplicarDescontoNaCondicional()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var condicionalBasePage = beginLifetimeScope.Resolve<Func<DriverService, CondicionalBasePage>>()(DriverService);
            condicionalBasePage.AbrirOAtalhoParaSelecionarCliente();
            LancarProduto(condicionalBasePage.RetornarIdDoProduto());
            DriverService.DigitarNoCampoName(CondicionalModel.CampoDaGridDeQuantidadeDoProduto, LancarItensNaCondicionalModel.QuantidadeDeProduto);
            DriverService.EditarItensNaGridComDuploClickComTab(CondicionalModel.CampoDaGridDeDescontoDoProduto, LancarItensNaCondicionalModel.DescontoNoItemCondicional);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(CondicionalModel.CampoDaGridDeTotalDoProduto), LancarItensNaCondicionalModel.ItemComDescontoNaCondicional);
            AvancarNaCondicional();
            AvancarNaCondicional();
            DriverService.RealizarSelecaoDaAcao(CondicionalModel.AcoesDaCondicional, 2);
            FecharTelaDeCondicionalComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(CondicionalModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNaCondicional()
            => ClicarBotaoName(CondicionalModel.ElementoNameDoAvancar);

        private void FecharTelaDeCondicionalComEsc() =>
            DriverService.FecharJanelaComEsc(CondicionalModel.ElementoTelaDeCondicional);
    }
}

﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaProduto;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDeProduto = new Dictionary<string, string>
        {
            {"Nome","PRODUTO"},
            {"Unidade", "UN"},
            {"CodigoInterno","int"},
            {"Categoria","PRODUTO"},
            {"Custo","5,00"},
            {"Markup","100,00"},
            {"PrecoVenda","10,00"},
            {"Referencia","ref"},
            {"NCM","22030000"}
        };

        [Test(Description = "Cadastro de Produto Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarProdutoSomenteCamposObrigatorios()
        {
            var resolveCadastroDeProdutoPage = _lifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, _dadosDeProduto);
            // Arange
            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoPage.ClicarNoBotaoNovo();

            // Act
            cadastroDeProdutoPage.PreencherCamposDoProduto();
            cadastroDeProdutoPage.VerificarSePrecoDeVendaFoiCalculado();
            // mudar para aba impostos
            cadastroDeProdutoPage.AcessarAbaImpostos();
            // preencher impostos
            cadastroDeProdutoPage.PreencherCamposDeImpostos();
            cadastroDeProdutoPage.Gravar();

            // Assert
            cadastroDeProdutoPage.ClicarNaOpcaoDoPesquisar();
            var resolvePesquisaDeProdutoPage = _lifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
            pesquisaDeProdutoPage.PesquisarProduto(_dadosDeProduto["Nome"]);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(_dadosDeProduto["Nome"]);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();     
        }
    }
}

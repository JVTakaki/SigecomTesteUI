﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Teste
{
    public class EdicaoDeProdutoCombustivelTeste : BaseTestes
    {
        [Test(Description = "Edição produto combustivel possuindo somente campos obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Produto")]
        public void EdicaoDeProdutoCombustivel()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeProdutoBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeProdutoBasePage>>();
            var edicaoDeProdutoBasePage = resolveEdicaoDeProdutoBasePage(DriverService);
            const TipoDeProduto tipoDeProduto = TipoDeProduto.Combustivel;

            // Act
            edicaoDeProdutoBasePage.PesquisarProdutoQueSeraEditado(tipoDeProduto);
            edicaoDeProdutoBasePage.VerificarCamposDoProduto(tipoDeProduto);
            edicaoDeProdutoBasePage.PreencherCamposDoProdutoAoEditar(tipoDeProduto);
            edicaoDeProdutoBasePage.AcessarAba(CadastroDeProdutoModel.AbaCombustivel);
            edicaoDeProdutoBasePage.VerificarCamposDaAba(tipoDeProduto);
            edicaoDeProdutoBasePage.PreencherCamposDaAbaAoEditar(tipoDeProduto);
            edicaoDeProdutoBasePage.Gravar();

            // Assert
            edicaoDeProdutoBasePage.RealizarFluxoDePesquisaDoProdutoQueFoiEditado(tipoDeProduto);
            edicaoDeProdutoBasePage.AcessarAba(CadastroDeProdutoModel.AbaCombustivel);
            edicaoDeProdutoBasePage.VerificarCamposDaAbaEditado(tipoDeProduto);
            edicaoDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}

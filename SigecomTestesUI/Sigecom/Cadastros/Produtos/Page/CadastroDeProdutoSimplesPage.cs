﻿using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;
using System;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page
{
    public class CadastroDeProdutoSimplesPage : PageObjectModel, ICadastroDeProdutoPage
    {
        public CadastroDeProdutoSimplesPage(DriverService driver) : base(driver) { }

        public bool PreencherCamposDoProduto()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoSimplesModel.NomeDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                DriverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoSimplesModel.CategoriaDoProduto);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, CadastroDeProdutoBaseModel.CustoDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, CadastroDeProdutoBaseModel.MarkupDoProduto);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, CadastroDeProdutoBaseModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaAba()
        {
            return false;
            //Não utilizado;
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage, PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProduto(CadastroDeProdutoSimplesModel.NomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoSimplesModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}

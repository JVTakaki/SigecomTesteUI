﻿using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoCompletoPage : IEdicaoDeProdutoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeProdutoCompletoPage(DriverService driver) =>
            _driverService = driver;

        public void PesquisarProdutoQueSeraEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage)
        {
            edicaoDeProdutoBasePage.AbrirTelaDeCadastroDoProduto();
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeProdutoBasePage.RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoCompletoModel.NomeDoProdutoParaPesquisar);
        }

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto), "PRODUTO COMPLETO EDITAR TESTE");
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoUnidade), CadastroDeProdutoBaseModel.UnidadeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodigoInterno), CadastroDeProdutoBaseModel.CodigoInternoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), CadastroDeProdutoCompletoModel.CategoriaDoProduto);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoGarantiaEmDias), CadastroDeProdutoCompletoModel.GarantiaEmDias);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodigoDeBarrasProduto), CadastroDeProdutoCompletoModel.CodigoDeBarrasProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoEstoque), CadastroDeProdutoCompletoModel.Estoque);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoEstoqueMinimo), CadastroDeProdutoCompletoModel.EstoqueMinimo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoEstoqueMaximo), CadastroDeProdutoCompletoModel.EstoqueMaximo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarca), CadastroDeProdutoCompletoModel.Marca);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoFornecedor), CadastroDeProdutoCompletoModel.Fornecedor);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCusto), CadastroDeProdutoBaseModel.CustoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarkup), CadastroDeProdutoBaseModel.MarkupDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda), CadastroDeProdutoBaseModel.PrecoVendaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoReferencia), CadastroDeProdutoBaseModel.ReferenciaDoProduto);
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EdicaoDeProdutoCompletoModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, EdicaoDeProdutoCompletoModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoInterno, EdicaoDeProdutoCompletoModel.CodigoInternoDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, EdicaoDeProdutoCompletoModel.CategoriaDoProduto, Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(2));

                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGarantiaEmDias, EdicaoDeProdutoCompletoModel.GarantiaEmDias);
                //_driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoDeBarrasProduto, EdicaoDeProdutoCompletoModel.CodigoDeBarrasProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoEstoqueMinimo, EdicaoDeProdutoCompletoModel.EstoqueMinimo);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoEstoqueMaximo, EdicaoDeProdutoCompletoModel.EstoqueMaximo);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarca, EdicaoDeProdutoCompletoModel.Marca);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoFornecedor, EdicaoDeProdutoCompletoModel.Fornecedor);

                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, EdicaoDeProdutoCompletoModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, EdicaoDeProdutoCompletoModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, EdicaoDeProdutoCompletoModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDeProdutoEditado()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto), EdicaoDeProdutoCompletoModel.NomeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoUnidade), EdicaoDeProdutoCompletoModel.UnidadeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodigoInterno), EdicaoDeProdutoCompletoModel.CodigoInternoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), EdicaoDeProdutoCompletoModel.CategoriaDoProduto);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoGarantiaEmDias), EdicaoDeProdutoCompletoModel.GarantiaEmDias);
            //Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodigoDeBarrasProduto), EdicaoDeProdutoCompletoModel.CodigoDeBarrasProduto);
            //Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoEstoque), EdicaoDeProdutoCompletoModel.Estoque);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoEstoqueMinimo), EdicaoDeProdutoCompletoModel.EstoqueMinimo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoEstoqueMaximo), EdicaoDeProdutoCompletoModel.EstoqueMaximo);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarca), EdicaoDeProdutoCompletoModel.Marca);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoFornecedor), EdicaoDeProdutoCompletoModel.Fornecedor);

            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCusto), EdicaoDeProdutoCompletoModel.CustoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarkup), EdicaoDeProdutoCompletoModel.MarkupDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda), EdicaoDeProdutoCompletoModel.PrecoVendaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoReferencia), EdicaoDeProdutoCompletoModel.ReferenciaDoProduto);
        }

        public void VerificarCamposDaAba()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCstpis), CadastroDeProdutoCompletoModel.Cstpis);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCstCofins), CadastroDeProdutoCompletoModel.CstCofins);
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            //Não utilizado;
        }

        public void VerificarCamposDaAbaEditado()
        {
            //Não utilizado;
        }

        public void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoCompletoModel.NomeFinalDoProduto);
        }
    }
}

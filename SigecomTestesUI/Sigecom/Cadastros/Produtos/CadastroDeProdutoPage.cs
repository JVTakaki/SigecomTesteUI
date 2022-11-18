﻿using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public class CadastroDeProdutoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeProduto;
        public CadastroDeProdutoPage(DriverService driver, Dictionary<string, string> dadosDeProduto) : base(driver) => 
            _dadosDeProduto = dadosDeProduto;

        public bool ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public bool ClicarNaOpcaoDoPesquisar() =>
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoPesquisar);

        public bool ClicarNoBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.BotaoNovoCadastro);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDoProduto()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, _dadosDeProduto["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, _dadosDeProduto["Unidade"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeProdutoModel.ElementoCategoria, _dadosDeProduto["Categoria"]);
                EsperarAcaoEmSegundos(2);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, _dadosDeProduto["Custo"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, _dadosDeProduto["Markup"]);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, _dadosDeProduto["Referencia"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarSePrecoDeVendaFoiCalculado()
        {
            var precoDeVenda = double.Parse(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda));
            return precoDeVenda.Equals(double.Parse(_dadosDeProduto["PrecoVenda"]));
        }

        public bool AcessarAbaImpostos()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.AbaImpostos);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDeImpostos()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm, _dadosDeProduto["NCM"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Gravar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.BotaoGravar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaCadastroDeProdutoComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
﻿using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClienteFisicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDoCliente;

        public CadastroDeClienteFisicoPage(DriverService driver, Dictionary<string, string> dadosDoCliente) :
            base(driver) =>
            _dadosDoCliente = dadosDoCliente;

        public bool ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeClienteModel.BotaoMenu);

        public bool ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeClienteModel.BotaoSubMenu);

        public bool ClicarBotaoNovo() =>
            ClicarBotaoNovo(CadastroDeClienteModel.BotaoNovo);

        public bool ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoPesquisar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa);
            return valorTipoPessoa.Equals("FÍSICA");
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, _dadosDoCliente["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCpf, _dadosDoCliente["Cpf"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeClienteModel.ElementoCep, _dadosDoCliente["Cep"]);
                EsperarAcaoEmSegundos(3);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNumero, _dadosDoCliente["Numero"]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PreencherCamposCompleto()
        {
            try
            {
                PreencherCamposSimples();
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoRg, _dadosDoCliente["Rg"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoApelido, _dadosDoCliente["Apelido"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeClienteModel.ElementoDataDeNascimento, _dadosDoCliente["DataNascimento"]);
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoSexo, 1);
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstadoCivil, 1);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoComplemento, _dadosDoCliente["Complemento"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoProfissao, _dadosDoCliente["Profissao"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObservacao, _dadosDoCliente["Observacao"]);
                CadastrarContatosDoCliente();
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoAvisoDeVenda, _dadosDoCliente["AvisoDeVenda"]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CadastrarContatosDoCliente()
        {
            DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoContato, 3);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatoDoCliente, _dadosDoCliente["ContatoPrimario"]);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObsContatoDoCliente, _dadosDoCliente["ObservacaoContatoPrimario"]);
            DriverService.ClicarBotaoId(CadastroDeClienteModel.BotaoContato);
            EsperarAcaoEmSegundos(2);
            DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoContato, 1);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatoDoCliente, _dadosDoCliente["ContatoSecundario"]);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObsContatoDoCliente, _dadosDoCliente["ObservacaoContatoSecundario"]);
            DriverService.ClicarBotaoId(CadastroDeClienteModel.BotaoContato);
        }

        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeClienteModel.ElementoTelaCadastroCliente);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public void AcessarTelaDeCadastroDeCliente()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoNovo();
            VerificarTipoPessoa();
        }

        public void PesquisarClienteGravado(ILifetimeScope beginLifetimeScope)
        {
            ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("cliente", _dadosDoCliente["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDoCliente["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            FecharJanelaComEsc();
        }
    }
}

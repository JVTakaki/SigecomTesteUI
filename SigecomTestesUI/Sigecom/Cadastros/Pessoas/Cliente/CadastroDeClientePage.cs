﻿using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClientePage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDoCliente;

        public CadastroDeClientePage(DriverService driver, Dictionary<string, string> dadosDoCliente) : base(driver) => 
            _dadosDoCliente = dadosDoCliente;

        public bool ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeClienteModel.BotaoMenu);

        public bool ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeClienteModel.BotaoSubMenu);

        public bool ClicarBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoNovo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoPesquisar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa);
            return valorTipoPessoa.Equals("FÍSICA");
        }

        public bool PreencherCampos()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, _dadosDoCliente["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCpf, _dadosDoCliente["Cpf"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeClienteModel.ElementoCep, _dadosDoCliente["Cep"]);
                EsperarAcaoEmSegundos(5);
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
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, _dadosDoCliente["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCpf, _dadosDoCliente["Cpf"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoRg, _dadosDoCliente["Rg"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoApelido, _dadosDoCliente["Apelido"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeClienteModel.ElementoDataDeNascimento, _dadosDoCliente["DataNascimento"]);
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoSexo, 1);
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoEstadoCivil, 1);
                DriverService.DigitarNoCampoEnterId(CadastroDeClienteModel.ElementoCep, _dadosDoCliente["Cep"]);
                EsperarAcaoEmSegundos(3);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNumero, _dadosDoCliente["Numero"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoComplemento, _dadosDoCliente["Complemento"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoProfissao, _dadosDoCliente["Profissao"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObservacao, _dadosDoCliente["Observacao"]);
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoContato, 3);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatoDoCliente, _dadosDoCliente["ContatoPrimario"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObsContatoDoCliente, _dadosDoCliente["ObservacaoContatoPrimario"]);
                DriverService.ClicarBotaoId(CadastroDeClienteModel.BotaoContato);
                EsperarAcaoEmSegundos(2);
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoContato, 1);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatoDoCliente, _dadosDoCliente["ContatoSecundario"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObsContatoDoCliente, _dadosDoCliente["ObservacaoContatoSecundario"]);
                DriverService.ClicarBotaoId(CadastroDeClienteModel.BotaoContato);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoAvisoDeVenda, _dadosDoCliente["AvisoDeVenda"]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoGravar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeClienteModel.ElementoTelaCadastroCliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

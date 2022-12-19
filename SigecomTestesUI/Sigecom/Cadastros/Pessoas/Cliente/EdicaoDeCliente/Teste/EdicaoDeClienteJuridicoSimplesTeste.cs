﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Teste
{
    class EdicaoDeClienteJuridicoSimplesTeste : BaseTestes
    {
        [Test(Description = "Edição de cliente jurídico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Cliente")]
        public void EdicaoDeClienteJuridicoSimples()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeClienteBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeClienteBasePage>>();
            var edicaoDeClienteBasePage = resolveEdicaoDeClienteBasePage(DriverService);
            const ClassificacaoDePessoa classificacaoDePessoa = ClassificacaoDePessoa.JuridicaSimples;
            edicaoDeClienteBasePage.PesquisarClienteQueSeraEditado(classificacaoDePessoa);

            // Act
            edicaoDeClienteBasePage.VerificarInformacoesDoCliente(classificacaoDePessoa);
            edicaoDeClienteBasePage.PreencherAsInformacoesDaPessoasNaEdicao(classificacaoDePessoa);
            edicaoDeClienteBasePage.Gravar();

            // Assert
            edicaoDeClienteBasePage.FluxoDePesquisaDaPessoaEditado(classificacaoDePessoa);
            edicaoDeClienteBasePage.VerificarDadosDaPessoaEditados(classificacaoDePessoa);
            edicaoDeClienteBasePage.FecharJanelaCadastroDeClienteComEsc();
        }
    }
}

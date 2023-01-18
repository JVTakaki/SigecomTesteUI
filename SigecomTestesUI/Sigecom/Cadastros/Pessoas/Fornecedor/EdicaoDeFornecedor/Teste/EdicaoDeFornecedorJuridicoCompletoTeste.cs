﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Teste
{
    public class EdicaoDeFornecedorJuridicoCompletoTeste: BaseTestes
    {
        [Test(Description = "Edição de fornecedor juridíco completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Fornecedor")]
        public void EdicaoDeFornecedorJuridicoCompleto()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeFornecedorBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeFornecedorBasePage>>();
            var edicaoDeFornecedorBasePage = resolveEdicaoDeFornecedorBasePage(DriverService);
            edicaoDeFornecedorBasePage.RealizarFluxoDaEdicaoDeFornecedor(ClassificacaoDePessoa.JuridicaCompleta);
        }
    }
}

using Autofac;
using NUnit.Allure.Core;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Login;
using SigecomTestesUI.Services;

namespace SigecomTestesUI
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTestes
    {
        public DriverService DriverService;
        private readonly LoginPage _loginPage;

        public BaseTestes()
        {
            ControleDeInjecaoAutofac.ConstruirContainerComDependenciasSemCarregarDados();
            var scope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            DriverService = scope.Resolve<DriverService>();
            _loginPage = new LoginPage(DriverService);
        }

        [SetUp]
        public void Setup()
        {
            Assert.IsTrue(_loginPage.Logar());
        }

        [TearDown]
        public void TearDown()
        {
            _loginPage.FecharSistema();
        }
    }
}
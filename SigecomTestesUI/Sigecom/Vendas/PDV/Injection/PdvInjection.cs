﻿using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using SigecomTestesUI.Sigecom.Vendas.PDV.Teste;
using System;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Factory;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Injection
{
    public class PdvInjection: Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<LancarItensNoPdvPage>();
                containerBuilder.RegisterType<LancarVendaNoDinheiroPage>();
                containerBuilder.RegisterType<LancarVendaNoPrazoPage>();
                containerBuilder.RegisterType<LancarVendaNoCreditoPage>();
                containerBuilder.RegisterType<LancarVendaNoChequePage>();
                containerBuilder.RegisterType<LancarFormaDePagamentoPageFactory>().As<ILancarFormaDePagamentoPageFactory>();
                containerBuilder.RegisterType<LancarVendaNoDinheiroTeste>();
                containerBuilder.RegisterType<LancarVendaNoPrazoTeste>();
                containerBuilder.RegisterType<LancarVendaNoCreditoTeste>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(PdvInjection).Namespace, exception);
            }
        }
    }
}

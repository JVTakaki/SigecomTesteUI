﻿namespace SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces
{
    public interface IContaBasePage
    {
        void RealizarFluxoDeGerarContaAReceber(string valorDaConta);
        void RealizarFluxoDeGerarContaAPagar(string valorDaConta);
    }
}
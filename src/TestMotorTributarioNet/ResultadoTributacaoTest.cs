﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using TestCalculosTributarios.Entidade;

namespace TestCalculosTributarios
{
    [TestClass]
    public class ResultadoTributacaoTest
    {
        [TestMethod]
        public void TestaCalculoCST00()
        {
            var produto = new Produto();

            produto.Cst = MotorTributarioNet.Flags.Cst.Cst00;
            produto.Desconto = 0;
            produto.Documento = Documento.NFe;
            produto.Frete = 0;
            produto.IsServico = false;
            produto.OutrasDespesas = 0;
            produto.PercentualCofins = 15;
            produto.PercentualDifalInterestadual = 80m;
            produto.PercentualFcp = 1m;
            produto.PercentualIcms = 18;
            produto.PercentualPis = 5;
            produto.PercentualReducao = 0;
            produto.QuantidadeProduto = 9;
            produto.Seguro = 0;
            produto.ValorProduto = 23;

            var tributacao = new ResultadoTributacao(produto, Crt.RegimeNormal, TipoOperacao.OperacaoInterna, TipoPessoa.Juridica);

            var resultado = tributacao.Calcular();
            Assert.AreEqual(37.26m, resultado.ValorIcms);
        }
        
    }
}
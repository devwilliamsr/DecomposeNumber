using DN.Domain.Dtos;
using DN.Domain.Entities;
using DN.Service.Services.DecomposeNumber;
using Xunit;

namespace DN.Test
{
    public class DNTest
    {
        [Fact]
        public void DivisoresSucesso()
        {
            DNService dnService = new DNService();

            DNEntity dn = new DNEntity();

            dn.Numero = 45;

            DNResponse respostaCorreta = new DNResponse
            {
                Divisores = { 1, 3, 5, 9, 15, 45 }
            };

            var respostaObtida = dnService.DecomporNumeros(dn);

            Assert.Equal(respostaCorreta.Divisores, respostaObtida.Divisores);
        }

        [Fact]
        public void NumerosPrimosSucesso()
        {
            DNService dnService = new DNService();

            DNEntity dn = new DNEntity();

            dn.Numero = 45;

            DNResponse respostaCorreta = new DNResponse
            {
                NumerosPrimos = { 3, 5 }
            };

            var respostaObtida = dnService.DecomporNumeros(dn);

            Assert.Equal(respostaCorreta.NumerosPrimos, respostaObtida.NumerosPrimos);
        }

        [Fact]
        public void DivisoresFalhaComZero()
        {
            DNEntity dn = new DNEntity();

            dn.Numero = 0;

            string respostaCorreta = "Valor precisa ser inteiro e maior que zero.";
            string respostaObtida = Utils.Util.ValidarValorDeEntrada(dn.Numero.ToString());

            Assert.Equal(respostaCorreta, respostaObtida);

        }
        [Fact]
        public void DivisoresFalhaComLetra()
        {
            string respostaCorreta = "Valor precisa ser inteiro e maior que zero.";
            string respostaObtida = Utils.Util.ValidarValorDeEntrada("a");

            Assert.Equal(respostaCorreta, respostaObtida);

        }
        [Fact]
        public void DivisoresFalhaComValorNegativo()
        {
            DNEntity dn = new DNEntity();

            dn.Numero = -1;

            string respostaCorreta = "Valor não pode ser negativo.";
            string respostaObtida = Utils.Util.ValidarValorDeEntrada(dn.Numero.ToString());

            Assert.Equal(respostaCorreta, respostaObtida);

        }

        [Fact]
        public void DivisoresFalhaComValorVazio()
        {
            
            string respostaCorreta = "Valor não pode ser vazio.";
            string respostaObtida = Utils.Util.ValidarValorDeEntrada("");

            Assert.Equal(respostaCorreta, respostaObtida);

        }
    }
}

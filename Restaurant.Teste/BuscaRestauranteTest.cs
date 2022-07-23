using Restaurant.Api.Services;
using System;
using Xunit;

namespace Restaurant.Teste
{
    public class BuscaRestauranteTest
    {
        [Fact]
        public void LerArquivoTesteVazio()
        {   
            BuscaRestaurantes busca = new BuscaRestaurantes();
            var result = busca.LerArquivo("efewfewf");
            Assert.Empty(result);
        }

        [Fact]
        public void LerArquivoTesteNull()
        {
            BuscaRestaurantes busca = new BuscaRestaurantes();
            var result = busca.LerArquivo("");

            bool valid = result == null ? true : false;

            Assert.True(valid);
        }

        [Fact]
        public void LerArquivoTesteEncontrarArq()
        {
            BuscaRestaurantes busca = new BuscaRestaurantes();
            var result = busca.LerArquivo("09:10");

            bool valid = result.Count > 0 ? true : false;

            Assert.True(valid);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Restaurant.Api.Services
{
    /// <summary>
    /// Classe com objetivo de ter serviços base para a api
    /// </summary>
    public class BaseServices
    {
        public List<ErroApp> erros { get; set; } = new List<ErroApp>();
        /// <summary>
        /// Retorna o erro para ser exibido
        /// </summary>
        /// <returns>Um ou mais erros gerado durante o processo</returns>
        public string RetornarErro()
        {
            string ret = "";
            foreach (var erro in this.erros)
            {
                ret += $"código do erro: {erro.Codigo}, Detalhes: {erro.Descricao}";
            }
            return ret;
        }

        /// <summary>
        /// Verifica se possui erro na lista
        /// </summary>
        public bool PossuiErro
        {
            get { return erros.Count > 0; }
        }
    }
}

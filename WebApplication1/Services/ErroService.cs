using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Api.Services
{
    /// <summary>
    /// Classe utilizada para para fazer o processo de adicionar os erros na lista
    /// </summary>
    public static class ErroService
    {
        /// <summary>
        /// Metodo Faz o processo de adicionar codErro
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="codErro"></param>
        public static void AddErro(this List<ErroApp> obj, string codErro)
        {
            if (ErroJaAdiciona(obj, codErro)) return;
            obj.Add(new ErroApp() { Codigo = codErro });
        }

        /// <summary>
        /// Metodo Faz o processo de adicionar codErro + mensagem
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="codErro"></param>
        /// <param name="mensagem"></param>
        public static void AddErro(this List<ErroApp> obj, string codErro, string mensagem)
        {
            if (ErroJaAdiciona(obj, codErro)) return;
            obj.Add(new ErroApp() { Codigo = codErro, Descricao = mensagem });
        }

        /// <summary>
        /// Verifica se o erro já foi adicionado
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="codErro"></param>
        /// <returns></returns>
        private static bool ErroJaAdiciona(this List<ErroApp> obj, string codErro)
        {
            return obj.Any(err => err.Codigo == codErro);
        }
    }
}

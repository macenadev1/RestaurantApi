using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Api.Services
{
    /// <summary>
    /// Classe gerencia o processo de erro
    /// </summary>
    public class ErroApp
    {
        [DataMember]
        private string codigo = "";

        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
                try
                {
                    var res = new ResourceManager(typeof(Resourcers.Erros));
                    string ret = res.GetString(value);
                    if ((ret == null || ret == "") && (Detalhes != null && Detalhes.Message != ""))
                    {
                        Descricao = Detalhes.Message;
                    }

                }
                catch (Exception ex)
                {

                    Descricao = ex.Message;
                }

            }
        }
        public string Descricao { get; set; }
        public Exception Detalhes { get; set; }
    }
}

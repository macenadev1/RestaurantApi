using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Api.Services
{
    /// <summary>
    /// Classe para tratar do processo de buscar restaurants abertos
    /// </summary>
    public class BuscaRestaurantes : BaseServices
    {
        /// <summary>
        /// Metodo faz todo processo de validação e leitura do arquivo CSV
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public List<Restaurant> LerArquivo(string hora)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                #region validações
                var path = @"restaurant-hours.csv";
                bool existeArq = File.Exists(path);

                if (string.IsNullOrEmpty(hora))
                {
                    this.erros.AddErro("BuscarRestaurante_001", "Hora não informada para buscar restaurantes abertos.");
                    return null;
                }

                if (!existeArq)
                {
                    this.erros.AddErro("BuscarRestaurante_002","Arquivo não encontrado na pasta base.");
                }

                if (!ValidaHora(hora))
                {
                    this.erros.AddErro("BuscarRestaurante_003", "A hora precisa ser no formato HH:MM, sendo HH entre 1 e 24 e MM entre 00 e 60");
                }
                #endregion

                #region processo para pegar as informações do arquivo
                if (!this.PossuiErro)
                {
                    using (TextFieldParser csvReader = new TextFieldParser(path))
                    {
                        DateTime horaBuscaRestaurantes = DateTime.Parse(hora);
                        csvReader.CommentTokens = new string[] { "#" };
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;


                        csvReader.ReadLine();

                        while (!csvReader.EndOfData)
                        {
                            string[] fields = csvReader.ReadFields();
                            var splitTeste = fields[1].Split("-");

                            DateTime horaInicial = DateTime.Parse(splitTeste[0]);
                            DateTime horaFinal = DateTime.Parse(splitTeste[1]);

                            bool restauranteAberto = horaBuscaRestaurantes >= horaInicial && horaBuscaRestaurantes <= horaFinal;

                            if (restauranteAberto)
                            {
                                restaurants.Add(new Restaurant(fields[0]));
                            }
                        }

                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

                this.erros.AddErro(ex.Message);
            }

            return restaurants;
        }

        /// <summary>
        /// Metodo faz a validação das horas permitidas
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        public bool ValidaHora(string hora)
        {
            if(hora.Length != 5 || !hora.Contains(":"))
            {
                return false;
            }

            String[] hm = hora.Split(":");
            int horas = int.Parse(hm[0]);
            int minutos = int.Parse(hm[1]);

            if (horas < 1 || horas > 24)
            {
                return false;
            }
            else if(minutos > 60)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
 }


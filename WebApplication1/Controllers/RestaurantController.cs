using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Restaurant.Api.Services;

namespace Restaurant.Api.Controllers
{
    /// <summary>
    /// Endpoint relacionado a restaurante
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class RestaurantController : ControllerBase
    {
        /// <summary>
        /// Verifica restaurantes abertos
        /// </summary>
        /// <param name="hora"></param>Informe no formato HH:MM sendo HH entre 1 e 24 e MM entre 00 e 60
        /// <response code="200">Sucesso ao buscar restaurantes abertos</response> Encontrou restaurantes abertos com sucesso
        /// <responde code="500"></responde> Ocorreu um erro ao buscar restaurantes abertos
        [HttpGet("OpenRestaurants")]
        [ProducesResponseType(typeof(List<Restaurant>),200)]
        [ProducesResponseType(500)]
        public ActionResult OpenRestaurants(string hora)
        {
            try
            {
                BuscaRestaurantes busca = new BuscaRestaurantes();
                var retorno = busca.LerArquivo(hora);

                if (busca.PossuiErro)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, busca.erros);
                }

                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}

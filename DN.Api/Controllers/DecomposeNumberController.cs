using System;
using System.Collections.Generic;
using DN.Domain.Dtos;
using DN.Domain.Entities;
using DN.Domain.Interfaces;
using DN.Service.Services.DecomposeNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Utils;

namespace DN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecomposeNumberController : ControllerBase
    {
        private static IDecomposeService _decomposeService;

        [HttpGet("{numero}")]
        public ActionResult<IList<int>> Get(int numero)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _decomposeService = serviceProvider.GetService<IDecomposeService>();

            string valorLido = numero.ToString(); //Usado valor como string para passar para função da linha abaixo e ser feita as devidas tratativas.
            string msgErro = Util.ValidarValorDeEntrada(valorLido);

            //Se a condicional abaixo for verdade, ou seja, a função ValidarValorDeEntrada retornou uma mensagem, é sinal que o valor digitado é inválido e o retorno sera do erro.
            //Caso contrário o valor é válido e segue para a regra de negócio.
            if (!String.IsNullOrEmpty(msgErro))
            {
                return BadRequest(msgErro);
            }

            DNEntity dn = new DNEntity();

            dn.Numero = numero;

            DNResponse response = _decomposeService.DecomporNumeros(dn);

            if (response.Erro != "")
            {
                return BadRequest(response.Erro);
            }
            else
            {
                return Ok(response);

            }
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDecomposeService, DNService>();
        }
    }
}
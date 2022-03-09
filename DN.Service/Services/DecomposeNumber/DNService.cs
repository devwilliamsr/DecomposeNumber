using System;
using DN.Domain.Dtos;
using DN.Domain.Entities;
using DN.Domain.Interfaces;
using Utils;

namespace DN.Service.Services.DecomposeNumber
{

    public class DNService : IDecomposeService
    {
        public DNResponse DecomporNumeros(DNEntity dn)
        {
            DNResponse response = new DNResponse();
            response.Erro = "";

            try
            {
                for (int i = 1; i <= dn.Numero; i++)
                {
                    if (Util.ValidaDivisor(dn.Numero, i))
                    {
                        response.Divisores.Add(i); //Lista dos números que são divisores
                    }
                }

                foreach (var item in response.Divisores)
                {
                    if (Util.ValidaNumeroPrimo(item))
                    {
                        response.NumerosPrimos.Add(item); //Lista de números primos.
                    }
                }

            }
            catch (Exception ex)
            {
                response.Erro = ex.Message;
            }

            return response;
        }
    }
}
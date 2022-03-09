using System;
using DN.Domain.Dtos;
using DN.Domain.Entities;
using DN.Domain.Interfaces;
using DN.Service.Services.DecomposeNumber;
using Microsoft.Extensions.DependencyInjection;
using Utils;

namespace application
{
    public class Program
    {
        private static IDecomposeService _decomposeService;
        
        static void Main(string[] args)
        {
            //https://marcionizzola.medium.com/como-fazer-inje%C3%A7%C3%A3o-de-depend%C3%AAncia-em-um-console-application-com-net-core-c5d66f092593 
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _decomposeService = serviceProvider.GetService<IDecomposeService>();

            Saudacao();
        }

        //Fazendo a inserção da interface
        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDecomposeService, DNService>();
        }


        //Método criada no intúito de oferecer uma saudação ao usuário.
        private static void Saudacao()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo(a) ao Decompose Number :)");
            Console.WriteLine("-----------------------------------");

            MenuPrincipal();
        }

        //Menu criado para atender a necessidade do projeto. Decompor um número e mostrar os números decompostos que são primos.
        private static void MenuPrincipal()
        {
            Console.Write("\n\rDigite um número inteiro e positivo: ");

            string valorLido = Console.ReadLine().ToString(); //Usado valor como string para que consigamos usar para a função da linha abaixo e ser feita as devidas validações.
            string msgErro = Util.ValidarValorDeEntrada(valorLido);

            //Se a condicional abaixo for verdade, ou seja, a função ValidarValorDeEntrada retornou uma mensagem, é sinal que o valor digitado é inválido e o retorno sera do erro.
            //Caso contrário o valor é válido e segue para a regra de negócio.
            if (!String.IsNullOrEmpty(msgErro))
            {
                Console.WriteLine($"ATENÇÃO!!! {msgErro}");
                MenuNovaTentativa();
            }

            DNEntity dn = new DNEntity();

            dn.Numero = Int32.Parse(valorLido); //Como o valor é válido, transformamos o mesmo para inteiro.

            DNResponse response = _decomposeService.DecomporNumeros(dn);

            if (response.Erro != "")
            {
                Console.WriteLine(response.Erro);
            }
            else
            {
                Console.WriteLine($"O(s) número(s) que o {valorLido} possui divisores: {string.Join(",", response.Divisores)}");
                
                if (response.NumerosPrimos.Count > 0)
                    Console.WriteLine($"O(s) número(s) primo(s): {string.Join(",", response.NumerosPrimos)}");
                else
                    Console.WriteLine("Não há número primo.");

                MenuNovaTentativa();
            }

            Console.ReadKey();
        }

        //Menu criado para oferecer nova tentativa ou fechar o sistema
        private static void MenuNovaTentativa()
        {
            Console.WriteLine("\n\rDeseja fazer uma nova consulta? Digite S para SIM ou N para NÃO: ");

            var valorLido = Console.ReadLine();

            switch (valorLido.ToUpper())
            {
                case "S":
                    MenuPrincipal();
                    break;
                case "N":
                    Despedida();
                    break;
                default:
                    MenuNovaTentativa();
                    break;
            }
        }

        //Método criado para exibir uma mensagem de despedida
        private static void Despedida()
        {
            Console.WriteLine("\n.---------------------------.");
            Console.WriteLine("|Obrigado e até a próxima...|");
            Console.WriteLine("'---------------------------'");
            Environment.Exit(1);
            Console.ReadKey();
        }
    }
}

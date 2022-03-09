namespace Utils
{
    public class Util
    {
        //Validando se o valor digitado é válido e retornando a mensagem de erro caso seja inválido
        public static string ValidarValorDeEntrada(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return "Valor não pode ser vazio.";
            }
            else if (!int.TryParse(valor, out int intAux) || intAux<=0)
            {
                if(intAux < 0)
                {
                    return "Valor não pode ser negativo.";
                }

                return "Valor precisa ser inteiro e maior que zero.";

            }

            return "";
        }

        //Os Números Primos são números naturais maiores do que 1 que possuem somente dois divisores, ou seja, são divisíveis por 1 e por ele mesmo.
        public static bool ValidaNumeroPrimo(int numero)
        {
            if (numero <= 1)
                return false;

            for (int i = 2; i < numero; i++) //começando i = 2 pois se for i = 1 a condicional if seria verdade e não conseguiremos tratar os primos de forma correta
            {
                //se for verdade o número não é primo
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true; //se chegou até aqui é porque o número é primo
        }

        public static bool ValidaDivisor(int numero, int divisor)
        {
            if (numero % divisor == 0) //se a divisão for igual a zero é porque o número é um divisor.
                return true;

            return false;
        }
    }
}

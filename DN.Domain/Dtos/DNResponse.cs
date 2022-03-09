using System.Collections.Generic;

namespace DN.Domain.Dtos
{
    public class DNResponse
    {
        public List<int> Divisores { get; set; }
        public List<int> NumerosPrimos { get; set; }
        public string Erro { get; set; }

        public DNResponse()
        {
            Divisores = new List<int>();
            NumerosPrimos = new List<int>();
        }
    }
}
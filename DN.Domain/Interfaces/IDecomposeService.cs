using DN.Domain.Entities;
using DN.Domain.Dtos;

namespace DN.Domain.Interfaces
{

    public interface IDecomposeService
    {
        DNResponse DecomporNumeros(DNEntity dn);
    }
}
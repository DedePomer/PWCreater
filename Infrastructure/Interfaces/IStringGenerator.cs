using PWCreater.Model.UserType;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Interfaces
{
    public interface IStringGenerator
    {
        public Task<byte[,]> GetPasswordBytes(int symbolCount, SymbolAlphabet symbolAlphabet);

    }
}

using PWCreater.Model.UserType;
using System.Threading;
using System.Threading.Tasks;

namespace PWCreater.Infrastructure.Interfaces
{
    public interface IStringGenerator
    {
        Task<byte[,]> GetPasswordBytes(int symbolCount, SymbolAlphabet symbolAlphabet, CancellationTokenSource cancelTokenSource);

    }
}

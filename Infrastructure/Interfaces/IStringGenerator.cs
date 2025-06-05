using PWCreater.Model.UserType;

namespace PWCreater.Infrastructure.Interfaces
{
    public interface IStringGenerator
    {
        public byte[,] GetPasswordBytes(int symbolCount, SymbolAlphabet symbolAlphabet);

    }
}

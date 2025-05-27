using PWCreater.Model.UserType;

namespace PWCreater.Infrastructure.Interfaces
{
    public interface IStringGenerator
    {
        public string GetPasswordString(int symbolCount, SymbolAlphabet symbolAlphabet);

    }
}

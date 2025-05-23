namespace PWCreater.Model.UserType
{
    internal class SymbolAlphabet
    {
        private  bool _lowerLatinLetters = true ;
        public bool LowerLatinLetters 
        {
            get 
            {
                return _lowerLatinLetters;
            }
            set 
            {
                _lowerLatinLetters = value;
            }
        }
        public bool UpperLatinLetters { get; set; }
        public bool SpecialSymbols { get; set; }
    }
}

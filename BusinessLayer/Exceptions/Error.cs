namespace Otomativ_e_ticaret.Models
{
    public class Error : Exception
    {
        public Error(){}
        public Error(string errormessage)
        
            : base (errormessage)
        {}
    }
}

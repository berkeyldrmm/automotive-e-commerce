namespace Otomativ_e_ticaret.Models
{
    public class Error : Exception
    {
        public bool error { get; set; }
        public string ErrorMessage { get; set; }
    }
}

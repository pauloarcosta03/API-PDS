namespace API_PDS.ViewModel
{
    public class NovoCondominioViewModel
    {
        public string Nome { get; set; }
        public int Nif { get; set; }
        public int NPorta { get; set; }
        public int CondominioId { get; set; }
        public int? GestorCondominioId { get; set; }
        public int? LoginId { get; set; }
        public string Password { get; set; }
        public string contacto { get; set; }
        public string contactoTag { get; set; }

        public string CP { get; set; }
        public string Localidade { get; set; }
        public string Morada { get; set; }
    }
}

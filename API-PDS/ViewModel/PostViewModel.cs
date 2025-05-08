namespace API_PDS.ViewModel
{
    public class PostViewModel
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string? Foto { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UtilizadorId { get; set; }
    }
}

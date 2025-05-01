namespace API_PDS.ViewModel
{
    public class ReuniaoViewModel
    {
        public int Id { get; set; }
        public DateTime? Horario { get; set; }
        public int UtilizadorId { get; set; }
        public string Estado { get; set; }
        public string? Ata { get; set; }
        public int? GestorCondominioId { get; set; }
    }
}

namespace API.Application.ViewModels
{
    public class ConsultaViewModel
    {
        public int PacienteId { get; set; }
        public int Medico_id { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data_hora { get; set; }
    }
}

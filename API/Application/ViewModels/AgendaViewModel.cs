namespace API.Application.ViewModels
{
    public class AgendaViewModel
    {
        public int consulta_id { get; set; }
        public DateOnly data {  get; set; }
        public TimeOnly hora { get; set; }
    }
}

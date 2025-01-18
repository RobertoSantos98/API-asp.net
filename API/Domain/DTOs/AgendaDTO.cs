namespace API.Domain.DTOs
{
    public class AgendaDTO
    {
        public int id { get; set; }
        public string data { get; set; }
        public string hora {  get; set; }
        public bool disponivel {  get; set; }
        public string? medico { get; set; }

         
        public AgendaDTO() { }

        public AgendaDTO(int id, string data, string hora, bool disponivel, string medico)
        {
            this.id = id;
            this.data = data;
            this.hora = hora;
            this.disponivel = disponivel;
            this.medico = medico;
        }
    }


}

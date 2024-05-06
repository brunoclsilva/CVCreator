namespace CVCreator.Domain.Entities.Models
{
    public class CVPayload
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Birth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Linkedin { get; set; }
        public List<Language> Languages { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}

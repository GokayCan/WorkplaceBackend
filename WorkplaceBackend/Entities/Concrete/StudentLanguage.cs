namespace Entities.Concrete
{
    public class StudentLanguage
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LanguageId { get; set; }
        public bool IsActive { get; set; }
    }
}

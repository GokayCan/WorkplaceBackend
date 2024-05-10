namespace Entities.Concrete
{
    public class StudentProgramming
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProgrammingId { get; set; }
        public bool IsActive { get; set; }
    }
}

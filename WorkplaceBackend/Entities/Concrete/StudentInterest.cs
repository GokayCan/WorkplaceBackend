namespace Entities.Concrete
{
    public class StudentInterest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int InterestId { get; set; }
        public bool IsActive { get; set; }

    }
}

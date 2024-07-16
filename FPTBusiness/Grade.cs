namespace FPTBusiness
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public decimal Point { get; set; }

        public DateTime? DateCreate { get; set; }

        public virtual Student Student { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;
    }

}

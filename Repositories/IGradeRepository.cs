using FPTBusiness;

namespace Repositories
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetAllGrade();
        Task<Grade> GetGradeById(int gradeId);
        Task InsertGrade(Grade grade);
        Task UpdateGrade(Grade grade);
        Task DeleteGrade(Grade grade);

    }
}

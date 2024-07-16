using FPTBusiness;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataLayerAccess
{
    public class GradeDAO : SingletonBase<GradeDAO>
    {
        private MyStudentDbContext? _context;
        public async Task<List<Grade>> GetAllGrade()
        {
            _context = new();
            return await _context.Grades.AsNoTracking().Include(g=> g.Subject).Include(g => g.Student).ToListAsync();
        }
        public async Task<Grade> GetGradeById(int gradeId)
        {
            try
            {
                _context = new();
                var grade = await _context.Grades.FirstOrDefaultAsync(g => g.GradeId == gradeId);
                return grade!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task InsertGrade(Grade grade)
        {
            _context = new();
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateGrade(Grade grade)
        {
            try
            {
                _context = new();
                var existingItem = await GetGradeById(grade.GradeId);
                if (existingItem != null)
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(grade);
                }
                else
                {
                    _context.Grades.Update(grade);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteGrade(Grade grade)
        {
            try
            {
                _context = new();
                var findGrade = await GetGradeById(grade.GradeId);
                if (findGrade != null)
                {
                    _context.Grades.Remove(findGrade);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

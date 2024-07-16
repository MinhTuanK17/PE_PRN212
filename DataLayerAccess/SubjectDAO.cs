using FPTBusiness;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class SubjectDAO : SingletonBase<SubjectDAO>
    {
        private MyStudentDbContext? _context;
        public async Task<List<Subject>> GetAllSubject()
        {
            _context = new();
            return await _context.Subjects.AsNoTracking().ToListAsync();
        }
        public async Task<Subject> GetSubjectById(int subjectId)
        {
            try
            {
                _context = new();
                var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId);
                return subject!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task InsertSubject(Subject sub)
        {
            _context = new();
            _context.Subjects.Add(sub);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateSubject(Subject sub)
        {
            try
            {
                _context = new();
                var existingItem = await GetSubjectById(sub.SubjectId);
                if (existingItem != null)
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(sub);
                }
                else
                {
                    _context.Subjects.Update(sub);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteSubject(Subject sub)
        {
            try
            {
                _context = new();
                var findSub = await GetSubjectById(sub.SubjectId);
                if (findSub != null)
                {
                    _context.Subjects.Remove(findSub);
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

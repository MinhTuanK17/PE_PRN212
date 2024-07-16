using FPTBusiness;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class StudentDAO : SingletonBase<StudentDAO>
    {
        private MyStudentDbContext? _context;
        public async Task<List<Student>> GetAllStudent()
        {
            _context = new();
            return await _context.Students.AsNoTracking().ToListAsync();
        }
        public async Task<Student> GetStudentById(int studentID)
        {
            try
            {
                _context = new();
                var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentID);
                return student!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task InsertStudent(Student stu)
        {
            _context = new();
            _context.Students.Add(stu);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateStudent(Student stu)
        {
            try
            {
                _context = new();
                var existingItem = await GetStudentById(stu.StudentId);
                if (existingItem != null)
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(stu);
                }
                else
                {
                    _context.Students.Update(stu);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteStudent(Student stu)
        {
            try
            {
                _context = new();
                var findStu = await GetStudentById(stu.StudentId);
                if (findStu != null)
                {
                    _context.Students.Remove(findStu);
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

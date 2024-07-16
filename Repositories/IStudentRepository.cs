using FPTBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(int studentID);
        Task InsertStudent(Student stu);
        Task UpdateStudent(Student stu);
        Task DeleteStudent(Student stu);

    }
}

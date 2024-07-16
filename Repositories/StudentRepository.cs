using DataLayerAccess;
using FPTBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task DeleteStudent(Student stu) => await StudentDAO.Instance.DeleteStudent(stu);
        public async Task<List<Student>> GetAllStudent() => await StudentDAO.Instance.GetAllStudent();

        public async Task<Student> GetStudentById(int studentID) => await StudentDAO.Instance.GetStudentById(studentID);

        public async Task InsertStudent(Student stu) => await StudentDAO.Instance.InsertStudent(stu);


        public async Task UpdateStudent(Student stu) => await StudentDAO.Instance.UpdateStudent(stu);
    }
}

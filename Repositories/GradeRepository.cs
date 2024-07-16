using DataLayerAccess;
using FPTBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GradeRepository : IGradeRepository
    {
        public async Task DeleteGrade(Grade grade) => await GradeDAO.Instance.DeleteGrade(grade);

        public async Task<List<Grade>> GetAllGrade() => await GradeDAO.Instance.GetAllGrade();

        public async Task<Grade> GetGradeById(int gradeId) => await GradeDAO.Instance.GetGradeById(gradeId);

        public async Task InsertGrade(Grade grade) => await GradeDAO.Instance.InsertGrade(grade);

        public async Task UpdateGrade(Grade grade) => await GradeDAO.Instance.UpdateGrade(grade);
    }
}

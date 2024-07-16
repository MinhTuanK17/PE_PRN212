using DataLayerAccess;
using FPTBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        public async Task DeleteSubject(Subject sub) => await SubjectDAO.Instance.DeleteSubject(sub);

        public async Task<List<Subject>> GetAllSubject() => await SubjectDAO.Instance.GetAllSubject();

        public async Task<Subject> GetSubjectById(int subjectId) => await SubjectDAO.Instance.GetSubjectById(subjectId);
        public async Task InsertSubject(Subject sub) => await SubjectDAO.Instance.InsertSubject(sub);

        public async Task UpdateSubject(Subject sub) => await SubjectDAO.Instance.UpdateSubject(sub);
    }
}

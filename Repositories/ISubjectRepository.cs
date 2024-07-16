using FPTBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubject();
        Task<Subject> GetSubjectById(int subjectId);
        Task InsertSubject(Subject sub);
        Task UpdateSubject(Subject sub);
        Task DeleteSubject(Subject sub);

    }
}

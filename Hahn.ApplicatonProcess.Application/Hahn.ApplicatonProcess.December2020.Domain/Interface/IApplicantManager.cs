using Hahn.ApplicatonProcess.December2020.Data;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public interface IApplicantManager
    {
        IEnumerable<Applicant> GetAll();
        Applicant GetById(int id);
        void Create(Applicant applicant);
        void Update(int id, Applicant applicant);
        void Delete(int id);
    }
}

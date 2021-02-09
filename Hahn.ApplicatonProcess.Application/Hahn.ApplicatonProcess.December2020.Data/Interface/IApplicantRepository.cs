using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetAll();
        Applicant GetById(int id);
        void Create(Applicant applicant);
        void Update(Applicant applicant);
        void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApplicantRepository : IApplicantRepository
    {
        HannDbContext _DbContext;

        public ApplicantRepository(HannDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IEnumerable<Applicant> GetAll()
        {            
            return _DbContext.Applicants;
        }

        public Applicant GetById(int id)
        {
           return _DbContext.Applicants.Where(x => x.ID == id).FirstOrDefault();
        }

        public void Create(Applicant applicant)
        {
            _DbContext.Applicants.Add(applicant);
            _DbContext.SaveChanges();
        }

        public void Update(Applicant applicant)
        {
            _DbContext.Applicants.Update(applicant);
            _DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Applicant app = _DbContext.Applicants.Where(x => x.ID == id).FirstOrDefault();
            _DbContext.Applicants.Remove(app);
            _DbContext.SaveChanges();
        }
    }
}

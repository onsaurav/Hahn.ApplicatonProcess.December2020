using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class ApplicantManager : IApplicantManager
    {
        private IApplicantRepository _ApplicantRepository;

        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _ApplicantRepository = applicantRepository;
        }

        public IEnumerable<Applicant> GetAll()
        {
            return _ApplicantRepository.GetAll();
        }

        public Applicant GetById(int id)
        {
            Applicant applicant = _ApplicantRepository.GetById(id);
            if(applicant == null)
            {
                throw new Exception(string.Format("No applicant has been found by this id : {0}", id));
            }

            return applicant;
        }

        public void Create(Applicant applicant)
        {
            Applicant dupApplicant = _ApplicantRepository.GetById(applicant.ID);
            if (dupApplicant != null)
            {
                throw new Exception(string.Format("An applicant allready exists in the database by this id : {0}", dupApplicant.ID));
            }

            _ApplicantRepository.Create(applicant);
        }

        public void Update(int id, Applicant applicant)
        {
            if(id == 0)
            {
                throw new Exception(string.Format("Invalid applicant id supplied: {0}", id));
            }

            Applicant dupApplicant = _ApplicantRepository.GetById(id);
            if (dupApplicant == null)
            {
                throw new Exception(string.Format("No applicant has been found by this id : {0}", id));
            }
            _ApplicantRepository.Update(applicant);
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception(string.Format("Invalid applicant id supplied: {0}", id));
            }

            Applicant dupApplicant = _ApplicantRepository.GetById(id);
            if (dupApplicant == null)
            {
                throw new Exception(string.Format("No applicant has been found by this id : {0}", id));
            }

            _ApplicantRepository.Delete(id);
        }        
    }
}

using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Web.Mapper
{
    public class AutomapperMapping: Profile
    {
        public AutomapperMapping()
        {
            CreateMap<ApplicantModel, Applicant>();
            CreateMap<Applicant, ApplicantModel>().ReverseMap();
        }
    }
}

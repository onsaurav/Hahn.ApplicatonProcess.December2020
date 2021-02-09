 using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Logger;
using Hahn.ApplicatonProcess.December2020.Web.Exceptions;
using Hahn.ApplicatonProcess.December2020.Web.Filter;
using Hahn.ApplicatonProcess.December2020.Web.Helper;
using Hahn.ApplicatonProcess.December2020.Web.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
  /// <summary>
  ///   Applicant Controller / API
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class ApplicantController : ControllerBase
  {
    IMapper _Mapper;
    ILogHelper _LogHelper;
    IApplicantManager _ApplicantManager;

    /// <summary>Initializes a new instance of the <see cref="ApplicantController" /> class.</summary>
    /// <param name="logHelper">The logger.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="applicantManager">The applicant manager.</param>
    public ApplicantController(ILogHelper logHelper, IMapper mapper, IApplicantManager applicantManager)
    {
      _LogHelper = logHelper;
      _Mapper = mapper;
      _ApplicantManager = applicantManager;
    }

    // GET: api/<ApplicantController>
    /// <summary>Gets this instance.</summary>
    /// <returns>
    ///   <br />
    /// </returns>
    [HttpGet]
    [ApiExceptionFilter]
    public IEnumerable<ApplicantModel> Get()
    {
      _LogHelper.Information(String.Format("Get regqest 'api/applicant has come.'"));

      try
      {
        List<ApplicantModel> applicants = _Mapper.Map<List<ApplicantModel>>(_ApplicantManager.GetAll());
        return applicants;
      }
      catch (Exception ex)
      {
        _LogHelper.Error(String.Format("Get regqest 'api/applicant got the followwing error: {0}", ex.ToString()));
        throw new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest);
      }
    }

    // GET api/<ApplicantController>/5
    /// <summary>Gets the specified identifier.</summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    [HttpGet("{id}")]
    [ApiExceptionFilter]
    public ApplicantModel Get(int id)
    {
      _LogHelper.Information(String.Format("Get regqest 'api/applicant?id has come.'"));

      try
      {
        return _Mapper.Map<ApplicantModel>(_ApplicantManager.GetById(id));
      }
      catch (Exception ex)
      {
        _LogHelper.Error(String.Format("Get regqest 'api/applicant?id got the followwing error: {0}", ex.ToString()));
        throw new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest);
      }
    }

    // POST api/<ApplicantController>
    /// <summary>Posts the specified applicant model.</summary>
    /// <param name="applicantModel">The applicant model.</param>
    [HttpPost]
    [ApiExceptionFilter]
    public ActionResult Post([FromBody] ApplicantModel applicantModel)
    {
      Applicant applicant = new Applicant();
      _LogHelper.Information(String.Format("Post regqest 'api/applicant has come.'"));

      try
      {
        if (ModelState.IsValid)
        {
          applicant = _Mapper.Map<Applicant>(applicantModel);
          _ApplicantManager.Create(applicant);
        }
      }
      catch (Exception ex)
      {
        _LogHelper.Error(String.Format("Post regqest 'api/applicant got the followwing error: {0}", ex.ToString()));
        throw new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest);
      }

      return Created(string.Format("/api/Applicant/{0}", applicant.ID), applicant);
    }

    // PUT api/<ApplicantController>/5
    /// <summary>Puts the specified identifier.</summary>
    /// <param name="id">The identifier.</param>
    /// <param name="applicantModel">The applicant model.</param>
    [HttpPut("{id}")]
    [ApiExceptionFilter]
    public void Put(int id, [FromBody] ApplicantModel applicantModel)
    {
      _LogHelper.Information(String.Format("Put regqest 'api/applicant has come.'"));

      try
      {
        if (ModelState.IsValid)
        {
          Applicant applicant = _Mapper.Map<Applicant>(applicantModel);
          _ApplicantManager.Update(id, applicant);
        }
      }
      catch (Exception ex)
      {
        _LogHelper.Error(String.Format("Put regqest 'api/applicant got the followwing error: {0}", ex.ToString()));
        throw new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest);
      }
    }


    /// <summary>Deletes the specified identifier.</summary>
    /// <param name="id">The identifier.</param>
    [HttpDelete("{id}")]
    [ApiExceptionFilter]
    public void Delete(int id)
    {
      _LogHelper.Information(String.Format("Delete regqest 'api/applicant has come.'"));

      try
      {
        _ApplicantManager.Delete(id);

      }
      catch (Exception ex)
      {
        _LogHelper.Error(String.Format("Delete regqest 'api/applicant got the followwing error: {0}", ex.ToString()));
        throw new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest);
      }
    }
  }
}

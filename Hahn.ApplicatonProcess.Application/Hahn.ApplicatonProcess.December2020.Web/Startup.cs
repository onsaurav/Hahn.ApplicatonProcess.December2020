using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Logger;
using Hahn.ApplicatonProcess.December2020.Web.Filter;
using Hahn.ApplicatonProcess.December2020.Web.Helper;
using Hahn.ApplicatonProcess.December2020.Web.Mapper;
using Hahn.ApplicatonProcess.December2020.Web.Model;
using Hahn.ApplicatonProcess.December2020.Web.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(c =>
      {
        c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
      });



      var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v5", new OpenApiInfo { Title = "Hahn.ApplicatonProcess.December2020.Web", Version = "v5" });
        c.IncludeXmlComments(xmlPath);
      });


      //Register for Dpendency Injection
      RegisterServices(services);

      // Auto Mapper Configurations
      var mapperConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new AutomapperMapping());
      });

      IMapper mapper = mapperConfig.CreateMapper();
      services.AddSingleton(mapper);

      //Regerter Fluent Validator
      services.AddMvc(opt =>
      {
        opt.Filters.Add(typeof(ValidatorActionFilter));
      }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ApplicantValidator>());

      services.AddTransient<IValidator<ApplicantModel>, ApplicantValidator>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
      services.AddScoped<IApplicantRepository, ApplicantRepository>();
      services.AddScoped<IApplicantManager, ApplicantManager>();
      services.AddScoped<IHahnLogger, HahnLogger>();
      services.AddScoped<ILogHelper, LogHelper>();

      services.AddDbContext<HannDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "HannApplicantInMemory"));
      services.AddScoped<HannDbContext>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v5/swagger.json", "Hahn.ApplicatonProcess.December2020.Web v5"));
      }

      //app.UseCors(options => options.AllowAnyOrigin());
      app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      //app.UseEndpoints(endpoints =>
      //{
      //    endpoints.MapControllers();
      //});      

      app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=index}/{id?}"
                  );
            });
    }
  }
}

using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Web.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Validator
{
    public class ApplicantValidator : AbstractValidator<ApplicantModel>
	{
		public ApplicantValidator()
		{
			RuleFor(x => x.ID).NotNull();
			RuleFor(x => x.Name).NotNull().MinimumLength(5);
			RuleFor(x => x.FamilyName).NotNull().MinimumLength(5);
			RuleFor(x => x.EMailAdress).NotNull().MinimumLength(10).EmailAddress().Must(q => IsValisEmail(q));
			RuleFor(x => x.CountryOfOrigin).NotNull().Must(q=> IsValisCountry(q));
			RuleFor(x => x.Age).NotNull().InclusiveBetween(20, 60);
		}

        private bool IsValisEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public bool IsValisCountry(string countryName)
        {
            bool val = IsValisCountry11( countryName).Result;
            return val;
        }

        private async Task<bool> IsValisCountry11(string countryName)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://restcountries.eu/rest/v2/name/" + countryName))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<CountryData> countryList = JsonConvert.DeserializeObject<List<CountryData>>(apiResponse);
                        if (countryList.Count > 0)
                        {
                            if (countryList.Where(x => x.name.ToLower().Trim() == countryName.ToLower().Trim()).Count() > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch 
            {
                return false;
            }

            return false;
        }
    }
}

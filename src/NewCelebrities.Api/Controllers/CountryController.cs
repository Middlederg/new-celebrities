using Microsoft.AspNetCore.Mvc;
using NewCelebrities.Api.Services;

namespace NewCelebrities.Api
{
    [ApiController]
    [Route(Shared.CountriesEndpoints.Base)]
    public class CountryController : ControllerBase
    {
        private readonly FileRepository repository;

        public CountryController(FileRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Shared.GetCountriesResponse> GetAll()
        {
            var countries = repository.CountryList();
            return Ok(new Shared.GetCountriesResponse()
            {
                Countries = countries,
            });
        }
    }
}

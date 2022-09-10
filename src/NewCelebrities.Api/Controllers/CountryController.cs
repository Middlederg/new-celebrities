using Microsoft.AspNetCore.Mvc;
using NewCelebrities.Api.Services;

namespace NewCelebrities.Api
{
    [ApiController]
    [Route(Shared.RegionEndpoints.Base)]
    public class RegionController : ControllerBase
    {
        private readonly FileRepository repository;

        public RegionController(FileRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Shared.GetRegionsResponse> GetAll()
        {
            var regions = repository.RegionList();
            return Ok(new Shared.GetRegionsResponse()
            {
                Regions = regions,
            });
        }
    }
}

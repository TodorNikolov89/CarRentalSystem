namespace CarRentalSystem.Web.Features
{
    using Application.Features.CarAds.Queries.Search;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("/CarAd")]
    public class CarAdsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Get(
            [FromQuery] SearchCarAdsQuery query)
            => await this.Mediator.Send(query);
    }
}

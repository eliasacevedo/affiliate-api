using Business.Business.Affiliates;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AffiliateController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IAffiliateLogic affiliateLogic;
    public AffiliateController(ILogger<WeatherForecastController> logger, IAffiliateLogic affiliateLogic)
    {
        _logger = logger;
        this.affiliateLogic = affiliateLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<Affiliate>> Get([FromQuery]SearchFilterAffiliatePage? filter)
    {
        return await affiliateLogic.GetAffiliates(filter);
    }
}

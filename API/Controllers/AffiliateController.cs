using Business.Business.Affiliates;
using Domain;
using DTOs;
using DTOs.Affiliates;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AffiliateController : ControllerBase
{
    private readonly ILogger<AffiliateController> _logger;
    private readonly IAffiliateLogic affiliateLogic;
    public AffiliateController(ILogger<AffiliateController> logger, IAffiliateLogic affiliateLogic)
    {
        _logger = logger;
        this.affiliateLogic = affiliateLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<Affiliate>> Get([FromQuery]SearchFilterAffiliatePage? filter)
    {
        return await affiliateLogic.GetAffiliates(filter);
    }

    [HttpPost("Insert")]
    public async Task Post([FromBody] Affiliate affiliate)
    {
        await affiliateLogic.CreateAffiliate(affiliate);
    }

    [HttpPost("Update")]
    public async Task Update([FromBody] Affiliate affiliate)
    {
        await affiliateLogic.UpdateAffiliate(affiliate);
    }

    [HttpPost("AddAmount")]
    public async Task AddAmount([FromBody] AmountConsumedAffiliate affiliate)
    {
        await affiliateLogic.AddConsumedAmount(affiliate);
    }
}

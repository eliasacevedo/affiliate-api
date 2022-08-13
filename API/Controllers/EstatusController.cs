using Business.Business.Affiliates;
using Business.Business.Estatus;
using Domain;
using DTOs;
using DTOs.Affiliates;
using DTOs.Estatus;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EstatusController : ControllerBase
{
    private readonly ILogger<AffiliateController> _logger;
    private readonly IEstatusLogic estatusLogic;
    public EstatusController(ILogger<AffiliateController> logger, IEstatusLogic estatusLogic)
    {
        _logger = logger;
        this.estatusLogic = estatusLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<Estatus>> Get([FromQuery] SearchEstatusFilter? filter)
    {
        return await estatusLogic.GetEstatus(filter);
    }

}

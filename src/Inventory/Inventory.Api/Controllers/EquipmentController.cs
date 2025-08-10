using Common.Api.Controllers;
using Inventory.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : BaseApiController
{
    [HttpGet]
    [Route("detail")]
    public async Task<ActionResult<EquipmentResponse>> GetEquipmentDetails(
    [FromQuery] GetEquipmentQuery query)
        => await Send(query); 
}
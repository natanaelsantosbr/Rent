using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rent.API.Abstractions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RentController : ControllerBase
    {

    }
}

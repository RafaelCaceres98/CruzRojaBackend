using Backend_CruzRoja.AppService;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CruzRoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DashboardController : ControllerBase
    {
        private readonly DashboardAppservice dashboardAppservice;

        public DashboardController(DashboardAppservice dashboardAppservice)
        {
            this.dashboardAppservice = dashboardAppservice;
        }

        [HttpGet("DashBodard")]
        public async Task<IActionResult> Get()
        {
            return Ok(await dashboardAppservice.GetDashboardData());
        }
    }
}

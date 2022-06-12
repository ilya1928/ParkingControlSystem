using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingControl.API.Services;
using ParkingControl.Database.Models;
using ParkingControl.Shared.DTO.Report;
using System.Threading.Tasks;

namespace ParkingControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;
        private readonly IMapper mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            this.reportService = reportService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateReportAsync(CreateReportRequest createReportRequest)
        {
            var report = mapper.Map<Report>(createReportRequest);
            await reportService.CreateReportAsync(report);

            return Ok();
        }
    }
}

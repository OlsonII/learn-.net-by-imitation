using Microsoft.AspNetCore.Mvc;
using VeterinaryManager.API.Extensions;
using VeterinaryManager.Domain.Entities;
using VeterinaryManager.Domain.Services;

namespace VeterinaryManager.API.Controllers;

[ApiController]
[ApiVersion("1")]
[AuthenticationMiddleware]
[Route("[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorServices _doctorServices;

    public DoctorsController(IDoctorServices doctorServices)
    {
        _doctorServices = doctorServices;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] Doctor doctor)
    {
        await _doctorServices.Register(doctor);
        return NoContent();
    }

    [HttpGet("{doctorId}")]
    public async Task<IActionResult> Find(string doctorId)
    {
        var doctor = await _doctorServices.Find(doctorId);
        return Ok(doctor);
    }
}
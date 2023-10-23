using DotsAPI.Data;
using DotsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DotController : ControllerBase
{
    readonly IDotRepository _dotRepository;
    
    public DotController(IDotRepository dotRepository)
    {
        _dotRepository = dotRepository;
    }
    
    
    [HttpGet(Name = "GetDots")]
    public async Task<ActionResult<IEnumerable<Dot>>> Get() 
    {
        return Ok(_dotRepository.GetDots());
    }
    
}
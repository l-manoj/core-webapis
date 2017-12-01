using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiswagger.Interfaces;

namespace apiswagger.Controllers
{
    [Route("api/[controller]")]
    public class SwaggerController : Controller{
    private readonly ISwagger _swagger;
    public SwaggerController(ISwagger swagger){
        _swagger=swagger;
    }
    [HttpGet("SGet")]
    public async Task<IActionResult> SGetAsync(int id, CancellationToken cancellationToken) => await _swagger.SGetAsync(id, cancellationToken);

    [HttpPut("SPut")]
    public async Task<IActionResult> SPutAsync(int id, CancellationToken cancellationToken){
        return await _swagger.SPutAsync(id,cancellationToken);
    }

    [HttpPost("SPost")]
    public async Task<IActionResult> SPostAsync(int id, CancellationToken cancellationToken){
        return await _swagger.SPostAsync(id,cancellationToken);
    }
    
    [HttpDelete("SDelete")]
    public async Task<IActionResult> SDeleteAsync(int id, CancellationToken cancellationToken){
        return await _swagger.SDeleteAsync(id,cancellationToken);
    }
}
}

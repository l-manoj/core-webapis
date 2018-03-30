using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiswagger.Interfaces;
using apiswagger.Models;

namespace apiswagger.Facade
{
public class SwaggerFacade : ISwagger
{
    private readonly SwaggerData _swaggerdata;
    public SwaggerFacade (SwaggerData swaggerdata ){
     _swaggerdata=swaggerdata;
    }

    public async Task<IActionResult> SDeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult<IActionResult>(new ObjectResult(_swaggerdata.numbers));
    }

    public async Task<IActionResult> SGetAsync(int id, CancellationToken cancellationToken = default)
    {
         return await Task.FromResult<IActionResult>(new ObjectResult(_swaggerdata.numbers));
    }

    public async Task<IActionResult> SPostAsync(int id, CancellationToken cancellationToken = default)
    {
         return await Task.FromResult<IActionResult>(new ObjectResult(_swaggerdata.numbers));
    }

    public async Task<IActionResult> SPutAsync(int id, CancellationToken cancellationToken = default)
    {
         return await Task.FromResult<IActionResult>(new ObjectResult(_swaggerdata.numbers));
    }
}
}
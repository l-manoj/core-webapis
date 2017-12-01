using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apiswagger.Interfaces
{
public interface ISwagger
{
    Task<IActionResult> SGetAsync(int id,CancellationToken cancellationToken=default);
    Task<IActionResult> SPutAsync(int id,CancellationToken cancellationToken=default);
    Task<IActionResult> SPostAsync(int id,CancellationToken cancellationToken=default);
    Task<IActionResult> SDeleteAsync(int id,CancellationToken cancellationToken=default); 
}
}
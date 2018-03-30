using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiswagger.Interfaces;
using System.Linq;
using Faker;
using Faker.Extensions;
using MailKit;
using MimeKit;
using System;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace apiswagger.Controllers
{
    [Route("api/[controller]")]
    public class SwaggerController : Controller{
    private readonly ISwagger _swagger;
    private const string MAIL_HOST="mail";
    private const int MAIL_PORT=1025;
    public SwaggerController(ISwagger swagger){
        _swagger=swagger;
    }
    #region mailserverPost
    [HttpPost]
    public async Task EmailRandomNums(string[] range, string email="test@fake.com"){
        var message=new MimeMessage();
        message.From.Add(new MailboxAddress("Generator","generator@generator.com"));
        message.To.Add(new MailboxAddress("",email));
        message.Subject="Here are your random numbers!";

        message.Body=new TextPart("plain"){
            Text=string.Join(Environment.NewLine,range)
        };
        using (var mailClient=new SmtpClient())
        {
            await mailClient.ConnectAsync(MAIL_HOST,MAIL_PORT,SecureSocketOptions.None);
            await mailClient.SendAsync(message);
            await mailClient.DisconnectAsync(true);
        }
    }
    #endregion

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

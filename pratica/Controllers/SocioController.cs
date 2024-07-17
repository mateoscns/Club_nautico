using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pratica.Models;
using static pratica.Services.SociosServices.Commands.DeleteSocio;
using static pratica.Services.SociosServices.Commands.PostSocio;
using static pratica.Services.SociosServices.Commands.PutSocio;
using static pratica.Services.SociosServices.Querys.GetAllSocios;
using static pratica.Services.SociosServices.Querys.GetSocioById;

namespace pratica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SocioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Post")]
        public async Task<Socio> SaveSocio([FromBody] PostSocioCommand postSocioCommand)
        {
            return await _mediator.Send(postSocioCommand);
        }

        [HttpGet]
        [Route("Get-By-Id/{id}")]
        public async Task<Socio> GetSocioById(int id)
        {
            return await _mediator.Send(new GetSocioByIdQuery { Id = id});
        }

        [HttpPut]
        [Route("Update")]

        public async Task<Socio> UpdateSocio([FromBody] PutSocioCommand putSocioCommand)
        {
            return await _mediator.Send(putSocioCommand);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<Socio> DeleteSocio(int id)
        {
            return await _mediator.Send(new DeleteSocioCommand { Id = id });
        }

        [HttpGet]
        [Route("Get-All-Socios")]
        public async Task<List<Socio>> GetAllSocios()
        {
            return await _mediator.Send(new GetAllSociosQuery());
        }

    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pratica.Dtos;
using pratica.Services.BarcosServices.Commands;
using pratica.Services.BarcosServices.Querys;
using static pratica.Services.BarcosServices.Commands.PostBarco;
using static pratica.Services.BarcosServices.Querys.GetBarcoById;


namespace pratica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarcosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("barcos")]
        public async Task<IActionResult> PostBarco([FromBody] PostBarco.PostBarcoCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBarcoById), new { id = result.Id }, result);
        }

        [HttpGet]
        [Route("barcos/{id}")]
        public async Task<IActionResult> GetBarcoById(int id)
        {
            var barcoDto = await _mediator.Send(new GetBarcoById.GetBarcoByIdQuery(id));
            return Ok(barcoDto);
        }
    }

}

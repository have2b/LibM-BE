using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RequestsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var requests = await _service.RequestService.GetRequestsAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var request = await _service.RequestService.GetRequestByIdAsync(id);
                return Ok(request);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RequestDto model)
        {
            try
            {
                await _service.RequestService.CreateRequestAsync(model);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, RequestDto model)
        {
            try
            {
                await _service.RequestService.UpdateRequestAsync(id, model);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.RequestService.DeleteRequestAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
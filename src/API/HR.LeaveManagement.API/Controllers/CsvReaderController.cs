using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Csv;
using HR.LeaveManagement.Application.Features.Csv.ReadUsers.Queries;
using HR.LeaveManagement.Application.Features.Csv.Users.Queries;
using HR.LeaveManagement.Application.Models.Csv;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvReaderController : ControllerBase
    {
        private readonly ICsvReader _csvReader;
        private readonly IMediator _mediator;

        public CsvReaderController(ICsvReader csvReader, IMediator mediator)
        {
            _csvReader = csvReader;
            _mediator = mediator;
        }

        // POST: api/CsvReader
        [HttpPost]
        public Task<IActionResult> Post([FromForm] IFormFileCollection file)
        {
            var users = _mediator.Send(new ValidateUserCsvQuery(file[0].OpenReadStream()));

            return Task.FromResult<IActionResult>(Ok(users));
        }
    }
}
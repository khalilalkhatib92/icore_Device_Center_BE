using AutoMapper;
using iCoreAPI.DTOs;
using iCoreAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly ILogger<DealersController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DealersController(ILogger<DealersController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DealerDTO>>> Get()
        {
            logger.LogInformation("Getting All Dealers ...");
            var dealer = await context.Dealers.OrderBy(x => x.Name).ToListAsync();
            return mapper.Map<List<DealerDTO>>(dealer);
        }

        [HttpGet("{id: int}")]
        public async Task<ActionResult<DealerDTO>> Get(int id)
        {
            var dealer = await context.Dealers.FirstOrDefaultAsync(x => x.Id == id);
            if (dealer == null)
            {
                return NotFound();
            }
            return mapper.Map<DealerDTO>(dealer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] DealerCreationDTO dealerCreationDTO)
        {
            var dealer = mapper.Map<Dealer>(dealerCreationDTO);
            context.Dealers.Add(dealer);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DealerCreationDTO dealerCreationDTO)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dealer = await context.Dealers.FirstOrDefaultAsync(x => x.Id == id);
            if(dealer == null)
            {
                return NotFound();
            }
            context.Dealers.Remove(dealer);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

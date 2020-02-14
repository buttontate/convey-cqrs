using System;
using convey_microservice.Commands.Item;
using convey_microservice.Services.Item;
using Microsoft.AspNetCore.Mvc;

namespace convey_microservice.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            return Ok(id);
        }
        
        [HttpPost]
        public IActionResult CreateItem()
        {
            _itemService.CreateItemAsync(new CreateItemCommand(Guid.NewGuid(), "Some Description", "123456789123" ));
            return Ok();
        }
    }
}
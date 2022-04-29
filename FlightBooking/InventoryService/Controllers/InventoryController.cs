using InventoryService.Models;
using InventoryService.Services;
using InventoryService.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public readonly InventoryDbContext _inventory;
        public InventoryController(InventoryDbContext inventory)
        {
            _inventory = inventory;
        }
        [HttpGet]
        [Route("GetAllInventories")]
        public IActionResult GetAllInventories()
        {
            return Ok(_inventory.lstInventories.ToList());
        }
    }
}

using InventoryService.Models;
using InventoryService.Services;
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
        public readonly IInventory _inventory;
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        [HttpGet]
        [Route("GetAllInventories")]
        public IActionResult GetAllInventories()
        {
            return Ok(_inventory.ShowInventories());
        }

        [HttpPost]
        [Route("PlanInventory")]
        public void AddNewInventory(Inventory inventory)
        {
            _inventory.PlanInventory(inventory);
        }
    }
}

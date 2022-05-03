using Airline.Inventory.Models;
using Airline.Inventory.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Airline.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public readonly IInventoryInterface _inventory;
        public InventoryController(IInventoryInterface inventory)
        {
            _inventory = inventory;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllInventories")]
        public IActionResult GetAllInventories()
        {
            return Ok(_inventory.ShowInventories());
        }

        [Authorize]
        [HttpPost]
        [Route("AddNewInventory")]
        public void AddNewInventory(Inventorys inventory)
        {
            _inventory.PlanInventory(inventory);
        }
    }
}

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
        public IActionResult GetAllInventories(DateTime fromDate, DateTime toDate, string fromPlace, string toPlace)
        {            
            return Ok(_inventory.ShowInventories().Where(a => a.StartDate >= fromDate && a.EndDate <= toDate && 
                                                                a.FromPlace.ToLower().Contains(fromPlace.ToLower()) &&
                                                                a.ToPlace.ToLower().Contains(toPlace.ToLower())));
        }

        [HttpPost]
        [Route("GetAllInventoriesWithSearch")]
        public IActionResult GetAllInventoriesWithSearch(DateTime fromDate, DateTime toDate, string fromPlace, string toPlace)
        {
            return GetAllInventories(fromDate, toDate, fromPlace, toPlace);
        }

        [HttpPost]
        [Route("PlanInventory")]
        public void AddNewInventory(Inventory inventory)
        {
            _inventory.PlanInventory(inventory);
        }
    }
}

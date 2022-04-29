using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.DBContext;

namespace InventoryService.Services
{
    public class InventoryImpl : IInventory
    {
        public InventoryDbContext _inventoryDbContext;
        public InventoryImpl(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }
        public void CancelInventory(int id)
        {
            
        }

        public void PlanInventory(Inventory inventory)
        {
            _inventoryDbContext.lstInventories.Add(inventory);
            _inventoryDbContext.SaveChanges();
        }

        public List<Inventory> ShowInventories()
        {
            return _inventoryDbContext.lstInventories.ToList();
        }
    }
}

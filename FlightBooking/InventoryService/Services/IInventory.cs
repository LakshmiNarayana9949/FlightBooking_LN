using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Services
{
    public interface IInventory
    {
        void PlanInventory(Inventory inventory);
        void ShowInventories();
        void CancelInventory(int id);
    }
}

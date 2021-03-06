using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository
    {
        IEnumerable<ItemModel> GetAllOrders();
        void AddItems(ItemModel itemModels);
        Task<bool> SaveChangesAsync();
    }
}

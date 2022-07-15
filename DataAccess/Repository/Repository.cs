using AutoMapper;
using DataAccess.ContextClasses;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository : IRepository
    {
        private readonly IMapper mapper;

        public Repository(ItemContext context, IMapper _mapper)
        {
            Context = context;
            mapper = _mapper;
        }

        public ItemContext Context { get; }

        public IEnumerable<ItemModel> GetAllOrders()
        {
           return mapper.Map<IEnumerable<ItemModel>>(Context.GetOrders());
        }
    }
}

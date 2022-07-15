using AutoMapper;
using DataAccess.Entity;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateProfile : Profile
    {
        public CreateProfile()
        {
            CreateMap<Item, ItemModel>().ReverseMap();
        }
    }
}

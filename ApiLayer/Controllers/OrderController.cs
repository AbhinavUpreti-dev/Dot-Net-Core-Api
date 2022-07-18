using AutoMapper;
using DataAccess.Entity;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public OrderController(IRepository repository, IMapper _mapper)
        {
            this.repository = repository;
            mapper = _mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        [Route("Items",Name ="GetAllItems")]
        public IEnumerable<ItemModel> Get()
        {
            return repository.GetAllOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemModel itemModel)
        {
           var item = mapper.Map<ItemModel>(itemModel);
            repository.AddItems(item);
            if(await repository.SaveChangesAsync())
            {
                var newModel = mapper.Map<ItemModel>(item);
                return CreatedAtRoute("GetAllItems", newModel);
            }
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ItemModel itemModel)
        {
            try
            {
                var currentItem = mapper.Map<Item>(repository.GetAllOrders().Where(i => i.Id == id).FirstOrDefault());
                currentItem.Quantity = itemModel.Quantity;
                currentItem.Name = itemModel.Name;
                if (await repository.SaveChangesAsync())
                {
                    return Ok(itemModel);
                }
            }
            catch (Exception e)
            {

                return BadRequest();
            }
           
            return BadRequest();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

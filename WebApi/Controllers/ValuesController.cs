using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    
    [Route("[controller]")]

    public class ValuesController : Controller
    {
        private static  List<DataModel> InfoList =
           new List<DataModel>
           {
                    new DataModel {  Data = "sdasd" },
                    new DataModel {  Data = "asdasdasdfasd" }
           };
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<DataModel> Get()
        {
            return InfoList;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public DataModel Get(int id)
        {
            return InfoList[id];
        }

        // POST api/<controller>

        
        [HttpPost]
        public ActionResult Post([FromBody]DataModel dataModel)
        {
            
            InfoList.Add(dataModel);
            return this.Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

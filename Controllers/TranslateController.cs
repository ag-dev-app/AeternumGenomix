using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using AeternumGenomix.Models;

namespace AeternumGenomix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {

        public JObject jsonObj { get; set; }
        public JsonFieldsCollector dataColl { get; set; }


        // GET: api/Translate
        [HttpGet]
        public async Task<ActionResult<JToken>> Get(Request data)
        {
            string jsonString = "";

            Translate translator = new Translate();
            Stream stream = new MemoryStream(data.jsonFile.Buffer);
            StreamReader jsonReader = new StreamReader(stream);

            jsonString = await jsonReader.ReadToEndAsync();

            JsonFieldsCollector dataCollector = new JsonFieldsCollector(jsonString);

            foreach (var field in data.fields)
            {

                dataCollector.jsonObject[field] = translator.TranslateText(dataCollector.jsonObject[field].ToString());

            }
            jsonObj = dataCollector.jsonObject;
            dataColl = dataCollector;
            
            return jsonObj;
        }

        // GET api/translate/fields
        [Route("api/[controller]/fields")]
        [HttpGet]
        public ActionResult<List<string>> GetFields()
        {
            return dataColl.GetFieldsKeys();
        }

        // GET: api/Translate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Translate
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Translate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

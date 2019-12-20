using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AzureBuildSample.Contracts;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AzureBuildSampleAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<ClaimType>> Get()
    {
      using (IDbConnection db = new SqlConnection(connectionString))
      {
        return db.Query<ClaimType>("Select * From ClaimType").ToList();
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<List<ClaimType>> Get(int id)
    {
      using (IDbConnection db = new SqlConnection(connectionString))
      {
        return db.Query<ClaimType>($"Select * From ClaimType where Id = {id}").ToList();
      }
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    const string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AzureBuildSampleDB;Integrated Security=True";
  }
}

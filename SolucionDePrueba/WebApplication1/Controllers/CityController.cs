using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly string connetion = @"Server=localhost;Uid=root;Database=world;Port=3306;Pwd=root";
        
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Ciudad> lstciudades;
            using (var db = new MySqlConnection(connetion)) { 

                var sql = "select * from city limit 50";
                lstciudades = db.Query<Models.Ciudad>(sql);
            }

            return Ok(lstciudades);
        }

        [HttpPost]
        public IActionResult Insert(Models.Ciudad model)
        {
            int result=0;
            using (var db = new MySqlConnection(connetion))
            {

                var sql = "insert into city(name, countrycode, district, population) values(@nombre, @codigoPais, @distrito, @poblacion)";
                result = db.Execute(sql, model);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Edit(Models.Ciudad model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connetion))
            {

                var sql = "update city set name=@nombre, countrycode=@codigoPais, district=@distrito, population=@poblacion where id=@id";
                result = db.Execute(sql, model);
            }

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(Models.Ciudad model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connetion))
            {

                var sql = "delete from city where id=@id";
                result = db.Execute(sql, model);
            }

            return Ok(result);
        }

    }
}

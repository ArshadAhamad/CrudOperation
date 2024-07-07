using CrudProject.Db;
using CrudProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
         private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]Student s1)
        {
            _db.Add(s1);
            _db.SaveChanges();
            return Ok(s1);
        }
        [HttpGet] 
        [Route("GetAll")]
        public IActionResult Read()
        {
            List<Student> Students = new List<Student>();
            Students = _db.Students.ToList();
            return Ok(Students);
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult ReadByID(int id)
        {
            Student s1 = _db.Students.FirstOrDefault(x => x.Id == id);
            return Ok(s1);
        }
        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody]Student s1)
        {
            _db.Update(s1);
            _db.SaveChanges();
            return Ok(s1);
        }

        [HttpDelete]
        [Route("Delete")]

        public IActionResult DeleteById(int id)
        {
            Student s1 = _db.Students.FirstOrDefault(x => x.Id == id);
            _db.Remove(s1);
            _db.SaveChanges();
            return Ok(s1);  
        }

    }
}

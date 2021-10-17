using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        public StudentsController()
        {
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentsRepo.Students;
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return StudentsRepo.Students.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void Post(int id, string faculty, string name, int year)
        {
            StudentsRepo.Students.Add(new Student {Id = id, Faculty = faculty, Name = name, Year =year });
        }


        [HttpPut]
        public void Put(int id, int year, string name)
        {

                    StudentsRepo.Students[id-1].Year = year;
                    StudentsRepo.Students[id-1].Name = name;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentsRepo.Students.RemoveAt(id-1);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assigment1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Assigment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private List<Lesson> _lessons = new List<Lesson>()
        {
            new Lesson(){Id=1,Name="Math",Time=new DateTime(2020,09,11),Teacher="Nurlan"  },
            new Lesson(){Id=2,Name="Physics",Time=new DateTime(2020,09,12),Teacher="Miras"  },
            new Lesson(){Id=3,Name="Biology",Time=new DateTime(2020,09,13),Teacher="Askar"  },
            new Lesson(){Id=4,Name="ICT",Time=new DateTime(2020,09,14),Teacher="Olzhas"  }


        };
        [HttpGet("get/all")]
        public List<Lesson> GetAllLessons()
        {
            return _lessons.OrderBy(x=>x.Id).ToList();
        }
        [HttpGet("get/byname/{name}")]
        public List<Lesson> GetAllLessonsByName(string name)
        {
            return _lessons.Where(c => c.Name.Equals(name)).OrderBy(x => x.Id).ToList();
        }
        [HttpGet("get/byteacher/{teacher}")]
        public List<Lesson> GetAllLessonsByTeacher(string teacher)
        {
            return _lessons.Where(c => c.Teacher.Equals(teacher)).OrderBy(x => x.Id).ToList();
        }



        public delegate List<Lesson> Del(int message);
        
        public  List<Lesson> DelegateMethod(int id)
        {
            return _lessons.Where(c => c.Id.Equals(id)).OrderBy(x => x.Id).ToList();
            

        }
        [HttpGet("get/delegate/{message}")]
        public List<Lesson> ShowExample(int message)
        {
             Del handler =  DelegateMethod;
             return handler(message);  

                
        }
        

        
    }
}

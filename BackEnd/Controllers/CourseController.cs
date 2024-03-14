using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEnd.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [EnableCors("reactApp")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService){
            _courseService=courseService;
        }

        [HttpPost("AddCourse")]
        public ActionResult AddCourse([FromForm]IFormCollection data){
            IFormFile file =data.Files["image"];
            if(file !=null && file.Length>0){
                string filename=file.FileName;
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
                string path = Path.Combine(directoryPath,filename);
                using(var stream = new FileStream(path,FileMode.Create)){
                    file.CopyTo(stream);
                }
            }
            string json=data["json"];
            Courses course = JsonConvert.DeserializeObject<Courses>(json);
            course.Image = "http://localhost:5134/Image/"+file.FileName;

            var result = _courseService.AddCourse(course);
            if(result==null){
                return BadRequest("Could not add course");
            }
            return Ok(result);
        }

        [HttpGet("GetCourseByID")]
        public ActionResult GetCourseByID(int id){
            var result = _courseService.GetCourseByID(id);
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("Course not found");
        }
        [HttpGet("GetAllCourse")]
        public ActionResult GetAllCourse(){
            var result = _courseService.GetAllCourses();
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("Courses not found");
        }
        [HttpPut("UpdateCourse")]
        public ActionResult UpdateCourse(Courses course){
            var result = _courseService.UpdateCourse(course);
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("Course not updated");
        }
        [HttpDelete("DeleteCourse")]
        public ActionResult DeleteCourse(int id){
            var result = _courseService.DeleteCourse(id);
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("Course not deleted");
        }
        [HttpGet("GetCourseByUser")]
        public ActionResult GetCourseByUser(string username){
            var result = _courseService.GetCourseByUser(username);
            if(result!=null){
                return Ok(result);
            }
            return BadRequest("No Courses found");
        }
    }
}
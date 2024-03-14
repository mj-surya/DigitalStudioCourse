using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Interfaces;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class CourseService: ICourseService
    {
        private readonly IRespository<int,Courses> _repository;
        public CourseService(IRespository<int,Courses> respository){
            _repository=respository;
        }


        public Courses AddCourse(Courses course)
        {
            var list = _repository.GetAll();
            course.CourseID = list.Count()+1;
            var result = _repository.Add(course);
            if(result!=null){
                return result;
            }
            return null;
        }
        public Courses GetCourseByID(int id)
        {
            var course = _repository.GetById(id);
            if(course!=null){
                return course;
            }
            return null;
        }
        public IList<Courses> GetAllCourses(){
            var courses = _repository.GetAll();
            if(courses==null){
                return null;
            }
            return courses;
        }

        public Courses UpdateCourse(Courses course)
        {
            var result = _repository.Update(course);
            if(result==null){
                return null;
            }
            return result;
        }
        public Courses DeleteCourse(int id)
        {
            var result = _repository.Delete(id);
            if(result==null){
                return null;
            }
            return result;
        }

        public IList<Courses> GetCourseByUser(string username)
        {
            var courses = _repository.GetAll().Where(u=>u.Username==username).ToList();
            if(courses.Count==0){
                return null;
            }
            return courses;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interfaces
{
    public interface ICourseService
    {
        Courses AddCourse(Courses course);
        Courses GetCourseByID(int id);
        Courses UpdateCourse(Courses course);
        Courses DeleteCourse(int id);
        IList<Courses> GetAllCourses();
        IList<Courses> GetCourseByUser(string username);
    }
}
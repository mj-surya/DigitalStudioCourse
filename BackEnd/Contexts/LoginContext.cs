using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Contexts
{
    // public class LoginContext: DbContext
    // {
    //     public LoginContext(DbContextOptions options):base(options){
            
    //     } 
    //     public DbSet<User>? Users{get;set;}
    //     public DbSet<Courses>? Courses{get;set;}

    //     protected override void OnModelCreating(ModelBuilder modelBuilder)
    //     {
    //         modelBuilder.Entity<Courses>().HasData(
    //             new Courses { CourseID=1,Title="Python Basics", Description="Python basics to advanced programming", Institute="Hexavarsity", Duration="6 Hours",Price=399.98f, Image="http://localhost:5134/Image/python.png"},
    //             new Courses { CourseID=2,Title="C# Basics", Description="C# basics to advanced programming", Institute="Hexavarsity", Duration="4 Hours",Price=465.98f, Image="http://localhost:5134/Image/c#.jpeg"},
    //             new Courses { CourseID=3,Title="Java Basics", Description="Java basics to advanced programming", Institute="Hexavarsity", Duration="8 Hours",Price=559.98f, Image="http://localhost:5134/Image/java.png"}
    //         );
    //     }
    // }

    //test
    public class LoginContext
    {
        public List<Courses> Courses { get; private set; }
        public List<User> Users { get; private set; }

        public LoginContext()
        {
            Users =new List<User>{
                new User{UserName="Jayasurya", Password="12345", Role="Instructor"},
                new User{UserName="Surya", Password="11111",Role="User"}
            };


            Courses = new List<Courses>
            {
                new Courses { CourseID = 1,Username="Jayasurya", Title = "Python Basics", Description = "Python basics to advanced programming", Institute = "Hexavarsity", Duration = "6 Hours", Price = 399.98f, Image = "http://localhost:5134/Image/python.png" },
                new Courses { CourseID = 2, Username="Jayasurya", Title = "C# Basics", Description = "C# basics to advanced programming", Institute = "Hexavarsity", Duration = "4 Hours", Price = 465.98f, Image = "http://localhost:5134/Image/csharp.jpeg" },
                new Courses { CourseID = 3, Username="Jayasurya", Title = "Java Basics", Description = "Java basics to advanced programming", Institute = "Hexavarsity", Duration = "8 Hours", Price = 559.98f, Image = "http://localhost:5134/Image/java.png" },
                new Courses { CourseID = 4, Username="Jayasurya", Title = "HTML & CSS", Description = "HTML & CSS: Single page application", Institute = "Hexavarsity", Duration = "2 Hours", Price = 199.98f, Image = "http://localhost:5134/Image/html.jpeg" },
            };
        }
        public Courses Add(Courses course){
            Courses.Add(course);
            return course;
        }
        public Courses Delete(Courses course){
            Courses.Remove(course);
            return course;
        }
        public Courses Update(Courses course){
            Courses[course.CourseID-1]=course;
            return course;
        }
        public User AddUser(User user){
            Users.Add(user);
            return user;
        }
    }
}
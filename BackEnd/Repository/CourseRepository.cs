using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Interfaces;
using BackEnd.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class CourseRepository : IRespository<int, Courses>
    {
        private readonly LoginContext _context;
        public CourseRepository(LoginContext context){
            _context =context;
        }
        public Courses Add(Courses entity)
        {
            _context.Add(entity);
            //_context.SaveChanges();
            return entity;
        }

        public Courses Delete(int key)
        {
            var course = GetById(key);
            if(course!=null){
                _context.Courses.Remove(course);
                //_context.SaveChanges();
                return course;
            }
            return null;
        }

        public IList<Courses> GetAll()
        {
            if(_context.Courses.Count==0){
                return null;
            }
            return _context.Courses.ToList();
            throw new NotImplementedException();
        }

        public Courses GetById(int key)
        {
            var course = _context.Courses.SingleOrDefault(u => u.CourseID == key);
            return course!;
        }

        public Courses Update(Courses entity)
        {
            // var course = GetById(entity.CourseID);
            // if(course!=null){
                // _context.Entry<Courses>(entity).State = EntityState.Modified;
                // _context.SaveChanges();
                var result=_context.Update(entity);
                return result;
            // }
            //return null;
        }
    }
}
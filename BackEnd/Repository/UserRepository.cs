using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Contexts;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class UserRepository: IRespository<string, User>
    {
        private readonly LoginContext _context;
        public UserRepository(LoginContext context){
            _context =context;
        }
        public User Add(User user){
            _context.AddUser(user);
            // _context.SaveChanges();
            return user;
        }
        public User Update(User user){
            var entity = GetById(user.UserName);
            if(entity!=null){
                // _context.Entry<User>(entity).State = EntityState.Modified;
                // _context.SaveChanges();
                return entity;
            }
            return null;
        }
        public User Delete(String username){
            var user = GetById(username);
            if(user!=null){
                // _context.Users.Remove(user);
                // _context.SaveChanges();
                return user;
            }
            return null;
        }
        // public IList<User> GetAll(){
        //     // if(_context.Users.Count()==0){
        //     //     return null;
        //     // }
        //     // return _context.Users.ToList();
        // }

        public User GetById(string key)
        {
            var user = _context.Users.SingleOrDefault(u=>u.UserName==key);
            if(user!=null){
                return user;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
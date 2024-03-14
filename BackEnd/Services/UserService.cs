using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Interfaces;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class UserService: IUserService
    {
        private readonly IRespository<string,User> _repository;
        public UserService(IRespository<string,User> respository){
            _repository=respository;
        }

        public User Login(User entity){
            var user= _repository.GetById(entity.UserName);
            if(user!=null){
                if(entity.Password==user.Password && entity.UserName==user.UserName){
                    return user;
                }
                return null;
            }
            return null;
        }

        public User Register(User user)
        {
            var result = _repository.Add(user);
            if(result==null){
                return null;
            }
            return user;
        }
    }
}
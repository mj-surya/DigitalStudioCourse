using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interfaces
{
    public interface IUserService
    {
        User Login(User user);
        User Register(User user);
         
    }
}
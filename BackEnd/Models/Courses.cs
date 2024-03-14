using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Courses
    {
        [Key]
        public int CourseID{get;set;}
        public string Username{get;set;}="";
        public string Title{get;set;}="";
        public string Description{get;set;}="";
        public string Institute{get;set;}="";
        public float Price{get;set;}
        public string Duration{get;set;}="";
        public string Image{get;set;}="";
    }
}
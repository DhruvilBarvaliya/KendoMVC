using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class t_Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_empId { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public  string c_empName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Your email is not valid.")]
        public  string c_empEmail { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(8, ErrorMessage = "Password at least 8 chareter long.")]
        public  string c_empPwd { get; set; }

        [Required(ErrorMessage = "Confirem password is required")]
        [Compare("c_empPwd", ErrorMessage = "Confirm password is not match")]
        public  string c_empConfPwd { get; set; }
        [Required(ErrorMessage = "Please select any State")]
        public  string c_empState { get; set; }
        [Required(ErrorMessage = "Plect select any city")]
        public  string c_empCity { get; set; }
        public string? c_empProfile { get; set; }
        public IFormFile? c_empformFile { get; set; }
    }
}



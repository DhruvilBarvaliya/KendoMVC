using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class t_Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_adminId { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public required string c_adminName { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Your email is not valid.")]
        public required string c_adminEmail { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [MinLength(8,ErrorMessage = "Password at least 8 charater long.")]
        public required string c_adminPwd { get; set; }

        [Required(ErrorMessage = "Please enter confirm password.")]
        [Compare("c_adminPwd",ErrorMessage = "Confirm password is not match.")]
        public required string c_adminConfPwd { get; set; }

        public string? c_adminProfile { get; set; }

        public IFormFile? c_adminformFile { get; set; }

        public t_Employee? c_employees { get; set; }
    }
}
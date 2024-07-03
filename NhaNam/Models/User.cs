//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NhaNam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Required(ErrorMessage = "Vui long nhap ten Admin User.")]
        [StringLength(20, ErrorMessage = "Ten Admin User khong duoc vuot qua 20 ki tu.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui long nhap mat khau.")]
        [MinLength(6, ErrorMessage = "Mat khau phai co it nhat 6 ky tu.")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

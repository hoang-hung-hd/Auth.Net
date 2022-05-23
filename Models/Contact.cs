using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Contact 
    {
        [Key]
        public int Id {set;get;}

        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Phải nhập họ tên")]
        [Display(Name ="Họ Tên")]
        public string FullName {set;get;}

        [Required(ErrorMessage ="Phải nhập {0}")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Phải là Email")]
        [Display(Name ="Địa chỉ Email")]
        public string Email {set;get;}
        
        public DateTime DateSent {set;get;}

        [Display(Name ="Nội dung")]
        public string Message {set;get;}

        [Display(Name ="Số điện thoại")]
        [Required(ErrorMessage ="Phải nhập số điện thoại")]
        [StringLength(50)]
        public string Phone {set;get;}
    }
}
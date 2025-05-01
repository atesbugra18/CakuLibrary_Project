using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using KutuphaneMvc1.Utils;
namespace KutuphaneMvc1.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Doğrulama kodu gereklidir.")]
        [StringLength(6, ErrorMessage = "Doğrulama kodu 6 haneli olmalıdır.")]
        public string VerificationCode { get; set; }
        [Required(ErrorMessage = "Yeni şifre gereklidir.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Şifre tekrarı gereklidir.")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
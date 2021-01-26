using AspNetCoreIdentity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AspNetCoreIdentity.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [EmailAddress]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }

    public class PasswordChangeViewModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır")]
        [Display(Name = "Mevcut Şifre")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır")]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Compare("NewPassword", ErrorMessage = "Girilen şifreler uyuşmuyor")]
        public string NewPasswordConfirm { get; set; }
    }

    public class UserViewModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [EmailAddress]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }
        //**********
        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Telefon")]
        public string PhoneNumber
        {
            get
            {
                if (_phoneNumber != null)
                {
                    return _phoneNumber;
                }
                else
                {
                    return "Kayıtlı numara bulunamadı";
                }
            }
            set { _phoneNumber = value; }
        }

        private string _phoneNumber;
        //******************
        public string City { get; set; }
        public string Picture { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

        public List<Claim> claims { get; set; }


    }

    public class LogInViewModel
    {

        [Required(ErrorMessage = "Zorunlu Alan")]
        [EmailAddress(ErrorMessage = "Geçerli bir eposta adresi giriniz!")]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        [MinLength(4, ErrorMessage = "Şifre uzunluğu en az 4 karakter olmalıdır.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }

    public class ResetPasswordViewModel
    {

        [Required(ErrorMessage = "Zorunlu Alan")]
        [EmailAddress(ErrorMessage = "Geçerli bir eposta adresi giriniz!")]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }


    }


    public class ResetPasswordConfirmViewModel
    {

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        [MinLength(4, ErrorMessage = "Şifre uzunluğu en az 4 karakter olmalıdır.")]
        public string PasswordNew { get; set; }
    }

}

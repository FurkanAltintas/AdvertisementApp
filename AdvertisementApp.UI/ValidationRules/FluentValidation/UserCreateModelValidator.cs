using AdvertisementApp.UI.Models;
using FluentValidation;
using System;

namespace AdvertisementApp.UI.ValidationRules.FluentValidation
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        // [Obsolete]
        public UserCreateModelValidator()
        {
            // CascadeMode = CascadeMode.StopOnFirstFailure; // ilk hatada durdur

            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(a => a.Password).MinimumLength(3).WithMessage("Parola min 3 karakter olmalıdır");
            RuleFor(a => a.Password).Equal(a => a.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(a => a.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur");
            RuleFor(a => a.Firstname).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(a => a.UserName).MinimumLength(3).WithMessage("Kullanıcı min 3 karakter olmalıdır");
            RuleFor(a => new
            {
                a.UserName,
                a.Firstname
            }).Must(a => CanNotFirstName(a.UserName, a.Firstname)).WithMessage("Kullanıcı adı, ad ile aynı olamaz!").When(a => a.UserName != null && a.Firstname != null);
        }

        private bool CanNotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}

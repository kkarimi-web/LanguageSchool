using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CleanArch.Domain.Models;
using FluentValidation;

namespace CleanArch.Application.Validations
{
    public  class PersonValidation:AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("فیلد نام اجباری می باشد.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("نام خانوادگی اجباری می باشد");
            RuleFor(x => x.FatherName).NotEmpty().WithMessage("نام پدر اجباری می باشد");
            RuleFor(x => x.NationalCode).NotEmpty().WithMessage("کدملی اجباری می باشد");
            RuleFor(x => x.Email).EmailAddress();

        }
    }
}

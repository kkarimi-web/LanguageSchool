using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
     public interface IPersonService
    {
        void Add(Person person);
        void Update(Person person);
        void Delete(int personId);
        IEnumerable<Person> GetAll();
        Person GetPersonByNationalCode(string code);
    }
}

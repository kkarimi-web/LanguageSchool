using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
   public  interface IPersonRepository:IRepository<Person>
    {
        Person GetPersonByNationalCode(string code);
        
    }
}

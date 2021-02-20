using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class PersonRepository :Repository<Person>, IPersonRepository
    {
       
        public PersonRepository(LanguageSchoolDbContext context):base(context)
        {

        }
        public Person GetPersonByNationalCode(string code)
        {
            return _context.Person.Where(c => c.NationalCode == code).FirstOrDefault();
        }

      
    }
}

using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Person person)
        {
            _unitOfWork.personRepository.Add(person);
            _unitOfWork.Commit();
        }

        public void Delete(int  personId)
        {
            _unitOfWork.personRepository.Delete(personId);
            _unitOfWork.Commit();
        }

        public IEnumerable<Person> GetAll()
        {
          return   _unitOfWork.personRepository.GetAll();
        }

        public Person GetPersonByNationalCode(string code)
        {
            return _unitOfWork.personRepository.GetPersonByNationalCode(code);
        }
       
        public void Update(Person person)
        {
            _unitOfWork.personRepository.Update(person);
            _unitOfWork.Commit();
        }
    }
}

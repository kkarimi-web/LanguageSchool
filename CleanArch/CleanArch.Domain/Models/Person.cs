using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Models
{
   public class Person
    {
        public int Id{ get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public bool? MaritalStatus { get; set; }
    }
}

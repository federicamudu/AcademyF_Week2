﻿namespace AcademyF.Week2.EsercitazioneDesignPattern.Entities
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        public int ProductivityRate { get; set; }
        public int AbsenceRate { get; set; }
        public DateTime AssumptionDate { get; set; }
        public int AgeOfService { get { return DateTime.Now.Year - AssumptionDate.Year; } }

        public virtual string ViewBenefit()
        {
            return "";
        }
    }
}
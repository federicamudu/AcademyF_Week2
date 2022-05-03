using AcademyF.Week2.EsercitazioneDesignPattern.Decorator;
using AcademyF.Week2.EsercitazioneDesignPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Test
{
    public class DecoratorTest
    {
        [Fact]
        public void ShouldHaveEmployeeWithoutBenefits()
        {
            //per impiegati semplici mi aspetto che non abbia benefit

            //ARRANGE
            Employee employee = new Employee()
            {
                FirstName = "Mario",
                LastName = "Rossi"
            };
            //ACT
            string benefit = employee.ViewBenefit();

            //ASSERT
            //mi aspetto che la stringa contenente i benefit sia vuota
            Assert.Equal("", benefit);
        }



        [Fact]
        public void ShouldHaveCarParkingNotNullForEmployee()
        {
            //per impiegati caratterizzati dal benefit posto auto voglio che il codice del posto auto sia 
            //non nullo o diverso da stringa vuota

            //ARRANGE
            Employee employee = new Employee()
            {
                FirstName = "Mario",
                LastName = "Rossi"
            };
            //creo componente in grado di arricchire l'impiegato con il benefit posto auto
            employee = new EmployeeParkingCar(employee, "P3456");
            //ACT
            string benefit = employee.ViewBenefit();
            //ASSERT
            Assert.True(!string.IsNullOrEmpty(benefit));
        }
        [Fact]
        public void ShouldHaveHealtyPolicyNullForEmployee()
        {
            //per impiegati caratterizzati dal benefit assistenza sanitaria sia 
            //non nullo o diverso da stringa vuota

            //ARRANGE
            Employee employee = new Employee()
            {
                FirstName = "Mario",
                LastName = "Rossi"
            };
            //creo componente in grado di arricchire l'impiegato con il benefit assistenza sanitaria
            employee = new EmployeeHealthyPolicy(employee, "H3456");
            //ACT
            string benefit = employee.ViewBenefit();
            //ASSERT
            Assert.True(!string.IsNullOrEmpty(benefit));
        }
        [Fact]
        public void ShouldHaveBothHealtyPolicyAndParkingCar()
        {
            //per impiegati caratterizzati dal benefit assistenza sanitaria e con posto auto sia 
            //non nullo o diverso da stringa vuota i codici

            //ARRANGE
            //creo come dipendente di partenza un dipendente che abbia il posto auto assegnato
            Employee employee = new Employee()
            {
                FirstName = "Mario",
                LastName = "Rossi"
            };
            var employeeParkingCar = new EmployeeParkingCar(employee, "P0987");
            //creo componente in grado di arricchire l'impiegato con il benefit posto auto
            employee = new EmployeeHealthyPolicy(employeeParkingCar, "H3456");
            //ACT
            string benefit = employee.ViewBenefit();
            //ASSERT
            Assert.True(!string.IsNullOrEmpty(benefit));
            Assert.Contains("P0987", benefit);
        }

    }
}

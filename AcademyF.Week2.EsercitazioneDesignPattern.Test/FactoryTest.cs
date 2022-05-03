using AcademyF.Week2.EsercitazioneDesignPattern.Entities;
using AcademyF.Week2.EsercitazioneDesignPattern.Factory;
using Xunit;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Test
{
    public class FactoryTest
    {
        [Fact]
        public void ShouldCreateNullCompanyWithNegativeEmployees()
        {
            int numeroDipendenti = -4; //Dichiaro variabile con numero dipendenti
            FactoryCompany factoryCompany = new FactoryCompany(); //creo il componente che sarà in grado di creare la mia company

            //ACT
            //Richiamo metodo creazione dell'azienda
            ICompany company = factoryCompany.CreateCompany(numeroDipendenti);

            //ASSERT
            Assert.Null(company);
        }
        [Fact]
        public void ShouldCreateSmallCompanyWith10Employees()
        {
            //Mi aspetto che la creazione di un'azienda di piccole dimensioni nel caso in cui il numero di dipendenti sia pari a 10
            //ARRANGE

            int numeroDipendenti = 10; //Dichiaro variabile con numero dipendenti
            FactoryCompany factoryCompany = new FactoryCompany(); //creo il componente che sarà in grado di creare la mia company

            //ACT
            //Richiamo metodo creazione dell'azienda
            ICompany smallCompany = factoryCompany.CreateCompany(numeroDipendenti);

            //ASSERT
            Assert.Equal("SmallCompany", smallCompany.GetType().Name);
        }
        [Fact]
        public void ShouldCreateMediumCompanyWithFiftyEmployees()
        {
            //ARRANGE

            int numeroDipendenti = 50; //Dichiaro variabile con numero dipendenti
            FactoryCompany factoryCompany = new FactoryCompany(); //creo il componente che sarà in grado di creare la mia company

            //ACT
            //Richiamo metodo creazione dell'azienda
            ICompany mediumCompany = factoryCompany.CreateCompany(numeroDipendenti);

            //ASSERT
            Assert.Equal("MediumCompany", mediumCompany.GetType().Name);
        }
        [Fact]
        public void ShouldCreateBigCompanyWith500Employees()
        {
            int numeroDipendenti = 500;
            FactoryCompany factoryCompany = new FactoryCompany();
            ICompany bigCompany = factoryCompany.CreateCompany(numeroDipendenti);
            Assert.Equal("BigCompany", bigCompany.GetType().Name);
        }
        [Fact]
        public void ShouldCreateMultinationalCompanyWithMoreThan500Employees()
        {
            int numeroDipendenti = 700;
            FactoryCompany factoryCompany = new FactoryCompany();
            ICompany multinationalCompany = factoryCompany.CreateCompany(numeroDipendenti);
            Assert.Equal("MultinationalCompany", multinationalCompany.GetType().Name);
        }
    }
}
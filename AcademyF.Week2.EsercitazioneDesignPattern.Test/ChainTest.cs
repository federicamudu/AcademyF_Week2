﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyF.Week2.EsercitazioneDesignPattern.Chain;
using AcademyF.Week2.EsercitazioneDesignPattern.Entities;
using AcademyF.Week2.EsercitazioneDesignPattern.Factory;
using Xunit;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Test
{
    public class ChainTest
    {
        [Fact]
        public void ShouldHaveProductivityValueForEmployeeWithAge20AndProductivity50()
        {
            //Come utente mi aspetto che un impiegato di età 20 anni e tasso di produttività
            //pari a 50 abbia un premio produttività  di 300 euro dato un gestore del premio 
            //produttività con valore Y pari a 25 e tasso di produttività W superiore a 40

            //ARRANGE
            //Creo il dipendente con le caratteristiche che mi aspetto dal test
            Employee employee = new Employee()
            {
                DateOfBirth = new DateTime(2002, 1, 1),
                ProductivityRate = 50
            };

            //Creo il gestore della richiesta sfruttando i parametri Y e W
            int Y = 25;
            int W = 40;

            IHandler productivityHandler = new ProductivityHandler(Y, W);

            //ACT 

            //Chiamata al metodo che gestisce la richiesta per l'impiegato creato
            double premio = productivityHandler.HandleRequest(employee);

            //ASSERT

            //Verifico che il premio sia uguale a 300
            Assert.Equal(300, premio);
        }

        [Fact]
        public void ShouldHavePresenceValueForEmployeeWithAge25AndAbsenceRate30()
        {
            //Come utente mi aspetto che un impiegato tasso di età 25
            // e tasso di assenza pari a 30
            //abbia un premio produttività  di 180 euro dato un gestore del premio 
            //presenza con valore Y pari a 35 e tasso di produttività Z minore di 40

            //ARRANGE
            //Creo il dipendente con le caratteristiche che mi aspetto dal test
            Employee employee = new Employee()
            {
                DateOfBirth = new DateTime(1997, 1, 1),
                ProductivityRate = 50,
                AbsenceRate = 30
            };

            //Creo il gestore della richiesta sfruttando i parametri Y e Z
            int Y = 26;
            int Z = 40;

            IHandler absenceHandler = new AbsenceHandler(Y, Z);

            //ACT 

            //Chiamata al metodo che gestisce la richiesta per l'impiegato creato
            double premio = absenceHandler.HandleRequest(employee);

            //ASSERT

            //Verifico che il premio sia uguale a 300
            Assert.Equal(180, premio);
        }

        [Fact]
        public void ShouldHaveProductivityBonusForEmployeeWithProductivityAndAbsenceBoth()
        {
            //Come utente mi aspetto che l'impiegato che ha i requisiti per vincere contemporaneamente
            //i bonus di presenza e produttività vinca solamente il primo che incontra (ovvero
            //quello di produttività)

            //ARRANGE
            //Creo il dipendente con le caratteristiche che mi aspetto dal test
            Employee employee = new Employee()
            {
                DateOfBirth = new DateTime(1997, 1, 1),
                ProductivityRate = 50,
                AbsenceRate = 30
            };

            //Creo i gestori della richiesta sfruttando i parametri Y, W e Z
            int Y = 26;
            int W = 40;
            int Z = 40;

            //Genero la catena di responsabilità
            IHandler absenceHandler = new AbsenceHandler(Y, Z);
            IHandler productiviryHandler = new ProductivityHandler(Y, W);

            productiviryHandler.SetNext(absenceHandler);

            //ACT 

            //Chiamata al metodo che gestisce la richiesta per l'impiegato creato
            double premio = productiviryHandler.HandleRequest(employee);

            //ASSERT

            //Verifico che il premio sia uguale a 300
            Assert.Equal(300, premio);
        }

        [Fact]
        public void ShouldHaveAbsenceBonusForEmployeeWithProductivityAndAbsenceBoth()
        {
            //Come utente mi aspetto che l'impiegato che ha i requisiti per vincere contemporaneamente
            //i bonus di presenza e produttività vinca solamente il primo che incontra (ovvero
            //quello di produttività)

            //ARRANGE
            //Creo il dipendente con le caratteristiche che mi aspetto dal test
            Employee employee = new Employee()
            {
                DateOfBirth = new DateTime(1997, 1, 1),
                ProductivityRate = 50,
                AbsenceRate = 30
            };

            //Creo i gestori della richiesta sfruttando i parametri Y, W e Z
            int Y = 26;
            int W = 70;
            int Z = 40;

            //Genero la catena di responsabilità
            IHandler absenceHandler = new AbsenceHandler(Y, Z);
            IHandler productiviryHandler = new ProductivityHandler(Y, W);

            absenceHandler.SetNext(productiviryHandler);

            //ACT 

            //Chiamata al metodo che gestisce la richiesta per l'impiegato creato
            double premio = absenceHandler.HandleRequest(employee);

            //ASSERT

            //Verifico che il premio sia uguale a 300
            Assert.Equal(180, premio);
        }

        [Fact]
        public void ShouldHaveProductivityBonusInChainWithTwoHandler()
        {
            //Ho un impiegato vincitore del premio produttività in una catena
            //costituita dall'anello premio assenza e successivamente quello di produttività
            //voglio che la richiesta passi attraverso i due anelli della catena

            //ARRANGE
            //Creo il dipendente con le caratteristiche che mi aspetto dal test
            Employee employee = new Employee()
            {
                DateOfBirth = new DateTime(1997, 1, 1),
                ProductivityRate = 80,
                AbsenceRate = 70
            };

            //Creo i gestori della richiesta sfruttando i parametri Y, W e Z
            int Y = 26;
            int W = 70;
            int Z = 40;

            //Genero la catena di responsabilità
            IHandler absenceHandler = new AbsenceHandler(Y, Z);
            IHandler productiviryHandler = new ProductivityHandler(Y, W);

            absenceHandler.SetNext(productiviryHandler);

            //ACT 

            //Chiamata al metodo che gestisce la richiesta per l'impiegato creato
            double premio = absenceHandler.HandleRequest(employee);

            //ASSERT

            //Verifico che il premio sia uguale a 300
            Assert.Equal(300, premio);
        }
        [Fact]
        public void ShouldHaveAgeOfServiceBonus()
        {
            Employee employee = new Employee()
            {
                AssumptionDate = new DateTime(1975, 1, 1)
            };
            int Y = 43;
            IHandler ageOfServiceHandler = new AgeOfServiceHandler(Y);
            double premio = ageOfServiceHandler.HandleRequest(employee);
            Assert.Equal(500, premio);
        }
        [Fact]
        public void ShouldHaveCollectingWellBeing()
        {
            Employee employee = new Employee()
            {
                ProductivityRate = 90
            };
            int W = 80;
            IHandler productiviryHandler = new ProductivityHandler(W);
            double premio = productiviryHandler.HandleRequest(employee);
            Assert.Equal(800, premio);
        }
    }
}

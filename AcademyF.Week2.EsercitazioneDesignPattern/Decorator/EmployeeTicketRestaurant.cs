using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Decorator
{
    public class EmployeeTicketRestaurant : EmployeeDecorator

    {
        public string NumeroTessera { get; set; }
        public int NumeroTicket { get; set; }
        public EmployeeTicketRestaurant(Employee employee, string numeroTessera, int numeroTicket) : base(employee)
        {
            NumeroTessera = numeroTessera;
            NumeroTicket = numeroTicket;
        }
        public override string ViewBenefit()
        {
            return StartedEmployee.ViewBenefit() + $"{NumeroTessera} - {NumeroTicket}";
        }
    }
}
using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Decorator
{
    public class EmployeeCompanyCar : EmployeeDecorator
    {
        public string NumeroTarga { get; set; }
        public string ModelloAuto { get; set; }

        public EmployeeCompanyCar(Employee employee, string numeroTarga, string modelloAuto) : base(employee)
        {
            NumeroTarga = numeroTarga;
            ModelloAuto = modelloAuto;
        }
        public override string ViewBenefit()
        {
            return StartedEmployee.ViewBenefit() + $"{NumeroTarga} - {ModelloAuto}";
        }
    }
}
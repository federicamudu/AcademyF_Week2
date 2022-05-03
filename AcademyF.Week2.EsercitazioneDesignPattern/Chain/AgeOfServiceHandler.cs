using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Chain
{
    public class AgeOfServiceHandler : AbstractHandler
    {
        public int Y { get; }
        public AgeOfServiceHandler(int y)
        {
            Y = y;
        }
        public override double HandleRequest(Employee employee)
        {
            if (employee.AgeOfService > Y)
            {
                return 500;
            }
            else
            {
                return base.HandleRequest(employee);
            }
        }
    }
}
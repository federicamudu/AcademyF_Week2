using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Chain
{
    public class ProductivityHandler : AbstractHandler
    {
        public int Y { get; }
        public int W { get; }

        public ProductivityHandler(int w)
        {
            W = w;
        }

        public ProductivityHandler(int y, int w)
        {
            this.Y = y;
            this.W = w;
        }

        public override double HandleRequest(Employee employee)
        {
            if(employee.Age < Y && employee.ProductivityRate > W)
            {
                return 300;
            }
            else if(employee.ProductivityRate >= W)
            {
                return 800;
            }
            else
            {
                return base.HandleRequest(employee);
            }
            
        }

    }
}
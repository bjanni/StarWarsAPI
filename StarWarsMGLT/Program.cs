using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsMGLT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isNumber = false;
            while (!isNumber)
            {
                Console.Write("\n Enter the value for distance in MGLT: ");
                var distance = Console.ReadLine();

                isNumber = double.TryParse(distance, out var numberResult);
                if (isNumber == false)
                {
                    Console.Write("\n Please enter Numbers only......");
                }
                else
                {
                    var starShips = new StarShips();
                    starShips.ProcessReSupply(numberResult);
                    Console.ReadLine();
                }
            }
        }
    }
}

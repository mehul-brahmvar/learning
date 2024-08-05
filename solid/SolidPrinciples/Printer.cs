using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public interface IPrinter
    {
        public void Print(IShape shape);
    }
    public class Printer : IPrinter
    {
        public void Print(IShape shape)
        {
            Console.WriteLine(shape);
        }
    }
}

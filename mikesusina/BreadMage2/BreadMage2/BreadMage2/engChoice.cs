using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Controls;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engChoice
    {


        public void TestMethod()
        {
            Console.WriteLine("I guess this worked");
        }

        public string TestString()
        {
            return "gah";
        }

        public int TestMath(int x, int y)
        {
            return x + y;
        }

        public void TestVar(int x)
        {
            x += 9;
        }
    }
}

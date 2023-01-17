using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Dice
    {
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public Dice(int num)
        {
            this.num = num;
        }
    }
}

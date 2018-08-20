using System;
using System.Collections.Generic;
using System.Text;

namespace LogAn
{
    public class MemCalculator
    {
        private int sum = 0;
        public void Add(int number)
        {
            sum += number;
        }
        public int Sum()
        {
            int temp = sum;
            sum = 0;
            return temp;
        }
    }
}

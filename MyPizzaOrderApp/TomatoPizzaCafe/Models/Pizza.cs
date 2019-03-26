using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomatoPizzaCafe.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Type { get; set; }
        public int Description { get; set; }
        public double EightInchPrice { get; private set; }
        public double TenInchPrice { get; private set; }
        public double TwelveInchPrice { get; private set; }
        public double FourteenInchPrice { get; private set; }
        public double EighteenInchPrice { get; private set; }
    }
}

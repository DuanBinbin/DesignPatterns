using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildPattern
{
    class Product
    {
        private List<string> _part = new List<string>();

        public void AddPart(string part)
        {
            _part.Add(part);
        }

        public void ShowProduct()
        {
            foreach (string part in _part)
            {
                Console.WriteLine();
            }
        }
    }
}

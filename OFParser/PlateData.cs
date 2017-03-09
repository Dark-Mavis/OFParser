using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class PlateData
    {
        public List<Plate> Plates;
        public PlateData()
        {
            Plates = new List<Plate>();
        }
        public void AddPlate(string data)
        {
            int pointer = 21;
            while(data[pointer]!=' ')
            {
                pointer++;
            }
            //ask matt about method
            Plates.Add(new Plate(Convert.ToInt32(data.Substring(10, 2)), Convert.ToInt32(data.Substring(16, 2)), data.Substring(21, pointer - 21), data.Substring(43, 1), data.Substring(47, 7), Convert.ToDouble(data.Substring(58, 4)),Convert.ToDouble(data.Substring(64))));
        }
    }
    class Plate
    {
        public int Node { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Application { get; set; }
        //what is cq and jsi? can it be geometrized?
        public double Cq { get; set; }
        public double JSI { get; set; }
        public Plate(int Node, int Type, string Name,string Method,string Application,double Cq,double JSI)
        {
            this.Node = Node;
            this.Type = Type;
            this.Name = Name;
            this.Method = Method;
            this.Application = Application;
            this.Cq = Cq;
            this.JSI = JSI;
        }
    }
}

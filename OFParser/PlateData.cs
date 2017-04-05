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
            //Plate # is in the data, but like Joint Data the reference number in Plates(the list) is the same
            int pointer = 21;
            while(data[pointer]!=' ')
            {
                pointer++;
            }
            int nodeNumber = Convert.ToInt32(data.Substring(10, 2));
            int type = Convert.ToInt32(data.Substring(16, 2));
            string name = data.Substring(21, pointer - 21);
            //method in all examples has either an N or nothing
            string method = data.Substring(43, 1);
            //application in all my examples says "On Face"
            string application = data.Substring(47, 7);
            double cq = Convert.ToDouble(data.Substring(58, 4));
            double jsi = Convert.ToDouble(data.Substring(64));
            Plates.Add(new Plate(nodeNumber,type,name,method,application,cq,jsi));
        }
    }
    class Plate
    {
        public int Node { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Application { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class JointData
    {
        public List<Node> Nodes;
        public JointData()
        {
            Nodes = new List<Node>();
        }
        public void AddNode(string data)
        {
            int pointer = 0;
            while(data[0]==' ')
            {
                data = data.Substring(1);
            }
            data = data.Substring(3);
            while (data[0] == ' ')
            {
                data = data.Substring(1);
            }
            while (data[pointer]!=' ')
            {
                pointer++;
            }
            double XCoord = Convert.ToDouble(data.Substring(0, pointer));
            data = data.Substring(pointer);
            pointer = 0;
            while (data[pointer] == ' ')
            {
                data = data.Substring(1);
            }
            while (data[pointer] != ' ')
            {
                pointer++;
            }
            double YCoord = Convert.ToDouble(data.Substring(0, pointer));
            data = data.Substring(pointer);
            pointer = 0;
            while (data[pointer] == ' ')
            {
                data = data.Substring(1);
            }
            int Description = Convert.ToInt32(data);
            data = data.Substring(pointer);
            Nodes.Add(new Node(XCoord, YCoord, Description));
        }
    }
    class Node
    {
        public double XCoord { get; set; }
        public double YCoord { get; set; }
        public int Description { get; set; }
        public Node(double XCoord, double YCoord, int Description)
        {
            this.XCoord = XCoord;
            this.YCoord = YCoord;
            this.Description = Description;
        }
    }
}

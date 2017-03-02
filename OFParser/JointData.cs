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
            data.Trim();
            int pointer = 0;
            int location = Convert.ToInt32(data[0]);
            data = data.Substring(1);
            while(data[pointer]==' ')
            {
                data = data.Substring(1);
            }
            while(data[pointer]!=' ')
            {
                pointer++;
            }
            double XCoord = Convert.ToDouble(data.Substring(0, pointer));
            data = data.Substring(pointer);
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
            while (data[pointer] == ' ')
            {
                data = data.Substring(1);
            }
            while (data[pointer] != ' ')
            {
                pointer++;
            }
            int Description = Convert.ToInt32(data.Substring(0, pointer));
            data = data.Substring(pointer);
            Nodes[location] = new Node(XCoord, YCoord, Description);
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

using GeometryClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;

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
            //this hops over the Node #, which doesn't matter as it is the same as the number reference in the Nodes List
            data = data.Substring(10);
            data=data.TrimStart();
            while (data[pointer]!=' ')
            {
                pointer++;
            }
            double XCoord = Convert.ToDouble(data.Substring(0, pointer));
            data = data.Substring(pointer);
            pointer = 0;
            data=data.TrimStart();
            while (data[pointer] != ' ')
            {
                pointer++;
            }
            double YCoord = Convert.ToDouble(data.Substring(0, pointer));
            data = data.Substring(pointer);
            pointer = 0;
            data=data.TrimStart();
            int Description = Convert.ToInt32(data);
            data = data.Substring(pointer);
            Nodes.Add(new Node(XCoord, YCoord, Description));
        }
    }
    class Node
    {
        public Point Coordinates
        {
            get
            {
                return new Point(new Foot(), XCoord, YCoord, 0);

            }
            set
            {
                this.XCoord = value.X.ValueInFeet;
                this.YCoord = value.Y.ValueInFeet;
            }
        }
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

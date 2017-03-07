using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class BearingData
    {
        public List<Bearing> Bearings { get; set; }
        private int jointCount;
        public double MaxProtrusion { get; set; }
        //ask Nathan if it's bad to have a name this long
        public bool OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember { get; set; }
        public BearingData(double MaxProtrusion,bool OnlyFast,int jointCount)
        {
            Bearings = new List<Bearing>();
            //ask Nathan about this
            Bearings.Add(null);
            this.jointCount = jointCount;
            this.MaxProtrusion = MaxProtrusion;
            this.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember = OnlyFast;
        }
        public void AddBearing(string data)
        {
            Type Type = enumChecker(data.Substring(18, 4));
            double Width = Convert.ToDouble(data.Substring(25, 5));
            double XCoord = Convert.ToDouble(data.Substring(39, 6));
            double YCoord = Convert.ToDouble(data.Substring(51, 6));
            int BearingType = Convert.ToInt32(data.Substring(64, 2));
            string WallSpecies = data.Substring(73);
            Bearings.Add(new Bearing(jointCount, Width, XCoord, YCoord, BearingType, WallSpecies));
            Bearings[Bearings.Count() - 1].Joints[Convert.ToInt32(data.Substring(10, 2))] = Type;
        }
        public void AddJointToBearing(string data)
        {
            int bearing = Convert.ToInt32(data.Substring(4, 2));
            Type Type = enumChecker(data.Substring(18, 4));
            Bearings[bearing].Joints[Convert.ToInt32(data.Substring(10, 2))] = Type;
        }
        private Type enumChecker(string check)
        {
            if (check == "Roll")
            {
                return Type.Roll;
            }
            else if (check == "Pin ")
            {
                return Type.Pin;
            }
            else
            {
                return Type.Fixed;
            }
        }
    }
    class Bearing
    {
        public List<Type> Joints { get; set; }
        public double Width { get; set; }
        public double XCoord { get; set; }
        public double YCoord { get; set; }
        public int BearingType { get; set; }
        public string WallSpecies { get; set; }
        public Bearing(int jointCount,double Width,double XCoord,double YCoord,int BearingType,string WallSpecies)
        {
            Joints = new List<Type>();
            for(int i = 0; i < jointCount; i++)
            {
                Joints.Add(Type.empty);
            }
            this.Width = Width;
            this.XCoord = XCoord;
            this.YCoord = YCoord;
            this.BearingType = BearingType;
            this.WallSpecies = WallSpecies;
        }
        public void AddJoint(Type Type,int location)
        {
            Joints[location] = Type;
        }
    }
}

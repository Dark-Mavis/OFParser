using GeometryClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;

namespace OFParser
{
    class BearingData
    {
        public List<Bearing> Bearings { get; set; }
        private int jointCount;
        public double MaxProtrusionOfSupportingFastener { get; set; }
        public bool OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember { get; set; }
        public BearingData(double MaxProtrusion,bool OnlyFast,int jointCount)
        {
            Bearings = new List<Bearing>();
            this.jointCount = jointCount;
            this.MaxProtrusionOfSupportingFastener = MaxProtrusion;
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
            AddJointToBearing(data);
        }
        public void AddJointToBearing(string data)
        {
            data = data.TrimStart();
            int bearing = Convert.ToInt32(data.Substring(0, 2));
            data = data.Substring(2);
            data = data.TrimStart();
            int jointNumber = Convert.ToInt32(data.Substring(0, 2));
            data = data.Substring(2);
            data = data.TrimStart();
            Type Type = enumChecker(data.Substring(0, 4));
            JointType current = new JointType(jointNumber, Type);
            Bearings[bearing-1].Joints.Add(current);
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
        public List<JointType> Joints { get; set; }
        public double WidthInches { get; set; }
        public double XCoord { get; set; }
        public double YCoord { get; set; }
        public int BearingType { get; set; }
        public string WallSpecies { get; set; }
        public Bearing(int jointCount,double Width,double XCoord,double YCoord,int BearingType,string WallSpecies)
        {
            Joints = new List<JointType>();
            this.WidthInches = Width;
            this.XCoord = XCoord;
            this.YCoord = YCoord;
            this.BearingType = BearingType;
            this.WallSpecies = WallSpecies;
        }
        public Point Coordinates
        {
            get
            {
                return new Point(new Distance(new Foot(), this.XCoord), new Distance(new Foot(), this.YCoord));
            }
            set
            {
                this.XCoord = value.X.ValueInFeet;
                this.YCoord = value.Y.ValueInFeet;
            }
        }
        public Distance Width
        {
            get
            {
                return new Distance(new Inch(), this.WidthInches);
            }
            set
            {
                this.WidthInches = value.ValueInInches;
            }
        }
    }
    class JointType
    {
        public int JointNumber { get; set; }
        public Type Type { get; set; }
        public JointType(int JointNumber,Type Type)
        {
            this.JointNumber = JointNumber;
            this.Type = Type;
        }
    }
}

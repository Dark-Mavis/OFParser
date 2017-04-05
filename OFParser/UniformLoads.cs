using GeometryClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DerivedUnits.StressUnit;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;
using UnitClassLibrary.DistributedForceUnit;

namespace OFParser
{
    class UniformLoads
    {
        public List<Load> Loads { get; set; }
        public UniformLoads()
        {
            Loads = new List<Load>();
        }
        public void AddLoad(string data)
        {
            double StartX = Convert.ToDouble(data.Substring(8, 5));
            double StartY = Convert.ToDouble(data.Substring(17, 5));
            double MagnitudeStart = Convert.ToDouble(data.Substring(26, 5));
            double EndX = Convert.ToDouble(data.Substring(35, 5));
            double EndY = Convert.ToDouble(data.Substring(42, 5));
            double MagnitudeEnd = Convert.ToDouble(data.Substring(51, 5));
            bool LiveLoad;
            if (Convert.ToDouble(data.Substring(61)) == 1)
            {
                LiveLoad = true;
            }
            else
            {
                LiveLoad = false;
            }
            Loads.Add(new Load(StartX, StartY, MagnitudeStart, EndX, EndY, MagnitudeEnd, LiveLoad));
        }
    }
    class Load
    {
        //PLF=pounds per linear foot
        public double StartXFeet { get; set; }
        public double StartYFeet { get; set; }
        public double MagnitudeStartPLF { get; set; }
        public double EndXFeet { get; set; }
        public double EndYFeet { get; set; }
        public double MagnitudeEndPLF { get; set; }
        //probably a boolean, as it shows either a 1 or a 0 (also Nathan said so)
        //I'm assuming that 1 is true and 0 is no. Should ask Matt or Nathan
        public bool LiveLoad { get; set; }
        public Load(double StartX,double StartY,double MagnitudeStart,double EndX,double EndY,double MagnitudeEnd,bool LiveLoad)
        {
            this.StartXFeet = StartX;
            this.StartYFeet = StartY;
            this.MagnitudeStartPLF = MagnitudeStart;
            this.EndXFeet = EndX;
            this.EndYFeet = EndY;
            this.MagnitudeEndPLF = MagnitudeEnd;
            this.LiveLoad = LiveLoad;
        }
        public Point StartCoordinates
        {
            get
            {
                return new Point(new Distance(new Foot(), this.StartXFeet), new Distance(new Foot(), this.StartYFeet));
            }
            set
            {
                this.StartXFeet = value.X.ValueInFeet;
                this.StartYFeet = value.Y.ValueInFeet;
            }
        }
        public Point EndCoordinates
        {
            get
            {
                return new Point(new Distance(new Foot(), this.EndXFeet), new Distance(new Foot(), this.EndYFeet));
            }
            set
            {
                this.EndXFeet = value.X.ValueInFeet;
                this.EndYFeet = value.Y.ValueInFeet;
            }
        }
        public DistributedForce StartMagnitude
        {
            get
            {
                return new DistributedForce(this.MagnitudeStartPLF, new PoundPerFoot());
            }
            set
            {
                this.MagnitudeStartPLF = value.InPoundsPerFoot.Value;
            }
        }
        public DistributedForce EndMagnitude
        {
            get
            {
                return new DistributedForce(this.MagnitudeEndPLF, new PoundPerFoot());
            }
            set
            {
                this.MagnitudeEndPLF = value.InPoundsPerFoot.Value;
            }
        }
    }
}

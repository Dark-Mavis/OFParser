using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            double LiveLoad = Convert.ToDouble(data.Substring(61));
            Loads.Add(new Load(StartX, StartY, MagnitudeStart, EndX, EndY, MagnitudeEnd, LiveLoad));
        }
    }
    class Load
    {
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double MagnitudeStart { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public double MagnitudeEnd { get; set; }
        public double LiveLoad { get; set; }
        public Load(double StartX,double StartY,double MagnitudeStart,double EndX,double EndY,double MagnitudeEnd,double LiveLoad)
        {
            this.StartX = StartX;
            this.StartY = StartY;
            this.MagnitudeStart = MagnitudeStart;
            this.EndX = EndX;
            this.EndY = EndY;
            this.MagnitudeEnd = MagnitudeEnd;
            this.LiveLoad = LiveLoad;
        }
    }
}

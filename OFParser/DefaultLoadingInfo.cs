using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class DefaultLoadingInfo
    {
        public string Description { get; set; }
        public double TCLiveLoad { get; set; }
        public double TCDeadLoad { get; set; }
        public double BCDeadLoad { get; set; }
        public double BCLiveLoad { get; set; }
        public double DurationFactor { get; set; }
        public double Spacing { get; set; }
        public int NumberOfPlys { get; set; }
        public string WindLoading { get; set; }
        public DefaultLoadingInfo(string Description,double TCLiveLoad,double TCDeadLoad,double BCDeadLoad,double BCLiveLoad,double DurationFactor,double Spacing,int NumberOfPlys,string WindLoading)
        {
            this.Description = Description;
            this.TCLiveLoad = TCLiveLoad;
            this.TCDeadLoad = TCDeadLoad;
            this.BCDeadLoad = BCDeadLoad;
            this.BCLiveLoad = BCLiveLoad;
            this.DurationFactor = DurationFactor;
            this.Spacing = Spacing;
            this.NumberOfPlys = NumberOfPlys;
            this.WindLoading = WindLoading;
        }
    }
}

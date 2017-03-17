using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;

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
        public double SpacingFt { get; set; }
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
            this.SpacingFt = Spacing;
            this.NumberOfPlys = NumberOfPlys;
            this.WindLoading = WindLoading;
        }
        public Distance Spacing
        {
            get
            {
                return new Distance(new Foot(), this.SpacingFt);
            }
            set
            {
                this.SpacingFt = value.ValueInFeet;
            }
        }
    }
}

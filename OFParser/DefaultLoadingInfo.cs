using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DerivedUnits.StressUnit;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;

namespace OFParser
{
    class DefaultLoadingInfo
    {
        public string Description { get; set; }
        public double TCLiveLoadPSF { get; set; }
        public double TCDeadLoadPSF { get; set; }
        public double BCDeadLoadPSF { get; set; }
        public double BCLiveLoadPSF { get; set; }
        public double DurationFactor { get; set; }
        public double SpacingFeet { get; set; }
        public int NumberOfPlys { get; set; }
        public string WindLoading { get; set; }
        public DefaultLoadingInfo(string Description,double TCLiveLoad,double TCDeadLoad,double BCDeadLoad,double BCLiveLoad,double DurationFactor,double Spacing,int NumberOfPlys,string WindLoading)
        {
            this.Description = Description;
            this.TCLiveLoadPSF = TCLiveLoad;
            this.TCDeadLoadPSF = TCDeadLoad;
            this.BCDeadLoadPSF = BCDeadLoad;
            this.BCLiveLoadPSF = BCLiveLoad;
            this.DurationFactor = DurationFactor;
            this.SpacingFeet = Spacing;
            this.NumberOfPlys = NumberOfPlys;
            this.WindLoading = WindLoading;
        }
      /*  public Stress TopChordLiveLoad
        {
            get
            {
                return new Stress(new PoundPerSquareFoot(), this.TCLiveLoadPSF);
            }
            set
            {
                this.TCLiveLoadPSF = value.InPSF.Value;
            }
        }
        public Stress TopChordDeadLoad
        {
            get
            {
                return new Stress(new PoundPerSquareFoot(), this.TCDeadLoadPSF);
            }
            set
            {
                this.TCDeadLoadPSF = value.InPSF.Value;
            }
        }
        public Stress BottomChordLiveLoad
        {
            get
            {
                return new Stress(new PoundPerSquareFoot(), this.BCLiveLoadPSF);
            }
            set
            {
                this.BCLiveLoadPSF = value.InPSF.Value;
            }
        }
        public Stress BottomChordDeadLoad
        {
            get
            {
                return new Stress(new PoundPerSquareFoot(), this.BCDeadLoadPSF);
            }
            set
            {
                this.BCDeadLoadPSF = value.InPSF.Value;
            }
        }*/
        public Distance Spacing
        {
            get
            {
                return new Distance(new Foot(), this.SpacingFeet);
            }
            set
            {
                this.SpacingFeet = value.ValueInFeet;
            }
        }
    }
}

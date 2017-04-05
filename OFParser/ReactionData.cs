using GeometryClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DerivedUnits;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;
using UnitClassLibrary.ForceUnit;

namespace OFParser
{
    class ReactionData
    {
        public List<BearingCase> Bearings { get; set; }
        //sometimes the ReactionData ends with a line reading as follows:
        //***** NOTE: BEARING REACTION EXCEEDS ALLOWABLE *****
        //boolean is true if this line appears
        public bool BearingReactionExceedsAllowable { get; set; }
        public ReactionData(bool bearingReactionExceedsAllowable)
        {
            this.BearingReactionExceedsAllowable = bearingReactionExceedsAllowable;
            Bearings = new List<BearingCase>();
        }
        public void AddBearing(string data)
        {
            int BearingNumber = Convert.ToInt32(data.Substring(6, 2));
            double VerticalReactionNumber = Convert.ToDouble(data.Substring(16, 8));
            double VerticalAllowableNumber = Convert.ToDouble(data.Substring(26, 9));
            double HorizontalNumber = Convert.ToDouble(data.Substring(37, 13));
            double MomentNumber = Convert.ToDouble(data.Substring(52, 5));
            double XLocation = 1234567890;
            double YLocation = 1234567890;
            //this conditional is because in some cases, X and Y Location don't appear
            //should ask Nathan about this
            if (data.Count()>58)
            { 
                XLocation = Convert.ToDouble(data.Substring(65, 9));
                YLocation = Convert.ToDouble(data.Substring(76));
            }
            Bearings.Add(new BearingCase(BearingNumber,VerticalReactionNumber, VerticalAllowableNumber, HorizontalNumber, MomentNumber, XLocation, YLocation));
        }
    }
    class BearingCase
    {
        public int BearingNumber { get; set; }
        public double VerticalReactionPounds { get; set; }
        public double VerticalAllowablePounds { get; set; }
        public double HorizontalPounds { get; set; }
        public double MomentFtPound { get; set; }
        public double XLocation { get; set; }
        public double YLocation { get; set; }
        public BearingCase(int BearingNumber,double VerticalReactionNumber,double VerticalAllowableNumber,double HorizontalNumber,double MomentNumber,double XLocation,double YLocation)
        {
            this.BearingNumber = BearingNumber;
            this.VerticalReactionPounds = VerticalReactionNumber;
            this.VerticalAllowablePounds = VerticalAllowableNumber;
            this.HorizontalPounds = HorizontalNumber;
            this.MomentFtPound = MomentNumber;
            this.XLocation = XLocation;
            this.YLocation = YLocation;
        }
        public Point Coordinates
        {
            get
            {
                return new Point(new Distance(new Inch(), XLocation), new Distance(new Inch(), YLocation));
            }
            set
            {
                this.XLocation = value.X.ValueInFeet;
                this.YLocation = value.Y.ValueInFeet;
            }
        }
        public Force VerticalReaction
        {
            get
            {
                return new Force(new Pound(), this.VerticalReactionPounds);
            }
            set
            {
                this.VerticalReactionPounds = value.InPounds.Value;
            }
        }
        public Force VerticalAllowable
        {
            get
            {
                return new Force(new Pound(), this.VerticalAllowablePounds);
            }
            set
            {
                this.VerticalAllowablePounds = value.InPounds.Value;
            }
        }
        public Force Horizontal
        {
            get
            {
                return new Force(new Pound(), this.HorizontalPounds);
            }
            set
            {
                this.HorizontalPounds = value.InPounds.Value;
            }
        }
        public Moment Moment
        {
            get
            {
                return new Moment(new FootPound(), MomentFtPound);
            }
            set
            {
                this.MomentFtPound = value.InFootPounds.Value;
            }
        }
    }
}

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
    class DeflectionPPData
    {
        public List<Deflect> Deflects { get; set; }
        public DeflectionPPData()
        {
            Deflects = new List<Deflect>();
        }
        public void AddDeflection(string data)
        {
            string Label = data.Substring(4, 2);
            double XLocation = Convert.ToDouble(data.Substring(9, 5));
            double LiveLoadX = Convert.ToDouble(data.Substring(15, 5));
            double LiveLoadY = Convert.ToDouble(data.Substring(21, 5));
            //allow falls between the LiveLoad coordinates and the DeadLoad coordinates
            double Allow = Convert.ToDouble(data.Substring(29, 5));
            double DeadLoadX = Convert.ToDouble(data.Substring(35, 5));
            double DeadLoadY = Convert.ToDouble(data.Substring(41, 5));
            double TotalLoadsX = Convert.ToDouble(data.Substring(47, 5));
            double TotalLoadsY = Convert.ToDouble(data.Substring(53, 5));
            //this is also name Allow, but it falls after the TotalLoads coordinates
            double AllowTotal = Convert.ToDouble(data.Substring(61, 5));
            double Span = Convert.ToDouble(data.Substring(67, 5));
            Deflects.Add(new Deflect(Label, XLocation, LiveLoadX, LiveLoadY, Allow, DeadLoadX, DeadLoadY, TotalLoadsX, TotalLoadsY, AllowTotal, Span));
        }
    }
    class DeflectionMPData
    {
        public List<Deflect> Deflects { get; set; }
        public DeflectionMPData()
        {
            Deflects = new List<Deflect>();
        }
        public void AddDeflection(string data)
        {
            string Label = data.Substring(4, 2);
            double XLocation = Convert.ToDouble(data.Substring(9, 5));
            double LiveLoadX = Convert.ToDouble(data.Substring(15, 5));
            double LiveLoadY = Convert.ToDouble(data.Substring(21, 5));
            double Allow = Convert.ToDouble(data.Substring(29, 5));
            double DeadLoadX = Convert.ToDouble(data.Substring(35, 5));
            double DeadLoadY = Convert.ToDouble(data.Substring(41, 5));
            double TotalLoadsX = Convert.ToDouble(data.Substring(47, 5));
            double TotalLoadsY = Convert.ToDouble(data.Substring(53, 5));
            double AllowTotal = Convert.ToDouble(data.Substring(61, 5));
            double Span = Convert.ToDouble(data.Substring(67, 5));
            Deflects.Add(new Deflect(Label, XLocation, LiveLoadX, LiveLoadY, Allow, DeadLoadX, DeadLoadY, TotalLoadsX, TotalLoadsY, AllowTotal, Span));
        }
    }
    class Deflect
    {
        public string Label { get; set; }
        public double XLocationFeet { get; set; }
        public double LiveLoadXInches { get; set; }
        public double LiveLoadYInches { get; set; }
        public double Allow { get; set; }
        public double DeadLoadXInches { get; set; }
        public double DeadLoadYInches { get; set; }
        public double TotalLoadXInches { get; set; }
        public double TotalLoadYInches { get; set; }
        public double AllowTotal { get; set; }
        public double SpanFeet { get; set; }
        public Deflect(string Label,double XLocation,double LiveLoadX,double LiveLoadY,double Allow,double DeadLoadX,double DeadLoadY,double TotalLoadsX,double TotalLoadsY,double AllowTotal,double SpanFeet)
        {
            this.Label = Label;
            this.XLocationFeet = XLocation;
            this.LiveLoadXInches = LiveLoadX;
            this.LiveLoadYInches = LiveLoadY;
            this.Allow = Allow;
            this.AllowTotal = AllowTotal;
            this.DeadLoadXInches = DeadLoadX;
            this.DeadLoadYInches = DeadLoadY;
            this.TotalLoadXInches = TotalLoadsX;
            this.TotalLoadYInches = TotalLoadsY;
            this.AllowTotal = AllowTotal;
            this.SpanFeet = SpanFeet;
        }
        public Distance XLocation
        {
            get
            {
                return new Distance(new Foot(), this.XLocationFeet);
            }
            set
            {
                this.XLocationFeet = value.ValueInFeet;
            }
        }
        public Point LiveLoad
        {
            get
            {
                return new Point(new Distance(new Inch(), this.LiveLoadXInches), new Distance(new Inch(), this.LiveLoadYInches));
            }
            set
            {
                this.LiveLoadXInches = value.X.ValueInInches;
                this.LiveLoadYInches = value.Y.ValueInInches;
            }
        }
        public Point DeadLoad
        {
            get
            {
                return new Point(new Distance(new Inch(), this.DeadLoadXInches), new Distance(new Inch(), this.DeadLoadYInches));
            }
            set
            {
                this.DeadLoadXInches = value.X.ValueInInches;
                this.DeadLoadYInches = value.Y.ValueInInches;
            }
        }
        public Point TotalLoad
        {
            get
            {
                return new Point(new Distance(new Inch(), this.TotalLoadXInches), new Distance(new Inch(), this.TotalLoadYInches));
            }
            set
            {
                this.TotalLoadXInches = value.X.ValueInInches;
                this.TotalLoadYInches = value.Y.ValueInInches;
            }
        }
        public Distance Span
        {
            get
            {
                return new Distance(new Foot(), this.SpanFeet);
            }
            set
            {
                this.SpanFeet = value.ValueInFeet;
            }
        }
    }
}

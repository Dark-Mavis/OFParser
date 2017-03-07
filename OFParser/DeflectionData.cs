using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double XLocation { get; set; }
        public double LiveLoadX { get; set; }
        public double LiveLoadY { get; set; }
        public double Allow { get; set; }
        public double DeadLoadX { get; set; }
        public double DeadLoadY { get; set; }
        public double TotalLoadsX { get; set; }
        public double TotalLoadsY { get; set; }
        public double AllowTotal { get; set; }
        public double Span { get; set; }
        public Deflect(string Label,double XLocation,double LiveLoadX,double LiveLoadY,double Allow,double DeadLoadX,double DeadLoadY,double TotalLoadsX,double TotalLoadsY,double AllowTotal,double Span)
        {
            this.Label = Label;
            this.XLocation = XLocation;
            this.LiveLoadX = LiveLoadX;
            this.LiveLoadY = LiveLoadY;
            this.Allow = Allow;
            this.AllowTotal = AllowTotal;
            this.DeadLoadX = DeadLoadX;
            this.DeadLoadY = DeadLoadY;
            this.TotalLoadsX = TotalLoadsX;
            this.TotalLoadsY = TotalLoadsY;
            this.AllowTotal = AllowTotal;
            this.Span = Span;
        }
    }
}

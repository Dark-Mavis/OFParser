﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class ReactionData
    {
        public List<BearingCase> Bearings { get; set; }
        public ReactionData()
        { 
            Bearings = new List<BearingCase>();
            BearingCase cur = null;
            Bearings.Add(cur);
        }
        public void AddBearing(string data)
        {
            double VerticalReactionNumber = Convert.ToDouble(data.Substring(16, 8));
            double VerticalAllowableNumber = Convert.ToDouble(data.Substring(26, 9));
            double HorizontalNumber = Convert.ToDouble(data.Substring(37, 13));
            double MomentNumber = Convert.ToDouble(data.Substring(52, 5));
            double XLocation = 1234567890;
            double YLocation = 1234567890;
            if (data.Count()>58)
            { 
                XLocation = Convert.ToDouble(data.Substring(65, 9));
                YLocation = Convert.ToDouble(data.Substring(76));
            }
            Bearings.Add(new BearingCase(VerticalReactionNumber, VerticalAllowableNumber, HorizontalNumber, MomentNumber, XLocation, YLocation));
        }
    }
    class BearingCase
    {
        public double VerticalReactionNumber { get; set; }
        public double VerticalAllowableNumber { get; set; }
        public double HorizontalNumber { get; set; }
        public double MomentNumber { get; set; }
        public double XLocation { get; set; }
        public double YLocation { get; set; }
        public BearingCase(double VerticalReactionNumber,double VerticalAllowableNumber,double HorizontalNumber,double MomentNumber,double XLocation,double YLocation)
        {
            this.VerticalReactionNumber = VerticalReactionNumber;
            this.VerticalAllowableNumber = VerticalAllowableNumber;
            this.HorizontalNumber = HorizontalNumber;
            this.MomentNumber = MomentNumber;
            this.XLocation = XLocation;
            this.YLocation = YLocation;
        }
    }
}
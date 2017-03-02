using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class MiscData
    {
        public string DesignCode { get; set; }
        public bool IsFlameRetardant { get; set; }
        public string MKAPriority { get; set; }
        public bool TCSheathingStatus { get; set; }
        public double TCPurlinSpacing { get; set; }
        public double BCPurlinSpacing { get; set; }
        public string RequestedBraceType { get; set; }
        public bool LoadSharing { get; set; }
        public bool PlasterCeiling { get; set; }
        public string SY42SquareCutWebCalcs { get; set; }
        public bool AllowBoltsOnGirders { get; set; }
        public bool SDSScrewsOnGirders { get; set; }
        public string AllowScabsOnTrays { get; set; }
        public bool EmpiricalAnalysis { get; set; }
        public bool CompositeFloor { get; set; }
        public bool KmFactor { get; set; }
        public bool RigidInsertsAllowedForFullFc { get; set; }
        public bool PlateIncreaseFactorForOverstressedBrg { get; set; }
        public MiscData(string designCode,bool isFlameRetardant,string MKAPriority,bool TCSheathingStatus,double TCPurlinSpacing,double BCPurlinSpacing,string requestedBraceType,bool loadSharing,bool plasterCeiling,string SY42SquareCutWebCalcs,bool allowBoltsOnGirders,bool SDSScrewsOnGirders,string allowScabsOnTrays,bool empiricalAnalysis,bool compositeFloor,bool KmFactor,bool rigidInsertsAllowedForFullFc,bool plateIncreaseFactorForOverstressedBrg)
        {
            this.DesignCode =designCode ;
            this.IsFlameRetardant = isFlameRetardant;
            this.MKAPriority = MKAPriority;
            this.TCSheathingStatus = TCSheathingStatus;
            this.TCPurlinSpacing = TCPurlinSpacing;
            this.BCPurlinSpacing = BCPurlinSpacing;
            this.RequestedBraceType = requestedBraceType;
            this.LoadSharing = loadSharing;
            this.PlasterCeiling = plasterCeiling;
            this.SY42SquareCutWebCalcs = SY42SquareCutWebCalcs;
            this.AllowBoltsOnGirders = allowBoltsOnGirders;
            this.SDSScrewsOnGirders = SDSScrewsOnGirders;
            this.AllowScabsOnTrays = allowScabsOnTrays;
            this.EmpiricalAnalysis = empiricalAnalysis;
            this.CompositeFloor = compositeFloor;
            this.KmFactor = KmFactor;
            this.RigidInsertsAllowedForFullFc = rigidInsertsAllowedForFullFc;
            this.PlateIncreaseFactorForOverstressedBrg = plateIncreaseFactorForOverstressedBrg;
        }
    }
}

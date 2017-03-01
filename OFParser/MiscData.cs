using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class MiscData
    {
        private string designCode { get; set; }
        private bool isFlameRetardant { get; set; }
        private string MKAPriority { get; set; }
        private bool TCSheathingStatus { get; set; }
        private double TCPurlinSpacing { get; set; }
        private double BCPurlinSpacing { get; set; }
        private string requestedBraceType { get; set; }
        private bool loadSharing { get; set; }
        private bool plasterCeiling { get; set; }
        private string SY42SquareCutWebCalcs { get; set; }
        private bool allowBoltsOnGirders { get; set; }
        private bool SDSScrewsOnGirders { get; set; }
        private string allowScabsOnTrays { get; set; }
        private bool empiricalAnalysis { get; set; }
        private bool compositeFloor { get; set; }
        private bool KmFactor { get; set; }
        private bool rigidInsertsAllowedForFullFc { get; set; }
        private bool plateIncreaseFactorForOverstressedBrg { get; set; }
        public MiscData(string designCode,bool isFlameRetardant,string MKAPriority,bool TCSheathingStatus,double TCPurlinSpacing,double BCPurlinSpacing,string requestedBraceType,bool loadSharing,bool plasterCeiling,string SY42SquareCutWebCalcs,bool allowBoltsOnGirders,bool SDSScrewsOnGirders,string allowScabsOnTrays,bool empiricalAnalysis,bool compositeFloor,bool KmFactor,bool rigidInsertsAllowedForFullFc,bool plateIncreaseFactorForOverstressedBrg)
        {
            designCode = this.designCode;
            isFlameRetardant = this.isFlameRetardant;
            MKAPriority = this.MKAPriority;
            TCSheathingStatus = this.TCSheathingStatus;
            TCPurlinSpacing = this.TCPurlinSpacing;
            BCPurlinSpacing = this.BCPurlinSpacing;
            requestedBraceType = this.requestedBraceType;
            loadSharing = this.loadSharing;
            plasterCeiling = this.plasterCeiling;
            SY42SquareCutWebCalcs = this.SY42SquareCutWebCalcs;
            allowBoltsOnGirders = this.allowBoltsOnGirders;
            SDSScrewsOnGirders = this.SDSScrewsOnGirders;
            allowScabsOnTrays = this.allowScabsOnTrays;
            empiricalAnalysis = this.empiricalAnalysis;
            compositeFloor = this.compositeFloor;
            KmFactor = this.KmFactor;
            rigidInsertsAllowedForFullFc = this.rigidInsertsAllowedForFullFc;
            plateIncreaseFactorForOverstressedBrg = this.plateIncreaseFactorForOverstressedBrg;
        }
    }
}

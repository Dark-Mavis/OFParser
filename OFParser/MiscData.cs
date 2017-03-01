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
    }
}

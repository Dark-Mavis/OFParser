using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class PlateInfo
    {
        public string ToothHoldingDescription { get; set; }
        public int ToothHoldingName { get; set; }
        public int NumberOfUnplatedJoints { get; set; }
        public int NumberOfTypes { get; set; }
        public int MostCommonPlateType { get; set; }
        public string PlateHandling { get; set; }

        public string PlateTypeName { get; set; }
        public int PlateType { get; set; }
        public double ZeroTension { get; set; }
        public double NinetyTension { get; set; }
        public double ZeroShear { get; set; }
        public double NinetyShear { get; set; }
        public PlateInfo(string ToothHoldingDescription,int ToothHoldingName,int NumberOfUnplatedJoints,int NumberOfTypes,int MostCommonPlateType,string PlateHandling,string PlateTypeName,int PlateType,double ZeroTension,double NinetyTension,double ZeroShear,double NinetyShear)
        {
            this.ToothHoldingDescription = ToothHoldingDescription;
            this.ToothHoldingName = ToothHoldingName;
            this.NumberOfUnplatedJoints = NumberOfUnplatedJoints;
            this.NumberOfTypes = NumberOfTypes;
            this.MostCommonPlateType = MostCommonPlateType;
            this.PlateHandling = PlateHandling;

            this.PlateTypeName = PlateTypeName;
            this.PlateType = PlateType;
            this.ZeroTension = ZeroTension;
            this.NinetyTension = NinetyTension;
            this.ZeroShear = ZeroShear;
            this.NinetyShear = NinetyShear;
        }
    }
}

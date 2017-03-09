using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistributedForceUnit;

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

        //check this
        public DistributedForce ZeroTensionPli
        {
            get
            {
                return new DistributedForce(this.ZeroTension,new PoundPerInch());
            }
            set
            {
                this.ZeroTension = value.InPoundsPerInch.Value;
            }
        }
        public DistributedForce NinetyTensionPli
        {
            get
            {
                return new DistributedForce(this.NinetyTension, new PoundPerInch());
            }
            set
            {
                this.NinetyTension = value.InPoundsPerInch.Value;
            }
        }
        public DistributedForce ZeroShearPli
        {
            get
            {
                return new DistributedForce(this.ZeroShear, new PoundPerInch());
            }
            set
            {
                this.ZeroShear = value.InPoundsPerInch.Value;
            }
        }
        public DistributedForce NinetyShearPli
        {
            get
            {
                return new DistributedForce(this.NinetyShear, new PoundPerInch());
            }
            set
            {
                this.NinetyShear = value.InPoundsPerInch.Value;
            }
        }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DerivedUnits.StressUnit;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.MileUnit;
using UnitClassLibrary.SpeedUnit;
using UnitClassLibrary.SpeedUnit.SpeedTypes;

namespace OFParser
{
    class LoadCase
    {
        public string LoadCaseType { get; set; }
        public double SpacingFeet { get; set; }
        public double DurationFactor { get; set; }
        public double PlateDurationFactor { get; set; }
        public int NumberOfPlys { get; set; }
        public bool UserModifiedLoads { get; set; }
        public int KindOfLoadCase { get; set; }
        public bool RepetitiveFactorsUsed { get; set; }
        public double SoffitDeadLoadPSF { get; set; }
        public ExtraInfo ExtraInfoBlock { get; set; }
        private int location;

        public UniformLoads UniformLoadsBlock { get; set; }
        public ReactionData ReactionDataBlock { get; set; }
        public CSIData CSIDataBlock { get; set; }
        public CSIShearData CSIShearDataBlock { get; set; }
        public DeflectionPPData DeflectionPPDataBlock { get; set; }
        public DeflectionMPData DeflectionMPDataBlock { get; set; }
        public ForceData ForceDataBlock { get; set; }
        public LoadCase(int locationin)
        {
            location = locationin;
        }
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
        /*
        public Stress SoffitDeadLoad
        {
            get
            {
                return new Stress(new PoundPerSquareFoot(), this.SoffitDeadLoadPSF);
            }
            set
            {
                this.SoffitDeadLoadPSF = value.InPSI.Value;
            }
        }*/
        public int createData(string[] data)
        {
            LoadCaseType = data[location].Substring(10);
            SpacingFeet = Convert.ToDouble(data[location+1].Substring(31, 4));
            DurationFactor = Convert.ToDouble(data[location+2].Substring(31, 4));
            PlateDurationFactor = Convert.ToDouble(data[location + 3].Substring(31, 4));
            NumberOfPlys = Convert.ToInt32(data[location + 4].Substring(31));
            UserModifiedLoads = booleanMaker(data[location + 5].Substring(31));
            KindOfLoadCase = Convert.ToInt32(data[location + 6].Substring(31));
            RepetitiveFactorsUsed = booleanMaker(data[location + 7].Substring(31));
            SoffitDeadLoadPSF = Convert.ToDouble(data[location + 8].Substring(30, 4));
            location = location + 9;
            if (data[location] != "")
            {
                string LoadCaseName = data[location].Substring(2);
                string ExposureType = data[location + 1].Substring(22);
                string BuildingClass = data[location + 2].Substring(22);
                double WindSpeed = Convert.ToDouble(data[location + 3].Substring(17,5));
                string BuildingType = data[location + 4].Substring(16);
                double DLTop = Convert.ToDouble(data[location + 5].Substring(17, 5));
                double DLBottom = Convert.ToDouble(data[location + 6].Substring(17, 5));
                double Height = Convert.ToDouble(data[location + 7].Substring(17, 5));
                bool Ceiling = booleanMaker(data[location + 8].Substring(16));
                bool Zone1 = booleanMaker(data[location + 9].Substring(16));
                bool Zone2 = booleanMaker(data[location + 10].Substring(16));
                double Uplifts1 = Convert.ToDouble(data[location + 11].Substring(16, 6));
                double Uplifts2 = 1234567890;
                if (data[location+11].Count()>28)
                {
                    Uplifts2 = Convert.ToDouble(data[location + 11].Substring(27, 6));
                }
                ExtraInfoBlock = new ExtraInfo(LoadCaseName,ExposureType,BuildingClass,WindSpeed,BuildingType,DLTop,DLBottom,Height,Ceiling,Zone1,Zone2,Uplifts1,Uplifts2);
                location = location + 12;
            }
            location = location + 4;
            uniformLoadStore(data);
            if(data[location-4]=="REACTION DATA")
            {
                reactionDataStore(data);
            }
            CSIDataStore(data);
            CSIShearDataStore(data);
            if (data[location - 5] == "DEFLECTION DATA")
            {
                deflectionDataStore(data);
            }
            else
            {
                location--;
            }
            forceDataStore(data);
            return location;
        }
        private void uniformLoadStore(string[] data)
        {
            UniformLoadsBlock = new UniformLoads();
            while (data[location] != "")
            {
                UniformLoadsBlock.AddLoad(data[location]);
                location++;
            }
            location = location + 6;
        }
        private void reactionDataStore(string[] data)
        {
            int pointer = location;
            while (data[pointer] != "")
            {
                pointer++;
            }
            ReactionDataBlock = new ReactionData();
            if (data[pointer - 1][8] == '*')
            {
                while (location<pointer-1)
                {
                    ReactionDataBlock.AddBearing(data[location]);
                    location++;
                }
                location=pointer;
            }
            else
            {
                while (data[location] != "")
                {
                    ReactionDataBlock.AddBearing(data[location]);
                    location++;
                }
            }
            location = location + 6;
        }
        private void CSIDataStore(string[] data)
        {
            CSIDataBlock = new CSIData();
            while (data[location] != "")
            {
                CSIDataBlock.AddMember(data[location]);
                location++;
            }
            location = location + 6;
        }
        private void CSIShearDataStore(string[] data)
        {
            CSIShearDataBlock = new CSIShearData();
            while (data[location] != "")
            {
                CSIShearDataBlock.AddMember(data[location]);
                location++;
            }
            location = location + 7;
        }
        private void deflectionDataStore(string[] data)
        {
            DeflectionMPDataBlock = new DeflectionMPData();
            DeflectionPPDataBlock = new DeflectionPPData();
            while (data[location] != "")
            {
                DeflectionPPDataBlock.AddDeflection(data[location]);
                location++;
            }
            location = location + 4;
            while (data[location] != "")
            {
                DeflectionMPDataBlock.AddDeflection(data[location]);
                location++;
            }
            location = location + 7;
        }
        private void forceDataStore(string[] data)
        {
            ForceDataBlock = new ForceData();
            while (data[location][0] != '*')
            {
                ForceDataBlock.AddMember(data[location]);
                location++;
                if (location == data.Count())
                {
                    break;
                }
            }
        }
        private bool booleanMaker(string word)
        {
            if (word == "True"||word=="Yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class ExtraInfo
    {
        public string LoadCaseName { get; set; }
        public string ExposureType { get; set; }
        public string BuildingClass { get; set; }
        public double WindSpeedMPH { get; set; }
        public string BuildingType { get; set; }
        public double DLTopPSF { get; set; }
        public double DLBottomPSF { get; set; }
        public double HeightFt { get; set; }
        public bool Ceiling { get; set; }
        public bool Zone1 { get; set; }
        public bool Zone2 { get; set; }
        public double Uplifts1 { get; set; }
        public double Uplifts2 { get; set; }
        public ExtraInfo(string LoadCaseName,string ExposureType,string BuildingClass,double WindSpeed,string BuildingType,double DLTop,double DLBottom,double Height,bool Ceiling,bool Zone1,bool Zone2,double Uplifts1,double Uplifts2)
        {
            this.LoadCaseName = LoadCaseName;
            this.ExposureType = ExposureType;
            this.BuildingClass = BuildingClass;
            this.WindSpeedMPH = WindSpeed;
            this.BuildingType = BuildingType;
            this.DLTopPSF = DLTop;
            this.DLBottomPSF = DLBottom;
            this.HeightFt = Height;
            this.Ceiling = Ceiling;
            this.Zone1 = Zone1;
            this.Zone2 = Zone2;
            this.Uplifts1 = Uplifts1;
            this.Uplifts2 = Uplifts2;
        }
       /* public Speed WindSpeed
        {
            get
            {
                return new Speed(new MilePerHour(),
            }
        }
        public Stress DLTop
        {
            get
            {
                return new Stress(new PoundPerSquareFoot(), this.DLTopPSF);
            }
        }*/
        public Distance Height
        {
            get
            {
                return new Distance(new Foot(), this.HeightFt);
            }
            set
            {
                this.HeightFt = value.ValueInFeet;
            }
        }
    }
}

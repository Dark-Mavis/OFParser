using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    public enum Type
    {
        Roll,
        Fixed,
        Pin,
        empty
    }
    class OFParser
    {
        private ArrayList file = new ArrayList();
        public string Version { get; set; }
        public DateTime DateAndTime { get; set; }
        public string JobKey { get; set; }
        public string JobDescription { get; set; }
        public string TrussDescription { get; set; }
        private string[] data;
        private int location = 0;

        public MiscData MiscDataBlock { get; set; }
        public JointData JointDataBlock { get; set; }
        public PlateInfo PlateInfoBlock { get; set; }
        public PlateData PlateDataBlock { get; set; }
        public QualityControlToothCounts QualityControlToothCountsBlock { get; set; }
        public MemberData MemberDataBlock { get; set; }
        public LumberData LumberDataBlock { get; set; }
        public BearingData BearingDataBlock { get; set; }

        public DefaultLoadingInfo DefaultInfoBlock { get; set; }
        public List<LoadCase> LoadCases { get; set; }

        public OFParser(string location)
        {
            createData(location);
        }
        private void readInFile(string location)
        {
            using (StreamReader sr = File.OpenText(location))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    file.Add(s);
                }
            }
        }
        private void createData(string location)
        {
            readInFile(location);
            data = new string[file.Count];
            for (int i = 0; i < file.Count; i++)
            {
                data[i] = (string)file[i];
            }
            Version = data[3].Substring(38, 16);
            int month = monthCapture(data[6].Substring(17, 3));
            DateAndTime = new DateTime(Convert.ToInt32(data[6].Substring(33,4)),month, Convert.ToInt32(data[6].Substring(21, 2)), Convert.ToInt32(data[6].Substring(24, 2)), Convert.ToInt32(data[6].Substring(27, 2)), Convert.ToInt32(data[6].Substring(30, 2)));
            JobKey = data[8].Substring(27, 11);
            JobDescription = data[8].Substring(41);
            TrussDescription = data[9].Substring(19);
            miscDataStore(data);
            jointDataStore(data);
            plateInfoStore(data);
            plateDataStore(data);
            qualityControlStore(data);
            memberDataStore(data);
            lumberDataStore(data);
            bearingDataStore(data);

            defaultLoadingInfoStore(data);
            loadCases(data);
        }
        private void miscDataStore(string[] data)
        {
            bool fire = booleanMaker(data[16].Substring(28));
            bool tc = booleanMaker(data[18].Substring(28));
            bool load = booleanMaker(data[22].Substring(28));
            bool plaster = booleanMaker(data[23].Substring(28));
            bool bolts = booleanMaker(data[25].Substring(28));
            bool screws = booleanMaker(data[26].Substring(28));
            bool emp = booleanMaker(data[28].Substring(28));
            bool floor = booleanMaker(data[29].Substring(28));
            bool km = booleanMaker(data[30].Substring(28));
            bool rigid = booleanMaker(data[31].Substring(28));
            bool plate = booleanMaker(data[32].Substring(28));
            MiscDataBlock = new MiscData(data[15].Substring(28), fire, data[17].Substring(28), tc, Convert.ToDouble(data[19].Substring(28)), Convert.ToDouble(data[20].Substring(28)), data[21].Substring(28), load, plaster, data[24].Substring(28), bolts, screws, data[27].Substring(28), emp, floor, km, rigid, plate);
        }
        private void jointDataStore(string[] data)
        {
            location = 35;
            while (data[location] != "")
            {
                location++;
            }
            JointDataBlock = new JointData();
            for(int i = 38; i < location; i++)
            {
                JointDataBlock.AddNode(data[i]);
            }
        }
        private void plateInfoStore(string[] data)
        {
            location = location + 3;
            string ToothHoldingDescription = data[location].Substring(30);
            int ToothHoldingName = Convert.ToInt32(data[location + 1].Substring(30));
            int NumberOfUnplatedJoints = Convert.ToInt32(data[location + 2].Substring(30));
            int NumberOfTypes = Convert.ToInt32(data[location + 3].Substring(30));
            int MostCommonPlateType = Convert.ToInt32(data[location + 4].Substring(30));
            string PlateHandling = data[location + 5].Substring(30);

            string PlateTypeName = data[location + 8].Substring(24);
            int PlateType = Convert.ToInt32(data[location + 9].Substring(24));
            double ZeroTension = Convert.ToDouble(data[location + 10].Substring(24, 7));
            double NinetyTension = Convert.ToDouble(data[location + 11].Substring(24, 7));
            double ZeroShear = Convert.ToDouble(data[location + 12].Substring(24, 7));
            double NinetyShear = Convert.ToDouble(data[location + 13].Substring(24, 7));
            PlateInfoBlock = new PlateInfo(ToothHoldingDescription,ToothHoldingName,NumberOfUnplatedJoints,NumberOfTypes,MostCommonPlateType,PlateHandling,PlateTypeName,PlateType,ZeroTension,NinetyTension,ZeroShear,NinetyShear);
        }
        private void plateDataStore(string[] data)
        {
            location = location + 19;
            int pointer = location;
            while (data[location] != "")
            {
                location++;
            }
            PlateDataBlock = new PlateData();
            for(int i = pointer; i < location; i++)
            {
                PlateDataBlock.AddPlate(data[i]);
            }
        }
        private void qualityControlStore(string[] data)
        {
            location = location + 4;
            QualityControlToothCountsBlock = new QualityControlToothCounts();
            while (data[location] != "")
            {
                QualityControlToothCountsBlock.AddJoint(data[location]);
                location++;
            }
        }
        private void memberDataStore(string[] data)
        {
            location = location + 6;
            MemberDataBlock = new MemberData();
            while(data[location]!="")
            {
                MemberDataBlock.AddMember(data[location]);
                location++;
            }

        }
        private void lumberDataStore(string[] data)
        {
            location = location + 5;
            bool doubleRow;
            LumberDataBlock = new LumberData();
            while (data[location] != "")
            {
                int check = Convert.ToInt32(data[location].Substring(3, 2));
                while (LumberDataBlock.Lumbers.Count() < check)
                {
                    LumberDataBlock.AddNullLumber();
                }
                doubleRow=LumberDataBlock.AddLumber(data[location]);
                if (doubleRow)
                {
                    location++;
                }
                else
                {
                    LumberDataBlock.AddLumberDoubleRow(data[location], data[location + 1]);
                    location = location + 2;
                }
            }
        }
        private void bearingDataStore(string[] data)
        {
            location = location + 4;
            int pointer = location;
            while(data[pointer].Substring(0,6)!="  Max.")
            {
                pointer++;
            }
            double MaxProtrusion = Convert.ToDouble(data[pointer].Substring(47));
            bool OnlyFast = booleanMaker(data[pointer + 1].Substring(56));
            BearingDataBlock = new BearingData(MaxProtrusion, OnlyFast,JointDataBlock.Nodes.Count());
            while (location < pointer)
            {
                if (BearingDataBlock.Bearings.Count() == Convert.ToInt32(data[location].Substring(4, 2)))
                {
                    BearingDataBlock.AddBearing(data[location]);
                }
                else
                {
                    BearingDataBlock.AddJointToBearing(data[location]);
                }
                location++;
            }
        }
        
        private void defaultLoadingInfoStore(string[] data)
        {
            location = location + 7;
            string Description = data[location].Substring(34);
            double TCLiveLoad = Convert.ToDouble(data[location + 1].Substring(34, 10));
            double TCDeadLoad = Convert.ToDouble(data[location + 2].Substring(34, 10));
            double BCDeadLoad = Convert.ToDouble(data[location + 3].Substring(34, 10));
            double BCLiveLoad = Convert.ToDouble(data[location + 4].Substring(34, 10));
            double DurationFactor = Convert.ToDouble(data[location + 5].Substring(34, 10));
            double Spacing = Convert.ToDouble(data[location + 6].Substring(34, 10));
            int NumberOfPlys = Convert.ToInt32(data[location + 7].Substring(33, 2));
            string WindLoading = data[location + 8].Substring(34);
            DefaultInfoBlock = new DefaultLoadingInfo(Description,TCLiveLoad,TCDeadLoad,BCDeadLoad,BCLiveLoad,DurationFactor,Spacing,NumberOfPlys,WindLoading);
            location = location + 13;
        }
        private void loadCases(string[] data)
        {
            LoadCases = new List<LoadCase>();
            LoadCase current = null;
            LoadCases.Add(current);
            while (location < data.Count())
            {
                LoadCase cur = new LoadCase(location);
                location=cur.createData(data);
                LoadCases.Add(cur);
                location = location + 3;
            }
               
        }

        private bool booleanMaker(string word)
        {
            if (word == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int monthCapture(string month)
        {
            if (month == "Jan")
            {
                return 1;
            }
            else if (month == "Feb")
            {
                return 2;
            }
            else if (month == "Mar")
            {
                return 3;
            }
            else if (month == "Apr")
            {
                return 4;
            }
            else if (month == "May")
            {
                return 5;
            }
            else if (month == "Jun")
            {
                return 6;
            }
            else if (month == "Jul")
            {
                return 7;
            }
            else if (month == "Aug")
            {
                return 8;
            }
            else if (month == "Sep")
            {
                return 9;
            }
            else if (month == "Oct")
            {
                return 10;
            }
            else if (month == "Nov")
            {
                return 11;
            }
            else if (month == "Dec")
            {
                return 12;
            }
            Console.Out.Write("Something wrong");
            return 15;
        }
        public static void Main(string[] args)
        {
            OFParser fred = new OFParser("C:/Users/Cerullium/OneDrive/Work/OFParser/OF Parser/OF_File_Examples/T385.OF");
        }
    }
}

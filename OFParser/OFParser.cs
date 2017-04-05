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
        //there are a lot of boolean variables stored that seemed very much like booleans, but I could be wrong
        //I only applied boolean to variables that said false, true, yes, and no as their values in the OF files
        private List<string> file = new List<string>();
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
        //takes in file reference and stores each line as a string into file
        private void readInFile(string data)
        {
            string[] lines = data.Split('\n');
            //it's lines.count-1 because the data split always adds a final line with nothing in it
            for (int i = 0; i < lines.Count() - 1; i++)
            {
                //getting rid of \r at the end of each string
                lines[i] = lines[i].Substring(0, (lines[i].Count() - 1));
                file.Add(lines[i]);
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
            int year = Convert.ToInt32(data[6].Substring(33, 4));
            int month = monthCapture(data[6].Substring(17, 3));
            int day = Convert.ToInt32(data[6].Substring(21, 2));
            int hour = Convert.ToInt32(data[6].Substring(24, 2));
            int minute = Convert.ToInt32(data[6].Substring(27, 2));
            int second = Convert.ToInt32(data[6].Substring(30, 2));
            DateAndTime = new DateTime(year,month,day, hour, minute, second);
            //JobKey and JobDescription are found on the same line with a / separating them
            JobKey = data[8].Substring(27, 11);
            JobDescription = data[8].Substring(41);
            TrussDescription = data[9].Substring(19);
            //stores data under "Miscellaneous Data Block"
            miscDataStore(data);
            //stores data under "Joint Data"
            jointDataStore(data);
            //stores data under "Plate Information"
            plateInfoStore(data);
            //stores data under "Plate Data"
            plateDataStore(data);
            //stores data under "Quality Control ToothCounts"
            qualityControlStore(data);
            //stores data under "Member Data"
            memberDataStore(data);
            //stores data under "Lumber Data"
            lumberDataStore(data);
            //stores data under "Bearing Data"
            bearingDataStore(data);
            //stores data under "Default Loading Information"
            defaultLoadingInfoStore(data);

            //each OF file has only one section for each of the previous sections, 
            //but after these there are a variable number of Load Cases
            loadCases(data);
        }
        private void miscDataStore(string[] data)
        {
            string designCode = data[15].Substring(28);
            bool fireRetardantTreated = booleanMaker(data[16].Substring(28));
            string mkaPriority = data[17].Substring(28);
            bool tcSheathingStatus = booleanMaker(data[18].Substring(28));
            //please note, the following two names are the name found in the file plus "Inches" since that is the assumed unit
            double tcPurlinSpacingInches = Convert.ToDouble(data[19].Substring(28));
            double bcPurlinSpacingInches = Convert.ToDouble(data[20].Substring(28));
            string requestedBraceType = data[21].Substring(28);
            bool loadSharing = booleanMaker(data[22].Substring(28));
            bool plasterCeiling = booleanMaker(data[23].Substring(28));
            string sy42SquareCutWebCalcs = data[24].Substring(28);
            bool allowBoltsOnGirders = booleanMaker(data[25].Substring(28));
            bool sdsScrewsOnGirders = booleanMaker(data[26].Substring(28));
            bool empiricalAnalysis = booleanMaker(data[28].Substring(28));
            bool compositeFloor = booleanMaker(data[29].Substring(28));
            bool kmFactor = booleanMaker(data[30].Substring(28));
            bool rigidInsertsAllowedForFullFc = booleanMaker(data[31].Substring(28));
            bool plateIncreaseFactorForOverstressedBrg = booleanMaker(data[32].Substring(28));
            MiscDataBlock = new MiscData(designCode, fireRetardantTreated, mkaPriority, tcSheathingStatus, tcPurlinSpacingInches, bcPurlinSpacingInches, requestedBraceType, loadSharing, plasterCeiling,sy42SquareCutWebCalcs , allowBoltsOnGirders, sdsScrewsOnGirders, data[27].Substring(28), empiricalAnalysis, compositeFloor, kmFactor, rigidInsertsAllowedForFullFc, plateIncreaseFactorForOverstressedBrg);
        }
        private void jointDataStore(string[] data)
        {
            //this hard jump could be dangerous
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
            string toothHoldingDescription = data[location].Substring(30);
            int toothHoldingName = Convert.ToInt32(data[location + 1].Substring(30));
            int numberOfUnplatedJoints = Convert.ToInt32(data[location + 2].Substring(30));
            int numberOfTypes = Convert.ToInt32(data[location + 3].Substring(30));
            int mostCommonPlateType = Convert.ToInt32(data[location + 4].Substring(30));
            //only answer seen for plateHandling is "Checked" so... possibly a boolean. Left as string to be safe
            string plateHandling = data[location + 5].Substring(30);

            string plateTypeName = data[location + 8].Substring(24);
            int plateType = Convert.ToInt32(data[location + 9].Substring(24));
            //the following four variables all had a symbol of some sort between 0 or 90 and Tension or Shear. Not sure what it was. Greek?
            double zeroTension = Convert.ToDouble(data[location + 10].Substring(24, 7));
            double ninetyTension = Convert.ToDouble(data[location + 11].Substring(24, 7));
            double zeroShear = Convert.ToDouble(data[location + 12].Substring(24, 7));
            double ninetyShear = Convert.ToDouble(data[location + 13].Substring(24, 7));
            PlateInfoBlock = new PlateInfo(toothHoldingDescription,toothHoldingName,numberOfUnplatedJoints,numberOfTypes,mostCommonPlateType,plateHandling,plateTypeName,plateType,zeroTension,ninetyTension,zeroShear,ninetyShear);
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
                doubleRow=LumberDataBlock.AddLumber(data[location]);
                //this if/else thing is because the last row when printed puts the data for
                //the last one on two rows because the Description Species name goes too far
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
            location += 4;
            int pointer = location;
            while(data[pointer].Substring(0,6)!="  Max.")
            {
                pointer++;
            }
            double maxProtrusionOfSupportingFastenerInches = Convert.ToDouble(data[pointer].Substring(47));
            bool onlyFastenersGreaterThan1AndAHalfInMultiPlySupportingMember = booleanMaker(data[pointer + 1].Substring(56));
            BearingDataBlock = new BearingData(maxProtrusionOfSupportingFastenerInches, onlyFastenersGreaterThan1AndAHalfInMultiPlySupportingMember,JointDataBlock.Nodes.Count());
            
            while (location < pointer)
            {
                //this setup adds Joints to each Bearing. This is because I noticed that each bearing
                //only had one line where the values beyond Joint# and Type are shown, so to make things
                //simpler, I put the multiple joints in each bearing. The line with the extra information
                //always seems to be the first of the bearing, so if we need to line that information up
                //with the correct joint/type, then it would be JointType[0] in a bearing
                if (data[location].Count()>26)
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
            //WindLoading...unsure what on earth this is, so stored as string
            string WindLoading = data[location + 8].Substring(34);
            DefaultInfoBlock = new DefaultLoadingInfo(Description,TCLiveLoad,TCDeadLoad,BCDeadLoad,BCLiveLoad,DurationFactor,Spacing,NumberOfPlys,WindLoading);
            location = location + 13;
        }
        private void loadCases(string[] data)
        {
            LoadCases = new List<LoadCase>();
            //this null LoadCase is loaded in so that the reference number in the list matches the original OF file
            LoadCase current = null;
            LoadCases.Add(current);
            //since the load cases run through to the end, this is in place to prevent overrunning the end
            while (location < data.Count())
            {
                LoadCase newLoadCase = new LoadCase(location);
                //the createData method is called here rather than in LoadCase because the program
                //needs to know where location is moved to after storing this Case's info, since the 
                //length is variable, so it returns the amount that location has moved
                location=newLoadCase.createData(data)+3;
                LoadCases.Add(newLoadCase);
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
    }
}

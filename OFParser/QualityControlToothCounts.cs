using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class QualityControlToothCounts
    {
        public List<Joint> Joints { get; set; }
        public QualityControlToothCounts()
        {
            Joints = new List<Joint>();
        }
        public void AddJoint(string data)
        {
            int jointNumber = Convert.ToInt32(data.Substring(5, 2));
            int pointer = 11;
            while (data[pointer]!=' ')
            {
                pointer++;
            }
            //plateType always appears as WAVE in my examples, however there is a bunch of space 
            //after that before the next data, so I used this pointer method to be safe
            string plateType = data.Substring(11, pointer - 11);
            //current is just the moniker used for the Joint that will be stored
            Joint current=new Joint(jointNumber,plateType);
            data = data.Substring(22);
            //this next line helps determine how many sets of information are on this joint
            int times = data.Count() / 15;
            for(int i = 0; i < times; i++)
            {
                current.AddTeeth(data.Substring(0, 15));
                data = data.Substring(15);
            }
            Joints.Add(current);
        }
    }
    class Joint
    {
        public List<Teeth> Teeths { get; set; }
        public int JointNumber { get; set; }
        public string PlateType { get; set; }
        public Joint(int JointNumber,string PlateType)
        {
            Teeths = new List<Teeth>();
            this.JointNumber = JointNumber;
            this.PlateType = PlateType;    
        }
        public void AddTeeth(string data)
        {
            int memberNumber = Convert.ToInt32(data.Substring(3, 2));
            int requiredTeeth = Convert.ToInt32(data.Substring(8, 2));
            int availableTeeth = Convert.ToInt32(data.Substring(13, 2));
            Teeths.Add(new Teeth(memberNumber,requiredTeeth,availableTeeth));
        }
    }
    class Teeth
    {
        public int MemberNumber { get; set; }
        public int RequiredTeeth { get; set; }
        public int AvailableTeeth { get; set; }
        public Teeth(int MemberNumber,int RequiredTeeth,int AvailableTeeth)
        {
            this.MemberNumber = MemberNumber;
            this.RequiredTeeth = RequiredTeeth;
            this.AvailableTeeth = AvailableTeeth;
        }
    }
}

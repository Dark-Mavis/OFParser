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
            int pointer = 11;
            while (data[pointer]!=' ')
            {
                pointer++;
            }

            Joint cur=new Joint(Convert.ToInt32(data.Substring(5, 2)), data.Substring(11, pointer - 11));
            data = data.Substring(22);
            int times = data.Count() / 15;
            for(int i = 0; i < times; i++)
            {
                cur.AddTeeth(data.Substring(0, 15));
                data = data.Substring(15);
            }
            Joints.Add(cur);
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
            int mem = Convert.ToInt32(data.Substring(3, 2));
            Teeths.Add(new Teeth(Convert.ToInt32(data.Substring(3, 2)), Convert.ToInt32(data.Substring(8, 2)), Convert.ToInt32(data.Substring(13, 2))));
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

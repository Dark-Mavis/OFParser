using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class CSIShearData
    {
        public List<MemberShear> Members { get; set; }
        public CSIShearData()
        {
            Members = new List<MemberShear>();
        }
        public void AddMember(string data)
        {
            int memberNumber = Convert.ToInt32(data.Substring(6, 2));
            double actual = Convert.ToDouble(data.Substring(14, 6));
            int allowable = Convert.ToInt32(data.Substring(26, 3));
            double csi = Convert.ToDouble(data.Substring(33, 5));
            double location = Convert.ToDouble(data.Substring(42));
            Members.Add(new MemberShear(memberNumber, actual, allowable, csi, location));
        }
    }
    class MemberShear
    {
        public int MemberNumber { get; set; }
        public double Actual { get; set; }
        public int Allowable { get; set; }
        public double Csi { get; set; }
        public double Location { get; set; }
        public MemberShear(int MemberNumber,double Actual,int Allowable,double Csi,double Location)
        {
            this.MemberNumber = MemberNumber;
            this.Actual = Actual;
            this.Allowable = Allowable;
            this.Csi = Csi;
            this.Location = Location;
        }
    }
}

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
            double Actual = Convert.ToDouble(data.Substring(14, 6));
            int Allowable = Convert.ToInt32(data.Substring(26, 3));
            double Csi = Convert.ToDouble(data.Substring(33, 5));
            double Location = Convert.ToDouble(data.Substring(42));
            Members.Add(new MemberShear(Actual, Allowable, Csi, Location));
        }
    }
    class MemberShear
    {
        public double Actual { get; set; }
        public int Allowable { get; set; }
        public double Csi { get; set; }
        public double Location { get; set; }
        public MemberShear(double Actual,int Allowable,double Csi,double Location)
        {
            this.Actual = Actual;
            this.Allowable = Allowable;
            this.Csi = Csi;
            this.Location = Location;
        }
    }
}

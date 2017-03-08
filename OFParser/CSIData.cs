using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class CSIData
    {
        public List<MemberCase> Members { get; set; }
        public CSIData()
        {
            Members = new List<MemberCase>();
        }
        public void AddMember(string data)
        {
            while (Convert.ToInt32(data.Substring(6,2))>Members.Count())
            {
                MemberCase cur = null;
                Members.Add(cur);
            }
            double AX = Convert.ToDouble(data.Substring(12, 5));
            double BD = Convert.ToDouble(data.Substring(19, 5));
            double Total = Convert.ToDouble(data.Substring(29, 5));
            double LocMax = Convert.ToDouble(data.Substring(40, 5));
            double Len = Convert.ToDouble(data.Substring(53, 5));
            double Ke = Convert.ToDouble(data.Substring(63, 6));
            double RAF = Convert.ToDouble(data.Substring(70, 4));
            double RBF = Convert.ToDouble(data.Substring(75));
            Members.Add(new MemberCase(AX, BD, Total, LocMax, Len, Ke, RAF, RBF));
        }
    }
    class MemberCase
    {
        public double AX { get; set; }
        public double BD { get; set; }
        public double Total { get; set; }
        public double LocMax { get; set; }
        public double Len { get; set; }
        public double Ke { get; set; }
        public double RAF { get; set; }
        public double RBF { get; set; }
        public MemberCase(double AX,double BD,double Total,double LocMax,double Len,double Ke,double RAF,double RBF)
        {
            this.AX = AX;
            this.BD = BD;
            this.Total = Total;
            this.LocMax = LocMax;
            this.Len = Len;
            this.Ke = Ke;
            this.RAF = RAF;
            this.RBF = RBF;
        }
    }
}

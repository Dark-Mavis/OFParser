using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.FootUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;

namespace OFParser
{
    class CSIData//per ply
    {
        public List<MemberCase> Members { get; set; }
        public CSIData()
        {
            Members = new List<MemberCase>();
        }
        public void AddMember(string data)
        {
            //not sure what some of these abbreviations mean
            int memberNumber = Convert.ToInt32(data.Substring(6, 2));
            double ax = Convert.ToDouble(data.Substring(12, 5));
            double bd = Convert.ToDouble(data.Substring(19, 5));
            double total = Convert.ToDouble(data.Substring(29, 5));
            double locMax = Convert.ToDouble(data.Substring(40, 5));
            double length = Convert.ToDouble(data.Substring(53, 5));
            double ke = Convert.ToDouble(data.Substring(63, 6));
            double raf = Convert.ToDouble(data.Substring(70, 4));
            double rbf = Convert.ToDouble(data.Substring(75));
            Members.Add(new MemberCase(memberNumber, ax, bd, total, locMax, length, ke, raf, rbf));
        }
    }
    class MemberCase
    {
        public int MemberNumber { get; set; }
        public double AX { get; set; }
        public double BD { get; set; }
        public double Total { get; set; }
        public double LocMaxFeet { get; set; }
        public double LenInches { get; set; }
        public double Ke { get; set; }
        public double RAF { get; set; }
        public double RBF { get; set; }
        public MemberCase(int MemberNumber, double AX,double BD,double Total,double LocMax,double Len,double Ke,double RAF,double RBF)
        {
            this.MemberNumber = MemberNumber;
            this.AX = AX;
            this.BD = BD;
            this.Total = Total;
            this.LocMaxFeet = LocMax;
            this.LenInches = Len;
            this.Ke = Ke;
            this.RAF = RAF;
            this.RBF = RBF;
        }
        public Distance LocalMax
        {
            get
            {
                return new Distance(new Foot(), this.LocMaxFeet);
            }
            set
            {
                this.LocMaxFeet = value.ValueInFeet;
            }
        }
        public Distance Length
        {
            get
            {
                return new Distance(new Inch(), this.LenInches);
            }
            set
            {
                this.LenInches = value.ValueInInches;
            }
        }
    }
}

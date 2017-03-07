using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class ForceData
    {
        public List<MemberForce> Members { get; set; }
        public ForceData()
        {
            Members = new List<MemberForce>();
        }
        public void AddMember(string data)
        {
            double NegativeEndAxialNumber = Convert.ToDouble(data.Substring(10, 7));
            double NegativeEndShearNumber = Convert.ToDouble(data.Substring(19, 7));
            double NegativeEndMoment = Convert.ToDouble(data.Substring(28, 8));
            double PositiveEndAxialNumber = Convert.ToDouble(data.Substring(39, 7));
            double PositiveEndShearNumber = Convert.ToDouble(data.Substring(48, 7));
            double PositiveEndMoment = Convert.ToDouble(data.Substring(58));
            Members.Add(new MemberForce(NegativeEndAxialNumber, NegativeEndShearNumber, NegativeEndMoment, PositiveEndAxialNumber, PositiveEndShearNumber, PositiveEndMoment));
        }
    }
    class MemberForce
    {
        public double NegativeEndAxialNumber { get; set; }
        public double NegativeEndShearNumber { get; set; }
        public double NegativeEndMoment { get; set; }
        public double PositiveEndAxialNumber { get; set; }
        public double PositiveEndShearNumber { get; set; }
        public double PositiveEndMoment { get; set; }
        public MemberForce(double NegativeEndAxialNumber,double NegativeEndShearNumber,double NegativeEndMoment,double PositiveEndAxialNumber,double PositiveEndShearNumber,double PositiveEndMoment)
        {
            this.NegativeEndAxialNumber = NegativeEndAxialNumber;
            this.NegativeEndMoment = NegativeEndMoment;
            this.NegativeEndShearNumber = NegativeEndShearNumber;
            this.PositiveEndAxialNumber = PositiveEndAxialNumber;
            this.PositiveEndMoment = PositiveEndMoment;
            this.PositiveEndShearNumber = PositiveEndShearNumber;
        }
    }
}

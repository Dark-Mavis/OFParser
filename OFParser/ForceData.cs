using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DerivedUnits;
using UnitClassLibrary.ForceUnit;

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
        public double NegativeMomentLBS { get; set; }
        public double PositiveEndAxialNumber { get; set; }
        public double PositiveEndShearNumber { get; set; }
        public double PositiveMomentLBS { get; set; }
        public MemberForce(double NegativeEndAxialNumber,double NegativeEndShearNumber,double NegativeEndMoment,double PositiveEndAxialNumber,double PositiveEndShearNumber,double PositiveEndMoment)
        {
            this.NegativeEndAxialNumber = NegativeEndAxialNumber;
            this.NegativeMomentLBS = NegativeEndMoment;
            this.NegativeEndShearNumber = NegativeEndShearNumber;
            this.PositiveEndAxialNumber = PositiveEndAxialNumber;
            this.PositiveMomentLBS = PositiveEndMoment;
            this.PositiveEndShearNumber = PositiveEndShearNumber;
        }
        public Moment NegativeMoment
        {
            get
            {
                return new Moment(this.NegativeMomentLBS, new PoundInch());
            }
            set
            {
                this.NegativeMomentLBS = value.InPoundInches.Value;
            }
        }
        public Moment PositiveMoment
        {
            get
            {
                return new Moment(this.PositiveMomentLBS, new PoundInch());
            }
            set
            {
                this.PositiveMomentLBS = value.InPoundInches.Value;
            }
        }
    }
}

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
            //in this case, the members always appear in order starting at 0, so reference number doubles as MemberNumber
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
        public double NegativeEndAxialPounds { get; set; }
        public double NegativeEndShearPounds { get; set; }
        public double NegativeMomentPounds { get; set; }
        public double PositiveEndAxialPounds { get; set; }
        public double PositiveEndShearPounds { get; set; }
        public double PositiveMomentPounds { get; set; }
        public MemberForce(double NegativeEndAxialNumber,double NegativeEndShearNumber,double NegativeEndMoment,double PositiveEndAxialNumber,double PositiveEndShearNumber,double PositiveEndMoment)
        {
            this.NegativeEndAxialPounds = NegativeEndAxialNumber;
            this.NegativeMomentPounds = NegativeEndMoment;
            this.NegativeEndShearPounds = NegativeEndShearNumber;
            this.PositiveEndAxialPounds = PositiveEndAxialNumber;
            this.PositiveMomentPounds = PositiveEndMoment;
            this.PositiveEndShearPounds = PositiveEndShearNumber;
        }
        public Moment NegativeMoment
        {
            get
            {
                return new Moment(this.NegativeMomentPounds, new PoundInch());
            }
            set
            {
                this.NegativeMomentPounds = value.InPoundInches.Value;
            }
        }
        public Moment PositiveMoment
        {
            get
            {
                return new Moment(this.PositiveMomentPounds, new PoundInch());
            }
            set
            {
                this.PositiveMomentPounds = value.InPoundInches.Value;
            }
        }
        public Force NegativeEndAxial
        {
            get
            {
                return new Force(new Pound(), NegativeEndAxialPounds);
            }
            set
            {
                this.NegativeEndAxialPounds = value.InPounds.Value;
            }
        }
        public Force NegativeEndShear
        {
            get
            {
                return new Force(new Pound(), NegativeEndShearPounds);
            }
            set
            {
                this.NegativeEndShearPounds = value.InPounds.Value;
            }
        }
        public Force PositiveEndAxial
        {
            get
            {
                return new Force(new Pound(), PositiveEndAxialPounds);
            }
            set
            {
                this.PositiveEndAxialPounds = value.InPounds.Value;
            }
        }
        public Force PositiveEndShear
        {
            get
            {
                return new Force(new Pound(), PositiveEndShearPounds);
            }
            set
            {
                this.PositiveEndShearPounds = value.InPounds.Value;
            }
        }
    }
}

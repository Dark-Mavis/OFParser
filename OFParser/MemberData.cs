using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class MemberData
    {
        public List<Member> Members { get; set; }
        public MemberData()
        {
            Members = new List<Member>();
        }
        private Type enumChecker(char check)
        {
            if (check == 'R')
            {
                return Type.R;
            }
            else if (check == 'F')
            {
                return Type.F;
            }
            else
            {
                return Type.P;
            }
        }
        public void AddMember(string data)
        {
            int NegativeJoint = Convert.ToInt32(data.Substring(12, 2));
            int NegEndFix = Convert.ToInt32(data.Substring(18, 2));
            int PositiveJoint = Convert.ToInt32(data.Substring(25, 2));
            int PosEndFix = Convert.ToInt32(data.Substring(31, 2));
            Type Type = enumChecker(data[39]);
            int AssociatedPieceNumber = Convert.ToInt32(data.Substring(46, 2));
            int LumberNumber = Convert.ToInt32(data.Substring(55, 2));
            int PurlinSpacing = Convert.ToInt32(data.Substring(64, 2));
            Members.Add(new Member(NegativeJoint, NegEndFix, PositiveJoint, PosEndFix, Type, AssociatedPieceNumber, LumberNumber, PurlinSpacing));
        }
    }
    class Member
    {
        public int NegativeJoint { get; set; }
        public int NegEndFix { get; set; }
        public int PositiveJoint { get; set; }
        public int PosEndFix { get; set; }
        public Type Type { get; set; }
        public int AssociatedPieceNumber { get; set; }
        public int LumberNumber { get; set; }
        public int PurlinSpacing { get; set; }
        public Member(int NegativeJoint,int NegEndFix,int PositiveJoint,int PosEndFix, Type Type,int AssociatedPieceNumber,int LumberNumber,int PurlinSpacing)
        {
            this.NegativeJoint = NegativeJoint;
            this.NegEndFix = NegEndFix;
            this.PositiveJoint = PositiveJoint;
            this.PosEndFix = PosEndFix;
            this.Type = Type;
            this.AssociatedPieceNumber = AssociatedPieceNumber;
            this.LumberNumber = LumberNumber;
            this.PurlinSpacing = PurlinSpacing;
        }
    }
}

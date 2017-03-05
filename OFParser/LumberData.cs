using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    public enum MSR
    {
        F
    }
    public enum CW
    {
        W,
        CW,
        P
    }
    class LumberData
    {
        public List<Lumber> Lumbers;
        public LumberData()
        {
            Lumbers = new List<Lumber>();
        }
        public void AddNullLumber()
        {
            Lumber cur = null;
            Lumbers.Add(cur);
        }
        public void AddLumber(string data)
        {
            int Grade = Convert.ToInt32(data.Substring(7, 2));
            double Depth = Convert.ToDouble(data.Substring(11,4));
            double Thick = Convert.ToDouble(data.Substring(16, 4));
            int pointer = 39;
            char fun=data[40];
            if(data[40]!='1' &&data[40]!='2' && data[40] != '3' && data[40] != '4' && data[40] != '5' && data[40] != '6' && data[40] != '7' && data[40] != '8' && data[40] != '9' && data[40] != '0')
            {
                return;
            }
            while(data[pointer]==' ')
            {
                pointer--;
            }
            string Description=data.Substring(21, pointer - 21);
            double E = scientificNumber(data.Substring(40, 9));
            int Fb = Convert.ToInt32(data.Substring(51, 4));
            int Fc = Convert.ToInt32(data.Substring(56, 4));
            int Ft = Convert.ToInt32(data.Substring(61, 4));
            int Fcp = Convert.ToInt32(data.Substring(66, 4));
            int Fv = Convert.ToInt32(data.Substring(71, 4));
            MSR MSR = enumMSRCheck(data[75]);
            CW CW = enumCWCheck(data.Substring(77, 3));
            string SizeName = data.Substring(81);
            Lumbers.Add(new Lumber(Grade, Depth, Thick, Description, E, Fb, Fc, Ft, Fcp, Fb, MSR, CW, SizeName));
        }
        private MSR enumMSRCheck(char check)
        {
            if (check == 'F')
            {
                return MSR.F;
            }
            else
            {
                return MSR.F;
            }
        }
        private CW enumCWCheck(string check)
        {
            if(check==" W ")
            {
                return CW.W;
            }
            else if (check == "C/W")
            {
                return CW.CW;
            }
            else if(check==" P ")
            {
                return CW.P;
            }
            else
            {
                return CW.P;

            }
        }
        private double scientificNumber(string numb)
        {
            double baseNumb = Convert.ToDouble(numb.Substring(0, 4));
            int exp = Convert.ToInt32(numb.Substring(6, 3));
            if (numb[5] == '-')
            {
                for(int i = 0; i < exp; i++)
                {
                    baseNumb = baseNumb / 10;
                }
            }
            else
            {
                for(int i = 0; i < exp; i++)
                {
                    baseNumb = baseNumb * 10;
                }
            }
            return baseNumb;
        }
    }
    class Lumber
    {
        public int Grade { get; set; }
        public double Depth { get; set; }
        public double Thick { get; set; }
        public string Description { get; set; }
        public double E { get; set; }
        public int Fb { get; set; }
        public int Fc { get; set; }
        public int Ft { get; set; }
        public int Fcp { get; set; }
        public int Fv { get; set; }
        public MSR MSR { get; set; }
        public CW CW { get; set; }
        public string SizeName { get; set; }
        public Lumber(int Grade,double Depth,double Thick,string Description,double E,int Fb,int Fc,int Ft,int Fcp,int Fv,MSR MSR,CW CW,string SizeName)
        {
            this.Grade = Grade;
            this.Depth = Depth;
            this.Thick = Thick;
            this.Description = Description;
            this.E = E;
            this.Fb = Fb;
            this.Fc = Fc;
            this.Ft = Ft;
            this.Fcp = Fcp;
            this.Fv = Fv;
            this.MSR = MSR;
            this.CW = CW;
            this.SizeName = SizeName;
        }
    }
}

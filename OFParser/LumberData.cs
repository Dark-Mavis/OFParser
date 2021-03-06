﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DerivedUnits.StressUnit;
using UnitClassLibrary.DistanceUnit;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;

namespace OFParser
{
    //these enums have all the types I saw, there are probably more
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
        public bool AddLumber(string data)
        {
            //this if is to check that E is starting when it's supposed to
            if(data[40]!='1' &&data[40]!='2' && data[40] != '3' && data[40] != '4' && data[40] != '5' && data[40] != '6' && data[40] != '7' && data[40] != '8' && data[40] != '9' && data[40] != '0')
            {
                return false;
            }
            int LumberNumber = Convert.ToInt32(data.Substring(3, 2));
            int Grade = Convert.ToInt32(data.Substring(7, 2));
            double Depth = Convert.ToDouble(data.Substring(11,4));
            double Thick = Convert.ToDouble(data.Substring(16, 4));
            int pointer = 39;
            char fun=data[40];
            while(data[pointer]==' ')
            {
                pointer--;
            }
            string Description=data.Substring(21, pointer - 21);
            int E = scientificNumber(data.Substring(40, 9));
            int Fb = Convert.ToInt32(data.Substring(51, 4));
            int Fc = Convert.ToInt32(data.Substring(56, 4));
            int Ft = Convert.ToInt32(data.Substring(61, 4));
            int Fcp = Convert.ToInt32(data.Substring(66, 4));
            int Fv = Convert.ToInt32(data.Substring(71, 4));
            MSR MSR = enumMSRCheck(data[75]);
            CW CW = enumCWCheck(data.Substring(77, 3));
            pointer = 81;
            while(data[pointer]!=' ')
            {
                pointer++;
            }
            string SizeName = data.Substring(81,pointer-81);
            Lumbers.Add(new Lumber(LumberNumber,Grade, Depth, Thick, Description, E, Fb, Fc, Ft, Fcp, Fb, MSR, CW, SizeName));
            return true;
        }
        public void AddLumberDoubleRow(string data1,string data2)
        {
            //data1 is the first line, data2 is the second
            int LumberNumber = Convert.ToInt32(data1.Substring(3, 2));
            int Grade = Convert.ToInt32(data1.Substring(7, 2));
            double Depth = Convert.ToDouble(data1.Substring(11, 4));
            double Thick = Convert.ToDouble(data1.Substring(16, 4));
            string Description = data1.Substring(21);
            int E = scientificNumber(data2.Substring(42, 9));
            int Fb = Convert.ToInt32(data2.Substring(53, 4));
            int Fc = Convert.ToInt32(data2.Substring(58, 4));
            int Ft = Convert.ToInt32(data2.Substring(63, 4));
            int Fcp = Convert.ToInt32(data2.Substring(68, 4));
            int Fv = Convert.ToInt32(data2.Substring(73, 4));
            MSR MSR = enumMSRCheck(data2[77]);
            CW CW = enumCWCheck(data2.Substring(79, 3));
            int pointer = 83;
            while (data2[pointer] != ' ')
            {
                pointer++;
            }
            string SizeName = data2.Substring(81, pointer - 83);
            Lumbers.Add(new Lumber(LumberNumber,Grade, Depth, Thick, Description, E, Fb, Fc, Ft, Fcp, Fb, MSR, CW, SizeName));
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
        private int scientificNumber(string numb)
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
            return (int)baseNumb;
        }
    }
    class Lumber
    {
        public int LumberNumber { get; set; }
        public int Grade { get; set; }
        public double DepthInches { get; set; }
        public double ThickInches { get; set; }
        public string Description { get; set; }
        public int EPSI { get; set; }
        public int FbPSI { get; set; }
        public int FcPSI { get; set; }
        public int FtPSI { get; set; }
        public int FcpPSI { get; set; }
        public int FvPSI { get; set; }
        public MSR MSR { get; set; }
        public CW CW { get; set; }
        public string SizeName { get; set; }
        public Lumber(int LumberNumber,int Grade,double Depth,double Thick,string Description,int E,int Fb,int Fc,int Ft,int Fcp,int Fv,MSR MSR,CW CW,string SizeName)
        {
            this.LumberNumber = LumberNumber;
            this.Grade = Grade;
            this.DepthInches = Depth;
            this.ThickInches = Thick;
            this.Description = Description;
            this.EPSI = E;
            this.FbPSI = Fb;
            this.FcPSI = Fc;
            this.FtPSI = Ft;
            this.FcpPSI = Fcp;
            this.FvPSI = Fv;
            this.MSR = MSR;
            this.CW = CW;
            this.SizeName = SizeName;
        }
        public Distance Depth
        {
            get
            {
                return new Distance(new Inch(), this.DepthInches);
            }
            set
            {
                this.DepthInches = value.ValueInInches;
            }
        }
        public Distance Thick
        {
            get
            {
                return new Distance(new Inch(), this.ThickInches);
            }
            set
            {
                this.ThickInches = value.ValueInInches;
            }
        }
        public Stress E
        {
            get
            {
                return new Stress(new PoundPerSquareInch(), EPSI);
            }
            set
            {
                this.EPSI = (int)value.InPSI.Value;
            }
        }
        public Stress Fb
        {
            get
            {
                return new Stress(new PoundPerSquareInch(), FbPSI);
            }
            set
            {
                this.FbPSI = (int)value.InPSI.Value;
            }
        }
        public Stress Fc
        {
            get
            {
                return new Stress(new PoundPerSquareInch(), FcPSI);
            }
            set
            {
                this.FcPSI = (int)value.InPSI.Value;
            }
        }
        public Stress Ft
        {
            get
            {
                return new Stress(new PoundPerSquareInch(), FtPSI);
            }
            set
            {
                this.FtPSI = (int)value.InPSI.Value;
            }
        }
        public Stress Fcp
        {
            get
            {
                return new Stress(new PoundPerSquareInch(), FcpPSI);
            }
            set
            {
                this.FcpPSI = (int)value.InPSI.Value;
            }
        }
        public Stress Fv
        {
            get
            {
                return new Stress(new PoundPerSquareInch(), FvPSI);
            }
            set
            {
                this.FvPSI = (int)value.InPSI.Value;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFParser
{
    class OFParser
    {
        private ArrayList file = new ArrayList();
        private string version { get; set; }
        private DateTime dateAndTime { get; set; }
        private string jobKey { get; set; }
        private string jobDescription { get; set; }
        private string trussDescription { get; set; }
        private string[] data;

        private MiscData MiscDataBlock { get; set; }
        public OFParser(string location)
        {
            createData(location);
        }
        private void readInFile(string location)
        {
            using (StreamReader sr = File.OpenText(location))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    file.Add(s);
                }
            }
        }
        private void createData(string location)
        {
            readInFile(location);
            data = new string[file.Count];
            for (int i = 0; i < file.Count; i++)
            {
                data[i] = (string)file[i];
            }
            version = data[3].Substring(38, 53);
            int month = monthCapture(data[6].Substring(17, 19));
            dateAndTime = new DateTime(Convert.ToInt32(data[6].Substring(33,36)),month, Convert.ToInt32(data[6].Substring(21, 22)), Convert.ToInt32(data[6].Substring(24, 25)), Convert.ToInt32(data[6].Substring(26, 27)), Convert.ToInt32(data[6].Substring(28, 29)));
            jobKey = data[8].Substring(27, 37);
            jobDescription = data[8].Substring(41);
            trussDescription = data[8].Substring(19);
        }
        private int monthCapture(string month)
        {
            if (month == "Jan")
            {
                return 1;
            }
            else if (month == "Feb")
            {
                return 2;
            }
            else if (month == "Mar")
            {
                return 3;
            }
            else if (month == "Apr")
            {
                return 4;
            }
            else if (month == "May")
            {
                return 5;
            }
            else if (month == "Jun")
            {
                return 6;
            }
            else if (month == "Jul")
            {
                return 7;
            }
            else if (month == "Aug")
            {
                return 8;
            }
            else if (month == "Sep")
            {
                return 9;
            }
            else if (month == "Oct")
            {
                return 10;
            }
            else if (month == "Nov")
            {
                return 11;
            }
            else if (month == "Dec")
            {
                return 12;
            }
            Console.Out.Write("Something wrong");
            return 15;
        }
        public static void Main(string[] args)
        {
            OFParser fred = new OFParser("C:/Users/Cerullium/OneDrive/Work/OFParser/OF Parser/OF_File_Examples/T20.OF");
        }
    }
}

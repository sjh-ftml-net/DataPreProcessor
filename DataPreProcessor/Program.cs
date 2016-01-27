using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPreProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader infile = new System.IO.StreamReader("C:\\Users\\simon.heathfield\\Documents\\USR\\@Working_copy\\HA_Data\\AE_SUS.csv");
            System.IO.StreamWriter outfile = new System.IO.StreamWriter("C:\\Users\\simon.heathfield\\Documents\\USR\\@Working_copy\\HA_Data\\ae_sus_op.csv");
            System.IO.StreamWriter sqlfile = new System.IO.StreamWriter("C:\\Users\\simon.heathfield\\Documents\\USR\\@Working_copy\\HA_Data\\tab.sql");
            while ((line = infile.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    // Headerline
                    string[] words = line.Split(',');
                    int tot = words.Length;
                    sqlfile.WriteLine("CREATE TABLE data_tab (");
                    int cnum = 1;
                    foreach (string s in words)
                    {
                        sqlfile.Write(s);
                        if (cnum == tot-1)
                            sqlfile.WriteLine(" VARCHAR(100),");
                        else
                            sqlfile.WriteLine(" VARCHAR(100),");
                        cnum++;                       
                    }
                    sqlfile.WriteLine(")");
                }
                else
                {
                    string[] words = line.Split(',');

                    foreach (string s in words)
                    {
                        outfile.Write(s);
                    }
                    //outfile.WriteLine(")");
                }

                counter++;
            }
            Console.WriteLine(counter);

            infile.Close();
            outfile.Close();
            sqlfile.Close();

            // Suspend the screen.
            Console.ReadLine();
        }
    }
}

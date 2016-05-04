using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    public class PeopleOutputReader
    {
        public string[,] CommaDelimitedLines(string text, int expectedLines, int expectedColumns)
        {
            string[,] lines = new string[expectedLines, expectedColumns];
            int lineNo = 0;
            Encoding encoding = Encoding.UTF8;

            using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(text.ToCharArray())))
            {
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    string read = null;
                    while ((read = reader.ReadLine()) != null)
                    {
                        string[] columnData = read.Split(new char[] {','}, StringSplitOptions.None);
                        for (int i = 0; i < columnData.Length; i++)
                        {
                            lines[lineNo, i] = columnData[i];
                        }
                        lineNo++;
                    }
                }
            }

            return lines;
        }
    }
}

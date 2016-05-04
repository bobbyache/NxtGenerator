using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    public static class DatasetLoader
    {
        public static DataTable LoadFileData(string filePath)
        {
            if (File.Exists(filePath))
            {
                DataSet dataSet = new DataSet();

                dataSet.ReadXml(filePath);
                return dataSet.Tables[0];
            }
            return null;
        }
    }
}

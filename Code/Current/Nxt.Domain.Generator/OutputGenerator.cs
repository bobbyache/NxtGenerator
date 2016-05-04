using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxt.Domain.Generator
{
    public class OutputGenerator
    {
        public DataTable DataTable { get; private set; }
        public string BlueprintText { get; private set; }

        public string PlaceholderPrefix { get; set; }
        public string PlaceholderPostfix { get; set; }


        public OutputGenerator(DataTable dataTable, string blueprintText)
        {
            this.DataTable = dataTable;
            this.BlueprintText = blueprintText;
            this.PlaceholderPrefix = "@{";
            this.PlaceholderPostfix = "}";
        }

        public string Generate()
        {
            string generatedText = "";
            
            // for each row in the table...
            for (int y = 0; y < this.DataTable.Rows.Count; y++)
            {
                string blueprintText = this.BlueprintText;

                foreach (DataColumn column in this.DataTable.Columns)
                {
                    // retrieve the text
                    string columnData = Convert.ToString(this.DataTable.Rows[y][column]);
                    string placeholder = string.Format("{0}{1}{2}", this.PlaceholderPrefix, column.ColumnName, this.PlaceholderPostfix);

                    blueprintText = blueprintText.Replace(placeholder, columnData);
                }

                generatedText += blueprintText;
            }

            return generatedText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nxt.Infrastructure
{
    public interface IDataSource
    {
        string Id { get; set; }
        string SourceTypeText { get; }
        string TableName { get; }
        string ProjectFilePath { get; set; }
        string DatasetFilePath { get; }
        string Title { get; set; }
        bool SourceIsValid();
        object CurrentData { get; }
        void FetchData();
        void LoadFileData();
        void DeleteFileData();
        void WriteFileData();
        void LoadFileData(bool selectableRows);

        bool DataExists();

    }
}

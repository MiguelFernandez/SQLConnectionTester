using System.Collections.Generic;

namespace SQLConnectionTest.Models
{
    public class SQLTest
    {
        public List<string> ColumnNames { get;} = new List<string>();
        public List<string> Rows { get; } = new List<string>();       
        public SQLConnectionString ConnectionString { get; set; } = new SQLConnectionString();
        public string ErrorMessage { get; set; } = string.Empty;
        public string InformationMessage { get; set; } = string.Empty;
        
    }
}

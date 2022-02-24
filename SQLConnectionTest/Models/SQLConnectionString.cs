namespace SQLConnectionTest.Models
{
    public class SQLConnectionString
    {
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Server { get; set; } 
        public string InitialCatalog { get; set; }
        public bool TrustServerCertificate { get; set; }
        public bool MultipleActiveResultSets { get; set; }
        public bool Encrypt { get; set; }
        public string TableName { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
        public string FullConnectionString
        {
            get
            {
                if (AuthenticationType == AuthenticationType.SQLCredentials)
                {
                    return $"Server={Server},1433;Initial Catalog={InitialCatalog};Persist Security Info=False;User ID={Username};Password={Password};MultipleActiveResultSets={MultipleActiveResultSets};Encrypt={Encrypt};TrustServerCertificate={TrustServerCertificate};";
                }


                return $"Server={Server},1433;Initial Catalog={InitialCatalog};Persist Security Info=False;User ID={Username};Password={Password};MultipleActiveResultSets={MultipleActiveResultSets};Encrypt={Encrypt};TrustServerCertificate={TrustServerCertificate};Authentication=\"{AuthenticationType.GetDisplayName()}\";";
            }
        }
    }
}

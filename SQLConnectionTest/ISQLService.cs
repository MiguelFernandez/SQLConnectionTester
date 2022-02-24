using SQLConnectionTest.Models;

namespace SQLConnectionTest
{
    public interface ISQLService
    {
        void Connect(SQLTest sQLConnectionTest);
    }
}
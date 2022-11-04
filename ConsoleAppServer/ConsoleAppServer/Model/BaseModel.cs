using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleAppServer.Model
{
    public class BaseModel
    {
        protected string _connstr = ConfigurationManager.ConnectionStrings["SqlStr"].ConnectionString;
        protected SqlConnection _cndb;
        protected SqlConnection _cndbDouble;
        protected BaseModel()
        {
            this._cndb = new SqlConnection(_connstr);
            this._cndbDouble = new SqlConnection(_connstr);
        }
    }
}

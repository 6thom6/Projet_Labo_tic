using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository
{
    class CentreEntrainementRepo
    {
        public SqlConnection connection;
        public CentreEntrainementRepo()
        {
            connection = new SqlConnection(ConnectionStringService.ConnString);
        }
    }
}

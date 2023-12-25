using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace UsersApi.Data;

public class DataContextDapper
{
    private IConfiguration _config;

    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }
    
    public T LoadDataSingle<T>(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingle<T>(sql);
    }
}
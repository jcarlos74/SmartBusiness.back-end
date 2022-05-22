using System.Data;

namespace SmartBusiness.Infra.Data
{
    public interface IDbSession
    {
         IDbConnection Connection { get; }
         IDbTransaction Transaction { get; set; }
         string Schema { get; set; }   
    }
}

using System.Data;
using System.Threading.Tasks;

namespace SmartBusiness.Identity.Interfaces
{
    /// <summary>
    /// Responsável por retornar a conexão do banco de dados
    /// </summary>
    public interface IDatabaseConnectionFactory
    {
        /// <summary>
        /// Retorna Conexão de Banco de Dados
        /// </summary>
        /// <returns></returns>
        Task<IDbConnection> CreateConnectionAsync();
    }
}

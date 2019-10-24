using DoAn.Data.Infrastructure;
using DoAn.Data.Model;
using System;
using System.Data.SqlClient;

namespace DoAn.Data.Repository
{
    public interface IWaringProfileRepository : IRepository<WarningProfile>
    {
    }

    public class WarningProfileRepository : RepositoryBase<WarningProfile>, IWaringProfileRepository
    {
        public WarningProfileRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
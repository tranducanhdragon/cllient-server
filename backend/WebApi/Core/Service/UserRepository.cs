using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class User
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
    public interface IUserRepository : IBaseRepository<User>
    {
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(
            NKSLKContext dbContext) : base(dbContext)
        {

        }
    }
}

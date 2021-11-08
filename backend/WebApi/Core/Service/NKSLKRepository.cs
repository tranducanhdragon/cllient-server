using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Service
{
   
    public interface INKSLKRepository : IBaseRepository<Nkslk>
    {
        bool DeleteNKSLK(int ma);
    }
    public class NKSLKRepository : BaseRepository<Nkslk>, INKSLKRepository
    {
        private NKSLKContext _NKSLKContext;

        public NKSLKRepository(NKSLKContext context) : base(context)
        {
            _NKSLKContext = context;
        }
        public bool DeleteNKSLK(int ma)
        {
            throw new NotImplementedException();
        }
    }
}

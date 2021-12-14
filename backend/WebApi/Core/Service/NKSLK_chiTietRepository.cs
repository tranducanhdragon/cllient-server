using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Service
{

    public interface INKSLK_chiTietRepository : IBaseRepository<NkslkChiTiet>
    {
        bool DeleteNKSLK(int ma);
    }
    public class INKSLKChiTietRepository : BaseRepository<NkslkChiTiet>, INKSLK_chiTietRepository
    {
        private NKSLKContext _NKSLKContext;

        public INKSLKChiTietRepository(NKSLKContext context) : base(context)
        {
            _NKSLKContext = context;
        }
        public bool DeleteNKSLK(int ma)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Core.Base;
using EntityFramework.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{

    public interface ISanPhamRepository:IBaseRepository<SanPham>
    {
        bool DeleteSanPham(int maSanPham);
    }
    class SanPhamRepository : BaseRepository<SanPham>, ISanPhamRepository
    {
        private NKSLKContext _nhancongContext;
        public SanPhamRepository(NKSLKContext context) : base(context)
        {
            _nhancongContext = context;
        }

        public bool DeleteSanPham(int maSanPham)
        {
            throw new NotImplementedException();
        }
    }
}

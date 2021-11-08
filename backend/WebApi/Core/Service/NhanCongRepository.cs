using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface INhanCongRepository:IBaseRepository<NhanCong>
    {
        bool DeleteNhanCong(int manhancong);
    }
    public class NhanCongRepository : BaseRepository<NhanCong>, INhanCongRepository
    {
        private NKSLKContext _nhancongContext;
        public NhanCongRepository(NKSLKContext context) : base(context)
        {
            _nhancongContext = context;
        }
        public bool DeleteNhanCong(int manhancong)
        {
            try
            {
                var nc = _nhancongContext.NhanCongs.Find(manhancong) as NhanCong;
                _nhancongContext.NhanCongs.Remove(nc);
                _nhancongContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
    }
}

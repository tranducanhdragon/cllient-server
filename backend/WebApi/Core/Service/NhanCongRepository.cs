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

    }
    public class NhanCongRepository : BaseRepository<NhanCong>, INhanCongRepository
    {
        public NhanCongRepository(NKSLKContext context) : base(context)
        {

        }
    }
}

using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
  

    public interface ICongViecRepository : IBaseRepository<CongViec>
    {
        bool DeleteCongViec(int maCongViec);
    }
    class CongViecRepository : BaseRepository<CongViec>, ICongViecRepository
    {
        private NKSLKContext _nhancongContext;
        public CongViecRepository(NKSLKContext context) : base(context)
        {
            _nhancongContext = context;
        }

        public bool DeleteCongViec(int maCongViec)
        {
            throw new NotImplementedException();
        }
    }
}

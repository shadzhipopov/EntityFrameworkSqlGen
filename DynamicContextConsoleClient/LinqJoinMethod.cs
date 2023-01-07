using DynamicContextConsoleClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicContextConsoleClient
{
    public class LinqJoinMethod
    {
        private readonly BookShopApiContext db;

        public LinqJoinMethod(BookShopApiContext db)
        {
            this.db = db;
        }

        public void CreateQuery()
        {

            IQueryable<BusinessModule> a = db.BusinessModules.AsQueryable();
            var ob = a.Join(db.BusinessObjects, c => c.Id, c => c.BusinessModuleId, (bm, bo) => bo);
            var bp = ob.Join(db.BusinessProperties, c => c.Id, c => c.BusinessObjectId, (bo, bp) => bp.OrderIndex);

            var joinQuery = db.BusinessModules.Select(bm => new
            {
                bm.Id,
                Objects = bm.BusinessObjects.Count(),
                AverageOrderIndex = db.BusinessObjects.Where(c => c.BusinessModuleId == bm.Id)
                .Join(db.BusinessProperties, c => c.Id, c => c.BusinessObjectId, (bo, bp) => bp.OrderIndex)
                .Average()
            });

            var sql = joinQuery.ToQueryString();


        }
    }
}

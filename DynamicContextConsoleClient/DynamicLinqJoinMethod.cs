using DynamicContextConsoleClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace DynamicContextConsoleClient
{
    public class DynamicLinqJoinMethod
    {
        private readonly BookShopApiContext db;

        public DynamicLinqJoinMethod(BookShopApiContext db)
        {
            this.db = db;
        }

        public void CreateQuery()
        {

            var joinQuery = db.BusinessModules.Select(bm => new
            {
                bm.Id,
                Objects = bm.BusinessObjects.Count(),
                AverageOrderIndex = db.BusinessObjects.Where(c => c.BusinessModuleId == bm.Id)
                .Join(db.BusinessProperties, "Id", "BusinessObjectId", "outer")
                .Average()
            });

            var sql = joinQuery.ToQueryString();


        }


    }
}

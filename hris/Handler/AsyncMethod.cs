using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace hris.Handler
{
    public class AsyncMethod
    {
        public Task UpdateWorkdaysAndAge(int id)
        {
            return Task.Run(() =>
            {
                using (var context = new hrisEntities())
                {
                    context.Get_Workdays(id);
                    context.Get_Age(id);
                }
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace hris.DAL
{
    public class EmployeeConfiguration : DbConfiguration
    {
        public EmployeeConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());

        }
    }
}
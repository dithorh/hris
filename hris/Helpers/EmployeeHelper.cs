using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using hris.Models;
using System.Configuration;
using System.Data;
using Dapper;
using System.Web.Mvc;
using System.Data.Entity;

namespace hris.Helpers
{
    public class EmployeeHelper : Handler.IPagination<karyawan>
    {
        private EmployeeContext db = new EmployeeContext();

        public List<SelectListItem> GetDropDownList(string table, string valueName, string id = "")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString))
            {
                string qry = "SELECT * FROM " + table;
                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = "",
                            Value = "Pilih"
                        });

                        while (dr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = dr["id"].ToString(),
                                Value = dr[valueName].ToString(),
                                Selected = (dr["id"].ToString() == id ? true : false)
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return items;
        }

        public IQueryable<karyawan> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered)
        {
            var data = db.karyawan.AsQueryable();
            totalRecords = data.Count();

            if (!string.IsNullOrEmpty(filter))
            {
                data = data.Where(x => x.NAMA_LENGKAP.ToUpper().Contains(filter.ToUpper()));
            }

            recordsFiltered = data.Count();
            data = data.OrderBy(x => x.NAMA_LENGKAP)
                .Skip((initialPage * pageSize))
                .Take(pageSize);

            return data;
        }
    }
}
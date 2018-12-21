using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using hris.Models;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;

namespace hris.Helpers
{
    public class HRISHelper : Handler.IPagination<karyawan>
    {
        private HRISContext db = new HRISContext();

        public List<SelectListItem> GetDropDownList(string table, string valueName, string id = "")
        {
            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRISContext"].ConnectionString))
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

        public List<SelectListItem> GetDropDownList(string table, int id = -1)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            switch (table)
            {
                case "divisi":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_divisi.Select(s => new SelectListItem
                        {
                            Text = s.divisi_id.ToString(),
                            Value = s.nama_divisi,
                            Selected = (s.divisi_id == id ? true : false)
                        })
                    ).ToList();
                    break;
                case "cctr":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_cctr.Select(s => new SelectListItem
                        {
                            Text = s.cctr_id.ToString(),
                            Value = s.cctr,
                            Selected = (s.cctr_id == id ? true : false)
                        })
                    ).ToList();
                    break;
                case "jabatan":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_gol_jabatan.Select(s => new SelectListItem
                        {
                            Text = s.gol_jabatan_id.ToString(),
                            Value = s.nama_jabatan,
                            Selected = (s.gol_jabatan_id == id ? true : false)
                        })
                    ).ToList();
                    break;
                case "lvljabatan":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_lvl_jabatan.Select(s => new SelectListItem
                        {
                            Text = s.lvl_jabatan_id.ToString(),
                            Value = s.lvl_jabatan,
                            Selected = (s.lvl_jabatan_id == id ? true : false)
                        })
                    ).ToList();
                    break;
                case "sublvljabatan":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_sub_lvl_jabatan.Select(s => new SelectListItem
                        {
                            Text = s.sub_lvl_jabatan_id.ToString(),
                            Value = s.sub_lvl_jabatan,
                            Selected = (s.sub_lvl_jabatan_id == id ? true : false)
                        })
                    ).ToList();
                    break;
                case "status":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_status_karyawan.Select(s => new SelectListItem
                        {
                            Text = s.status_karyawan_id.ToString(),
                            Value = s.status_karyawan,
                            Selected = (s.status_karyawan_id == id ? true : false)
                        })
                    ).ToList();
                    break;
                case "lokasi":
                    items = new[] { new SelectListItem { Text = "-1", Value = "Pilih", Selected = true } }
                    .Concat(
                        db.ref_lokasi_kerja.Select(s => new SelectListItem
                        {
                            Text = s.lokasi_kerja_id.ToString(),
                            Value = s.nama_lokasi,
                            Selected = (s.lokasi_kerja_id == id ? true : false)
                        })
                    ).ToList();
                    break;
            }

            return items;
        }

        public IQueryable<karyawan> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered)
        {
            var data = db.karyawan.AsQueryable();
            totalRecords = data.Count();

            if (!string.IsNullOrEmpty(filter))
            {
                data = data.Where(x => x.nama_karyawan.ToUpper().Contains(filter.ToUpper()));
            }

            recordsFiltered = data.Count();
            data = data.OrderBy(x => x.nama_karyawan)
                .Skip((initialPage * pageSize))
                .Take(pageSize);

            return data;
        }
    }
}
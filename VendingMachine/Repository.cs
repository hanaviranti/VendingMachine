using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendingMachine.DTO;

namespace VendingMachine
{
    internal class Repository
    {
        public List<barang> GetAllBarang()
        {
            var conStr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (var con = new SqlConnection(conStr))
            {
                return con.Query<barang>("SELECT * FROM tabel_barang").AsList();
            }
        }

        public barang GetBarang(string nama_barang)
        {
            var conStr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (var con = new SqlConnection(conStr))
            {
                var parameters = new { nama_barang = nama_barang };
                var sql = "SELECT * FROM tabel_barang where nama_barang = @nama_barang";
                var result = con.QuerySingle<barang>(sql, parameters);

                return result;
            }
        }


        public void setStokmin(string nama_barang)
        {
            var conStr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (var con = new SqlConnection(conStr))
            {
                var parameters = new { nama_barang = nama_barang };
                var sql = "UPDATE tabel_barang set stock = stock-1 where nama_barang = @nama_barang";
                var result = con.Query(sql, parameters);

               
            }
        }

        public void setStokplus(string nama_barang)
        {
            var conStr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (var con = new SqlConnection(conStr))
            {
                var parameters = new { nama_barang = nama_barang };
                var sql = "UPDATE tabel_barang set stock = stock+1 where nama_barang = @nama_barang";
                var result = con.Query(sql, parameters);


            }
        }


    }
}

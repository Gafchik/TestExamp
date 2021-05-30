using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLib
{
    public class Admin1
    {
        public int Admin_ID { get; set; }
        public string Admin_Login { get; set; }
        public string Admin_Pass { get; set; }
    }
    public static class Admin_Repository
    {
        static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;Admin Id=db_a736b5_foodeliverydb123_admin;Password=QQddRRvv1";

        public static void Create(Admin1 value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Admin_INSERT] @Login , @Pass ";
                        var values = new { Login = value.Admin_Login, Pass = value.Admin_Pass };
                        db.Query(sql, values);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(Admin1 value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Admin_DELETE] @ID";
                        var values = new { ID = value.Admin_ID };
                        db.Query(sql, values);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }



        public static IEnumerable<Admin1> Select()
        {
            List<Admin1> coll = new List<Admin1>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Admin_SELECT]";
                        coll = db.Query<Admin1>(sql, transaction).ToList();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            return coll;
        }

        public static void Update(Admin1 value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Admin_UPDATE] @ID ,@Login , @Pass";
                        var values = new { ID = value.Admin_ID, Login = value.Admin_Login, Pass = value.Admin_Pass };
                        db.Query(sql, values);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}



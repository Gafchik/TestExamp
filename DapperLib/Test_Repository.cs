using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLib
{
    public class Test
    {
        public int Test_ID { get; set; }
        public int Test_Category_ID { get; set; }
        public string Test_Name { get; set; }

    }
    public static class Test_Repository
    {
        static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;User Id=db_a736b5_foodeliverydb123_admin;Password=QQddRRvv1";

        public static void Create(Test value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Test_INSERT] @Name ";
                        var values = new { Name = value.Test_Name };
                        db.Query(sql, values, transaction);
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

        public static void Delete(Test value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Test_DELETE] @ID";
                        var values = new { ID = value.Test_ID };
                        db.Query(sql, values, transaction);
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



        public static IEnumerable<Test> Select()
        {
            List<Test> coll = new List<Test>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               
                    try
                    {
                    db.Open();
                        var sql = "exec [Test_SELECT]";
                        coll = db.Query<Test>(sql ).ToList();
                       
                    }
                    catch (Exception ex)
                    {
                        
                        throw ex;
                    }
                
            }
            return coll;
        }

        public static void Update(Test value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Test_UPDATE] @ID ,@Name";
                        var values = new { ID = value.Test_ID, Name = value.Test_Name };
                        db.Query(sql, values, transaction);
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



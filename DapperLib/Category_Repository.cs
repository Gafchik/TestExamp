using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLib
{
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
    
    }
    public static class Category_Repository
    {
        static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;User Id=db_a736b5_foodeliverydb123_admin;Password=QQddRRvv1";

        public static void Create(Category value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Category_INSERT]@Name ";
                        var values = new { Name = value.Category_Name };
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

        public static void Delete(Category value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Category_DELETE] @ID";
                        var values = new { ID = value.Category_ID };
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



        public static IEnumerable<Category> Select()
        {
            List<Category> coll = new List<Category>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               
                    try
                    {
                    db.Open();
                        var sql = "exec [Category_SELECT]";
                        coll = db.Query<Category>(sql).ToList();                     
                    }
                    catch (Exception ex)
                    { 
                        throw ex;
                    }
                
            }
            return coll;
        }

        public static void Update(Category value, string New_Name)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Category_UPDATE] @ID ,@Name";
                        var values = new { ID = value.Category_ID, Name = New_Name };
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



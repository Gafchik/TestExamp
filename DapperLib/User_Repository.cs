using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLib
{
    public class User1
    {
        public int User_ID { get; set; }
        public string User_Login { get; set; }
        public string User_Pass { get; set; }
    }
    public static class User_Repository
    {
       static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;User Id=db_a736b5_foodeliverydb123_admin;Password=QQddRRvv1";

        public static void Create(User1 value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [User_INSERT] @Login , @Pass ";
                        var values = new { Login = value.User_Login, Pass = value.User_Pass };
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

        public static void Delete(User1 value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [User_DELETE] @ID";
                        var values = new { ID = value.User_ID};
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

        

        public static IEnumerable<User1> Select()
        {
            List<User1> coll = new List<User1>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [User_SELECT]";                      
                        coll = db.Query<User1>(sql, transaction).ToList();                        
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

        public static void Update(User1 value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [User_UPDATE] @ID ,@Login , @Pass";
                        var values = new { ID = value.User_ID, Login = value.User_Login, Pass = value.User_Pass };
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



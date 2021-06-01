using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLib
{
    public class Answer
    {       
        public int Answer_ID { get; set; }
        public int Answer_Question_ID { get; set; }
        public int Answer_True { get; set; }
        public string Answer_True_txt { get; set; }
        public string Answer_Text { get; set; }

    }
    public static class Answer_Repository
    {
        static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;User Id=db_a736b5_foodeliverydb123_admin;Password=QQddRRvv1";

        public static void Create(Answer value, int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_INSERT] @Text, @Id ";
                        var values = new { Text = value.Answer_Text, Id = id };
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

        public static void Create_True(Answer value, int id,bool flag)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_INSERT_True] @Text, @Id, @True ";
                        var values = new { Text = value.Answer_Text, Id = id, True = flag };
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

        public static void Delete(Answer value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_DELETE] @ID";
                        var values = new { ID = value.Answer_ID };
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



        public static IEnumerable<Answer> Select()
        {
            List<Answer> coll = new List<Answer>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                try
                {
                    db.Open();
                    var sql = "exec [Answer_SELECT]";
                    coll = db.Query<Answer>(sql).ToList();

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return coll;
        }

        public static void Update(Answer value, string new_txt, bool flag)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_UPDATE] @ID, @Text, @True";
                        var values = new { ID = value.Answer_ID, Text = new_txt, @True =flag };
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
        public static void Update(Answer value, string new_txt)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_UPDATE] @ID, @Text, @True";
                        var values = new { ID = value.Answer_ID, True = false, Text = new_txt };
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



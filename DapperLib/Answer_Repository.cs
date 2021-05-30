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
        public string Answer_Text { get; set; }

    }
    public static class Answer_Repository
    {
        static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;Answer Id=db_a736b5_foodeliverydb123_Answer;Password=QQddRRvv1";

        public static void Create(Answer value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_INSERT] @Text ";
                        var values = new { Text = value.Answer_Text };
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



        public static IEnumerable<Answer> Select()
        {
            List<Answer> coll = new List<Answer>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_SELECT]";
                        coll = db.Query<Answer>(sql, transaction).ToList();
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

        public static void Update(Answer value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Answer_UPDATE] @ID , @Text";
                        var values = new { ID = value.Answer_ID, Text = value.Answer_Text };
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



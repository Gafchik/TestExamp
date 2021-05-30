using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLib
{
    public class Question
    {
        public int Question_ID { get; set; }
        public int Question_Test_ID { get; set; }
        public string Question_Text { get; set; }

    }
    public static class Question_Repository
    {
        static string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a736b5_foodeliverydb123;User Id=db_a736b5_foodeliverydb123_admin;Password=QQddRRvv1";

        public static void Create(Question value,int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Question_INSERT] @Text, @Id ";
                        var values = new { Text = value.Question_Text, Id = id };
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

        public static void Delete(Question value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Question_DELETE] @ID";
                        var values = new { ID = value.Question_ID };
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



        public static IEnumerable<Question> Select()
        {
            List<Question> coll = new List<Question>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                try
                {
                    db.Open();
                    var sql = "exec [Question_SELECT]";
                    coll = db.Query<Question>(sql).ToList();

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return coll;
        }

        public static void Update(Question value)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var sql = "exec [Question_UPDATE] @ID , @Text";
                        var values = new { ID = value.Question_ID, Text = value.Question_Text };
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



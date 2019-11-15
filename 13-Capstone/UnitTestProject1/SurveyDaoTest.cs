using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Transactions;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class SurveyDaoTests
    {
        protected string ConnectionString { get; } = "Data Source =.\\sqlexpress;Initial Catalog = NPGeek; Integrated Security = True";
        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void Survey_Should_Increase_Count_By_1()
        {
            Survey post = new Survey();
            post.ParkCode = "GNP";
            post.ActivityLevel = "Active";
            post.Email = "test@yahoo.com";
            post.State = "OH";
            SurveyDao dao = new SurveyDao(ConnectionString);
            int startingRowCount = GetRowCount("survey_result");

            dao.SaveNewSurvey(post);

            int endingRowCount = GetRowCount("survey_result");
            Assert.AreEqual(startingRowCount + 1, endingRowCount);
        }
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
        [TestMethod]
        public void Top_Survey_Is_Not_Null()
        {
            {
                Survey post = new Survey();
                post.ParkCode = "GNP";
                post.ActivityLevel = "Active";
                post.Email = "test@yahoo.com";
                post.State = "OH";
                SurveyDao dao = new SurveyDao(ConnectionString);

                dao.SaveNewSurvey(post);
                List<Survey> result = (List<Survey>)dao.GetTopSurveys();
                List<Survey> expected = new List<Survey>();

                CollectionAssert.AreNotEqual(result, expected);
            }

        }
    }
}

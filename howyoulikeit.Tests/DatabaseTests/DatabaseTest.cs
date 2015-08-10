using howyoulikeit.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace howyoulikeit.Tests.DatabaseTests
{
    [TestClass]
    public class DatabaseTest
    {
        [ClassInitialize]
        public static void InitializeDatabase(TestContext testContext)
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<MyDbContext>());
        }

        [TestMethod]
        public void InsertData()
        {
            using (var db = new MyDbContext())
            {
                db.Blogs.Add(new Blog
                {
                    Name = "test",
                    Posts = new List<Post>
                    {
                        new Post { Title = "title1" },
                        new Post { Title = "title2" }
                    }
                });

                db.SaveChanges();
            }

            using (var db = new MyDbContext())
            {
                Assert.AreEqual(1, db.Blogs.Count());
            }
        }

        [TestMethod]
        public void InsertDataFromDifferentThreads()
        {
            int noOfElements = 1000;

            Parallel.For(0, noOfElements,
                index =>
                {
                    bool done = false;
                    while (!done)
                    {
                        try
                        {
                            insertIntoDb(index);
                            done = true;
                        }
                        catch (Exception e)
                        {
                            done = false;
                        }
                    }
                });
        }

        private void insertIntoDb(int index)
        {
            using (var db = new MyDbContext())
            {
                db.Blogs.Add(new Blog { Name = index.ToString() });
                db.SaveChanges();
            }
        }
    }
}

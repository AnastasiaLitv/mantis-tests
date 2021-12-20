using NUnit.Framework;
using System;
using System.Linq;
using System.Text;

namespace mantis_tests
{
   public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        public static string GenerateRandomString(int max)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, max)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}

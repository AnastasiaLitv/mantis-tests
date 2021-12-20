using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
           : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Username);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }

        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//span[@class='user-info']"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() 
                && GetLoggetUserName() == account.Username;
        }

        public string GetLoggetUserName()
        {
            string user = driver.FindElement(By.XPath("//span[@class='user-info']")).Text;
             return user;
        }
    }
}

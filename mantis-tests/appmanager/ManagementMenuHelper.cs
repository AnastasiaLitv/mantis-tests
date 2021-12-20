using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void OpenManagePage()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Manage')]/preceding-sibling::i")).Click();
        }

        public void OpenManageProjectsTab()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Manage Projects')]")).Click();
        }
    }
}

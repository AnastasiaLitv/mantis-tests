using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected ManagementMenuHelper manageHelper;
        protected ProjectManagementHelper projectHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/";

            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectManagementHelper(this);
            manageHelper = new ManagementMenuHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ManagementMenuHelper Manage
        {
            get
            {
                return manageHelper;
            }
        }
        public ProjectManagementHelper Project
        {
            get
            {
                return projectHelper;
            }
        }



    }

}

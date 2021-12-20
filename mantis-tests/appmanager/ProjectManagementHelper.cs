using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager)
           : base(manager)
        {
        }
        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Manage.OpenManagePage();
            manager.Manage.OpenManageProjectsTab();

            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectAction();
            System.Threading.Thread.Sleep(1000);

            return this;
        }

        public ProjectManagementHelper Remove(int p)
        {
            manager.Manage.OpenManagePage();
            manager.Manage.OpenManageProjectsTab();

            SelectProject(p);

            SubmitProjectDeleting();
            SubmitProjectAction();
            System.Threading.Thread.Sleep(1000);

            return this;
        }

        private void SelectProject(int p)
        {
            driver.FindElements(By.XPath("//table//td/a"))[p].Click();
        }

        private ProjectManagementHelper SubmitProjectAction()
        {
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
            projectCache = null;
            return this;
        }

        private ProjectManagementHelper SubmitProjectDeleting()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            projectCache = null;
            return this;
        }

        private ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
            return this;
        }

        private ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[contains(text(),'Create New Project')]")).Click();
            return this;
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.XPath("//table//td/a")).Count;
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.Manage.OpenManagePage();
                manager.Manage.OpenManageProjectsTab();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table//td/a"));
                foreach (IWebElement element in elements)
                {
                    projectCache.Add(new ProjectData(element.Text)
                    {
                        Name = element.Text
                    });
                }

            }

            return new List<ProjectData>(projectCache);
        }

    }
}

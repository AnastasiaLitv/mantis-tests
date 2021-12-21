using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");

            ProjectData project = new ProjectData(GenerateRandomString(5), GenerateRandomString(10));

            List<ProjectData> oldProjects = app.Project.GetProjectListByService(account);

            app.Project.CreateByService(project, account);
            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProject = app.Project.GetProjectListByService(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }
    }
}

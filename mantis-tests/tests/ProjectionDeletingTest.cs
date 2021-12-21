using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectionDeletingTest : AuthTestBase
    {
        [Test]
        public void ProjectionDeletingTests()
        {
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> oldProjects = app.Project.GetProjectListByService(account);
            if(oldProjects.Count == 0)
            {
                ProjectData newproject = new ProjectData(GenerateRandomString(5), GenerateRandomString(10));
                app.Project.CreateByService(newproject, account);
                oldProjects.Add(newproject);
            }

            ProjectData project = oldProjects[0];
            app.Project.Remove(0);

            List<ProjectData> newProject = app.Project.GetProjectListByService(account);
            oldProjects.Remove(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }
    }
}

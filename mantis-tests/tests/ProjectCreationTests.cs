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
            ProjectData project = new ProjectData(GenerateRandomString(5), GenerateRandomString(10));

            List<ProjectData> oldProjects = app.Project.GetProjectList();
            app.Project.Create(project);
            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            System.Threading.Thread.Sleep(1500);
            List<ProjectData> newProject = app.Project.GetProjectList();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }
    }
}

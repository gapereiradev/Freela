using Freela.Core.Entities;
using Freela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Freela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome De Teste", "DescricaoDeTeste", 1, 2, 100);

            Assert.NotNull(project);
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
        }
    }
}

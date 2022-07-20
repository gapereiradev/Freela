using Freela.Application.Queries.GetAllProjects;
using Freela.Core.Entities;
using Freela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Freela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Execute_ReturnThreeProjectsViewModels()
        {
            //A-A-A
            // Arange
            // ACT
            // ASSERT


            // Arange
            var projects = new List<Project>
            {
                new Project("Nome Teste 1", "Descricao 1", 1,2,10000),
                new Project("Nome Teste 2", "Descricao 2", 1,2,20000),
                new Project("Nome Teste 3", "Descricao 3", 1,2,30000)
            };
            
            var projectRepository = new Mock<IProjectRepository>();
            projectRepository.Setup(pr => pr.GetAllAsync().Result).Returns(projects);
            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepository.Object);


            // ACT
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // ASSERT
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

        }
    }
}

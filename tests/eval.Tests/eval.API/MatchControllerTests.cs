using eval.Persistence;
using Moq;
using Xunit;
using eval.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eval.Tests.eval.API
{
    public class MatchControllerTests
    {
        [Fact]
        public void GetAll_Success()
        {
            //Arrange
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetAll(It.IsAny<string>()));
            var controller = new MatchController(mockRepo.Object);

            //Act
            var result = controller.GetAll(It.IsAny<string>());

            //Assert
            result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}

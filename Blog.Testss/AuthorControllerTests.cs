using AutoMapper;
using Blog.Controllers;
using Blog.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace Blog.Tests
{
    [TestClass]
    public class AuthorControllerTests : Controller
    {
        private IMapper mapper;

        public AuthorControllerTests()
        {
            IConfigurationProvider configurationProvider = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.Load("Blog")));
            mapper = new Mapper(configurationProvider);
        }

        [TestMethod]
        public void WhenCallIndex_WithNoParams_ReturnsIndexView()
        {
            // Arrange
            IAuthorService authorService = new MockedAuthorService();
            AuthorsController authorsController = new AuthorsController(authorService, this.mapper);
            var authorsViewModel = new List<ViewModels.AuthorViewModel>();
            var expectedResult = View(authorsViewModel);

            // Act
            var actualResult = authorsController.Index();

            // Assert
            Xunit.Assert.Equal(expectedResult, actualResult);
        }
    }
}

using CaseCadastro.API.Controllers;
using CaseCadastro.Application.Interfaces;
using CaseCadastro.Application.Services;
using CaseCadastro.Domain.Interfaces;
using CaseCadastro.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Web.Http.Results;

namespace CaseCadastro.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async Task Get_Cadastro_ReturnsOkResult()
        {
            var mockService = new Mock<ICadastroService>();
            mockService.Setup(service => service.GetById(It.IsAny<int>()))
                       .ReturnsAsync(new Cadastro());

            var controller = new CadastroController(mockService.Object);

            var result = await controller.GetById(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task Get_UnityWork_ReturnsOkResult()
        {
            var mockRepository = new Mock<IUnityWork>();
            mockRepository.Setup(service => service.Cadastro.GetById(It.IsAny<int>()))
                       .ReturnsAsync(new Cadastro());
            var service = new CadastroService(mockRepository.Object);

            var result = await service.GetById(1);

            Assert.IsInstanceOfType(result, typeof(Cadastro));
        }
        [TestMethod]
        public async Task GetAll_Cadastros_ReturnsOkResult()
        {
            var mockService = new Mock<ICadastroService>();
            mockService.Setup(service => service.GetAll())
                       .ReturnsAsync(new List<Cadastro>());

            var controller = new CadastroController(mockService.Object);

            var result = await controller.GetAll();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task Create_Cadastro_ReturnsCreatedAtRouteResult()
        {
            var mockService = new Mock<ICadastroService>();
            mockService.Setup(service => service.InserirCadastro(It.IsAny<Cadastro>()))
                       .ReturnsAsync(true);

            var controller = new CadastroController(mockService.Object);

            var newCadastro = new Cadastro
            {
                Nome = "Test",
                Sobrenome = "User",
                Idade = "25",
                Pais = "Country"
            };

            var result = await controller.Insert(newCadastro);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public async Task Patch_Cadastro_ReturnsNoContentResult()
        {
            var mockService = new Mock<ICadastroService>();
            mockService.Setup(service => service.UpdateCadastro(It.IsAny<Cadastro>()))
                       .ReturnsAsync(true);

            var controller = new CadastroController(mockService.Object);

            var updatedCadastro = new Cadastro
            {
                Id = 1,
                Nome = "UpdatedName"
            };

            var result = await controller.Update(updatedCadastro);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Delete_Cadastro_ReturnsNoContentResult()
        {
            var mockService = new Mock<ICadastroService>();
            mockService.Setup(service => service.DeleteCadastro(It.IsAny<int>()))
                       .ReturnsAsync(true);

            var controller = new CadastroController(mockService.Object);

            var result = await controller.Delete(2);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
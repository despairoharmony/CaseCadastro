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
    public class GenericRepositoryTests
    {
        [TestMethod]
        public async Task Get_Cadastro_ReturnsOkResult()
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
            var mockRepository = new Mock<IUnityWork>();
            mockRepository.Setup(service => service.Cadastro.GetAllAsync())
                       .ReturnsAsync(new List<Cadastro>());

            var service = new CadastroService(mockRepository.Object);

            var result = await service.GetAll() as List<Cadastro>;

            Assert.IsInstanceOfType(result, typeof(List<Cadastro>));
        }
        [TestMethod]
        public async Task Create_Cadastro_ReturnsCreatedAtRouteResult()
        {
            var mockRepository = new Mock<IUnityWork>();
            mockRepository.Setup(service => service.Cadastro.Insert(It.IsAny<Cadastro>()));

            var service = new CadastroService(mockRepository.Object);

            var newCadastro = new Cadastro
            {
                Nome = "Test",
                Sobrenome = "User",
                Idade = "25",
                Pais = "Country"
            };

            var result = await service.InserirCadastro(newCadastro);

            Assert.IsInstanceOfType(result, typeof(Boolean));

        }

        [TestMethod]
        public async Task Patch_Cadastro_ReturnsNoContentResult()
        {
            var mockRepository = new Mock<IUnityWork>();
            mockRepository.Setup(service => service.Cadastro.Update(It.IsAny<Cadastro>()));

            var service = new CadastroService(mockRepository.Object);

            var updatedCadastro = new Cadastro
            {
                Id = 1,
                Nome = "UpdatedName"
            };

            var result = await service.UpdateCadastro(updatedCadastro);

            Assert.IsInstanceOfType(result, typeof(Boolean));
        }

        [TestMethod]
        public async Task Delete_Cadastro_ReturnsNoContentResult()
        {
            var mockRepository = new Mock<IUnityWork>();
            mockRepository.Setup(service => service.Cadastro.Delete(It.IsAny<int>()));

            var service = new CadastroService(mockRepository.Object);

            var result = await service.DeleteCadastro(2);

            Assert.IsInstanceOfType(result, typeof(Boolean));
        }
    }
}
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace UnitTests
{
    public class UserRepositoryTests
    {
        private readonly Mock<UserManager<EntityUser>> _userManagerMock;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            var store = new Mock<IUserStore<EntityUser>>();
            _userManagerMock = new Mock<UserManager<EntityUser>>(
                new Mock<IUserStore<EntityUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<EntityUser>>().Object,
                new IUserValidator<EntityUser>[0],
                new IPasswordValidator<EntityUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<EntityUser>>>().Object);
            _userRepository = new UserRepository(_userManagerMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnIdentityResultSuccess()
        {
            // Arrange
            var user = new User("testUser1", "mixalev702@mail.ru", "NewPassword123");

            _userManagerMock
                .Setup(userManager => userManager.CreateAsync(It.IsAny<EntityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act 
            var result = await _userRepository.AddAsync(user);

            // Assert 
            Assert.True(result.Succeeded);
           
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnIdentityResultSuccess()
        {
            // Arrange
            var userName = "testUser";
            var entityUser = new EntityUser { UserName = userName };

            _userManagerMock.Setup(um => um.FindByNameAsync(userName))
                .ReturnsAsync(entityUser);
            _userManagerMock.Setup(um => um.DeleteAsync(entityUser))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _userRepository.DeleteAsync(userName);

            // Assert
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task GetByNameAsync_ShouldReturnUser()
        {
            // Arrange
            var userName = "testUser";
            var entityUser = new EntityUser { UserName = userName };

            _userManagerMock.Setup(um => um.FindByNameAsync(userName))
                .ReturnsAsync(entityUser);

            // Act
            var result = await _userRepository.GetByNameAsync(userName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userName, result.UserName);
        }

        [Fact]
        public async Task GetByNameAsync_ShouldReturnNull_WhenUserNotFound()
        {
            // Arrange
            var userName = "nonExistentUser";

            _userManagerMock.Setup(um => um.FindByNameAsync(userName))
                .ReturnsAsync((EntityUser)null);

            // Act
            var result = await _userRepository.GetByNameAsync(userName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnIdentityResultSuccess()
        {
            // Arrange
            var user = new User("testUser", "mixalev702@mail.ru", "NewPassword123");
            var entityUser = EntityUser.ConwertToEntityUser(user);
            _userManagerMock
                .Setup(userManager => userManager.CreateAsync(It.IsAny<EntityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            await _userRepository.AddAsync(user);
            // Act
            _userManagerMock.Setup(um => um.UpdateAsync(entityUser))
                .ReturnsAsync(IdentityResult.Success);
            var result = await _userRepository.AddAsync(user);

            // Assert
            Assert.True(result.Succeeded);
        }
    }
}



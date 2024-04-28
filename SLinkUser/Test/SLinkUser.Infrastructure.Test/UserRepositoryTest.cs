using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using SLinkUser.Domain;
using SLinkUser.Domain.Entity;

namespace SLinkUser.Infrastructure.Test
{
    public class UserRepositoryTest
    {
        private readonly UserDbContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly Mock<UserDbContext> _userContextMock;

        public UserRepositoryTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<UserDbContext>()
         .UseInMemoryDatabase("UserDbContextTest")
         .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
         .Options;
            _userContext = new UserDbContext(dbContextOptions);
            _userRepository = new UserRepository(_userContext);
            var dbMockOption = new DbContextOptions<UserDbContext>();
            _userContextMock = new Mock<UserDbContext>(dbMockOption);
        }

        [Fact]
        public async void Add_Users_Async_Success()
        {
            //Arrange
            List<User> users = [
                new User
                {
                    Address = new Address
                    {
                        City = "Madrid",
                        Latitud = "3000",
                        Longitude = "-3000",
                        Street = "Calle Carretas",
                        Suite = "701",
                        Zipcode = "29019"
                    },
                    Company = new Company
                    {
                        Bs = "The best",
                        CatchPhrase = "Best doing test",
                        Name = "Big Company"
                    },
                    Email = "SomeOne@mail.com",
                    Id = 1,
                    Name = "Andres",
                    Phone = "4567890",
                    Username ="Andy",
                    Website = "http://Test.com"
                },
                new User
                {
                    Address = new Address
                    {
                        City = "Alcobendas",
                        Latitud = "5000",
                        Longitude = "-7000",
                        Street = "Calle Alco",
                        Suite = "01",
                        Zipcode = "39019"
                    },
                    Company = new Company
                    {
                        Bs = "The best 2",
                        CatchPhrase = "Best doing test 2",
                        Name = "Big Company 2"
                    },
                    Email = "SomeOne2@mail.com",
                    Id = 2,
                    Name = "Andres2",
                    Phone = "45678902",
                    Username ="Andy2",
                    Website = "http://Test.com"
                }
            ];

            // Act
            var result = await _userRepository.AddUsersAsync(users, new CancellationToken());
            var response = result.Match(
                success => success,
                failed => failed);

            // Assert
            Assert.True(response.IsSuccess);
            Assert.True(_userContext.Users!.Contains(users.First()));
        }

        [Fact]
        public async void Add_Users_Async_Fail_Id_Duplicated()
        {
            //Arrange
            List<User> users = [
               new User
                {
                    Address = new Address
                    {
                        City = "Madrid",
                        Latitud = "3000",
                        Longitude = "-3000",
                        Street = "Calle Carretas",
                        Suite = "701",
                        Zipcode = "29019"
                    },
                    Company = new Company
                    {
                        Bs = "The best",
                        CatchPhrase = "Best doing test",
                        Name = "Big Company"
                    },
                    Email = "SomeOne@mail.com",
                    Id = 1,
                    Name = "Andres",
                    Phone = "4567890",
                    Username ="Andy",
                    Website = "http://Test.com"
                },
                new User
                {
                    Address = new Address
                    {
                        City = "Alcobendas",
                        Latitud = "5000",
                        Longitude = "-7000",
                        Street = "Calle Alco",
                        Suite = "01",
                        Zipcode = "39019"
                    },
                    Company = new Company
                    {
                        Bs = "The best 2",
                        CatchPhrase = "Best doing test 2",
                        Name = "Big Company 2"
                    },
                    Email = "SomeOne2@mail.com",
                    Id = 1,
                    Name = "Andres2",
                    Phone = "45678902",
                    Username ="Andy2",
                    Website = "http://Test.com"
                }
           ];

            // Act
            var result = await _userRepository.AddUsersAsync(users, new CancellationToken());
            var response = result.Match(
                success => new ErrorResponse(0, string.Empty),
                failed => failed);

            // Assert
            Assert.True(result.IsError);
            Assert.Equal(StatusErrorCode.InternalServerError, response.Code);
            Assert.Contains("The instance of entity type 'User' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked.", response.Description!);
        }

        [Fact]
        public async void Add_Users_Async_ArgumentException()
        {
            //Arrange
            List<User> users = [
               new User
                {
                    Address = new Address
                    {
                        City = "Madrid",
                        Latitud = "3000",
                        Longitude = "-3000",
                        Street = "Calle Carretas",
                        Suite = "701",
                        Zipcode = "29019"
                    },
                    Company = new Company
                    {
                        Bs = "The best",
                        CatchPhrase = "Best doing test",
                        Name = "Big Company"
                    },
                    Email = "SomeOne@mail.com",
                    Id = 1,
                    Name = "Andres",
                    Phone = "4567890",
                    Username ="Andy",
                    Website = "http://Test.com"
                },
               new User
                {
                    Address = new Address
                    {
                        City = "Alcobendas",
                        Latitud = "5000",
                        Longitude = "-7000",
                        Street = "Calle Alco",
                        Suite = "01",
                        Zipcode = "39019"
                    },
                    Company = new Company
                    {
                        Bs = "The best 2",
                        CatchPhrase = "Best doing test 2",
                        Name = "Big Company 2"
                    },
                    Email = "SomeOne2@mail.com",
                    Id = 2,
                    Name = "Andres2",
                    Phone = "45678902",
                    Username ="Andy2",
                    Website = "http://Test.com"
                }
           ];
            var userRepository = new UserRepository(_userContextMock.Object);
            _userContextMock.Setup(pc => pc.AddRangeAsync(users, It.IsAny<CancellationToken>())).Throws(new ArgumentException("", new ArgumentException("Test Error")));

            // Act
            var result = await userRepository.AddUsersAsync(users, new CancellationToken());
            var response = result.Match(
                success => new ErrorResponse(0, string.Empty),
                failed => failed);

            // Assert
            Assert.True(result.IsError);
            Assert.Equal(StatusErrorCode.InternalServerError, response.Code);
            Assert.Equal("Test Error", response.Description);
        }
    }
}
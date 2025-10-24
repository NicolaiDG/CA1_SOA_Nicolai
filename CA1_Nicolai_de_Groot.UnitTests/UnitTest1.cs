using CA1_Nicolai_deGroot.Services;

namespace CA1_Nicolai_de_Groot.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            // Arrange
            var httpClient = new HttpClient();
            var service = new CountryService(httpClient);

            // Act
            var country = await service.GetCountryAsync("Belgium");

            // Assert
            Assert.That(country.Name.Common, Is.EqualTo("Belgium"));
            Assert.That(country.Population, Is.GreaterThan(0));

        }
    }
}
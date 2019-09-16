using FluentAssertions;
using NUnit.Framework;

namespace AlternativesSolution.Tests
{
    [TestFixture]
    public class JsonReaderTest
    {
        private string _validConfigurationPath = "../../../conf.json";

        [Test]
        public void Read()
        {
            var sut = CreateReader(_validConfigurationPath);

            var model = sut.Read();

            model.Name.Should().Be("qwewrty2134");
        }

        private IReader<ConfigurationTestModel> CreateReader(string configurationPath) => 
            new JsonReader<ConfigurationTestModel>(configurationPath);

        private class ConfigurationTestModel
        {
            public string Name { get; set; }
        }
    }
}

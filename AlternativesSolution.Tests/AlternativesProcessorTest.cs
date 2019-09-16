using AlternativesSolution.Entities;
using AlternativesSolution.Processors;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlternativesSolution.Tests
{
    [TestFixture]
    public class AlternativesProcessorTest
    {
        private string _validConfigurationPath = "../../../alternativesConfiguration.json";
        private IReader<IReadOnlyList<MatrixCase>> _reader;

        [SetUp]
        public void SetUp()
        {
            _reader = new JsonReader<IReadOnlyList<MatrixCase>>(_validConfigurationPath);
        }

        [Test]
        public void When_CustomerCase1_ReturnsTwoProfessionalAlternatives()
        {
            //Arrange
            var sut = new AlternativesProcessor();
            var customerPreferences = CreateCustomerPreferences(false, false);

            // Act
            var result = sut.Process(customerPreferences, _reader.Read());

            //Assert
            result.Should().HaveCount(2);
            result.Should().OnlyContain(alternative => alternative.Type == AlternativeType.Professionall);
        }

        [Test]
        public void When_CustomerCase2_ReturnsOneStandardAlternative()
        {
            //Arrange
            var sut = new AlternativesProcessor();
            var customerPreferences = CreateCustomerPreferences(true, false);

            // Act
            var result = sut.Process(customerPreferences, _reader.Read());

            //Assert
            result.Should().HaveCount(1);
            result.Should().OnlyContain(alternative => alternative.Type == AlternativeType.Standard);
        }

        [Test]
        public void When_CustomerCase3_ReturnsOneProfessionallAlternative()
        {
            //Arrange
            var sut = new AlternativesProcessor();
            var customerPreferences = CreateCustomerPreferences(false, true);

            // Act
            var result = sut.Process(customerPreferences, _reader.Read());

            //Assert
            result.Should().HaveCount(1);
            result.Should().OnlyContain(alternative => alternative.Type == AlternativeType.Professionall);
        }

        [Test]
        public void When_CustomerCase4_ReturnsOneStandardAlternative()
        {
            //Arrange
            var sut = new AlternativesProcessor();
            var customerPreferences = CreateCustomerPreferences(true, true);

            // Act
            var result = sut.Process(customerPreferences, _reader.Read());

            //Assert
            result.Should().HaveCount(1);
            result.Should().OnlyContain(alternative => alternative.Type == AlternativeType.Standard);
        }

        private CustomerPreferences CreateCustomerPreferences(bool isYourLaptopFast, bool isYourCarTurboCharged) =>
            new CustomerPreferences { IsYourLaptopFast = isYourLaptopFast, IsYourCarTurboCharged = isYourCarTurboCharged };
    }
}

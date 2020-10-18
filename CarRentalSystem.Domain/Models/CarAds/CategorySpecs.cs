namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using FluentAssertions;
    using System;
    using Xunit;

    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotthrowException()
        {
            //Act
            Action act = () => new Category("Valid name", "Valid description text");

            //Assert
            act.Should().NotThrow<InvalidCarAdException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            //Act
            Action act = () => new Category("", "Valid description text");

            //Assert
            act.Should().Throw<InvalidCarAdException>();
        }
    }
}

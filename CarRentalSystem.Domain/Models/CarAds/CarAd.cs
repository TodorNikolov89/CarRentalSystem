﻿namespace CarRentalSystem.Domain.Models.CarAds
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;
    using static ModelConstants.CarAd;

    public class CarAd : Entity<int>, IAggregateRoot
    {

        internal CarAd(
            Manufacturer manufacturer,
            string model,
            Category category,
            string imageUrl,
            decimal pricePerDay,
            Options options,
            bool isAvailable)
        {
            this.Validate(model, imageUrl, pricePerDay);

            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.Options = options;
            this.IsAvailable = isAvailable;
        }

        private CarAd(
             string model,
             string imageUrl,
             decimal pricePerDay,
             bool isAvailable)
        {
            this.IsAvailable = isAvailable;
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;

            this.Options = default!;
            this.Category = default!;
            this.Manufacturer = default!;
        }


        public Manufacturer Manufacturer { get; }

        public string Model { get; private set; }

        public Category Category { get; }

        public string ImageUrl { get; private set; }

        public decimal PricePerDay { get; private set; }

        public Options Options { get; }

        public bool IsAvailable { get; private set; }

        public void ChangeAvailability() => this.IsAvailable = !this.IsAvailable;

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                model,
                MinModelLength,
                MaxModelLength,
                nameof(this.Model));

            Guard.ForValidUrl<InvalidCarAdException>(
                imageUrl,
                nameof(this.ImageUrl));

            Guard.AgainstOutOfRange<InvalidCarAdException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));
        }



    }
}

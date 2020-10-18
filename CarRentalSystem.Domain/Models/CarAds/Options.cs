namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Exceptions;
    using Common;

    using static ModelConstants.Options;

    public class Options : ValueObject
    {
        internal Options(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
        {
            HasClimateControl = hasClimateControl;
            NumberOfSeats = numberOfSeats;
            TransmissionType = transmissionType;
        }

        private Options(bool hasClimateControl, int numberOfSeats)
        {
            HasClimateControl = hasClimateControl;
            NumberOfSeats = numberOfSeats;
            TransmissionType = default!; 
        }


        public bool HasClimateControl { get; private set; }

        public int NumberOfSeats { get; private set; }

        public TransmissionType TransmissionType { get; private set; }

        private void Validate(int numberOfSeats)
        => Guard.AgainstOutOfRange<InvalidOptionsException>(
            numberOfSeats,
            MinNumberOfSeats,
            MaxNumberOfSeats,
            nameof(this.NumberOfSeats));
    }
}

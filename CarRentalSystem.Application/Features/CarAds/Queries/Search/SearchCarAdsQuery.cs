﻿namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchCarAdsQuery : IRequest<SearchCarAdsOutputModel>
    {
        public string? Manufacturer { get; set; }

        public class SearchCarAdsQueryHandler : IRequestHandler<SearchCarAdsQuery, SearchCarAdsOutputModel>
        {
            private readonly ICarAdRepository carAdRepository;

            public SearchCarAdsQueryHandler(ICarAdRepository carAdRepository)
                => this.carAdRepository = carAdRepository;

            public async Task<SearchCarAdsOutputModel> Handle(SearchCarAdsQuery request, CancellationToken cancellationToken)
            {
                var carAdListing = await this.carAdRepository.GetCarAdListings(request.Manufacturer, cancellationToken);
                var totalCarAds = await this.carAdRepository.Total(cancellationToken);

                return new SearchCarAdsOutputModel(carAdListing, totalCarAds);
            }

        }

    }
}

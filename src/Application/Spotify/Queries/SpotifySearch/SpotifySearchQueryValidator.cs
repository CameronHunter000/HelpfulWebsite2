using FluentValidation;

namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchQueryValidator : AbstractValidator<SpotifySearchQuery>
    {
        public SpotifySearchQueryValidator()
        {
            RuleFor(x => x.SearchText)
                .NotNull()
                .NotEmpty().WithMessage("SearchText is required.");

            RuleFor(x => x.Type)
                .NotNull()
                .IsInEnum()
                .NotEmpty().WithMessage("Type is required and must use EType Enum.");

            RuleFor(x => x.Market)
                .IsInEnum().WithMessage("Market must use EMarket Enum.");

            RuleFor(x => x.Limit)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(50)
                .WithMessage("Limit has a minimum of 1 and maximum of 50.");

            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(1000)
                .WithMessage("PageSize has a minimum of 0 and maximum of 1000.");
        }
    }

}

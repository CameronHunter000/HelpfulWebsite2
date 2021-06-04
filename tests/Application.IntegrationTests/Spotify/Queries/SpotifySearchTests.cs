using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using HelpfulWebsite_2.Application.Music.Queries.MusicSearch;

namespace HelpfulWebsite_2.Application.IntegrationTests.Spotify.Queries
{
    using static Testing;

    public class SpotifySearchTests : TestBase
    {
        [Test]
        public async Task SingleType_ShouldReturnResult()
        {
            var request = new MusicSearchQuery
            {
                SearchText = "a dream of you and me"
            };

            var result = await SendAsync(request);

            result.Track[0].TrackName.Should().Be("A Dream of You and Me");
            result.Track[0].Artists[0].Should().Be("Future Islands");
        }
    }
}
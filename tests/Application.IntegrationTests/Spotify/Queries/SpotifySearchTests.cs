using FluentAssertions;
using HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HelpfulWebsite_2.Application.IntegrationTests.Spotify.Queries
{
    using static Testing;

    public class SpotifySearchTests : TestBase
    {
        [Test]
        public async Task SingleType_ShouldReturnResult()
        {
            var query = new SpotifySearchQuery
            {
                Query = "Tool",
                Type = "Artist"
            };

            var result = await SendAsync(query);

            result.albums.Should().BeNull();
            result.artists.items[0].name.Should().Be("TOOL");
            result.tracks.Should().BeNull();
            result.playlists.Should().BeNull();
            result.shows.Should().BeNull();
            result.episodes.Should().BeNull();
        }

        [Test]
        public async Task MultipleTypes_ShouldReturnResult()
        {
            var query = new SpotifySearchQuery
            {
                Query = "Tool",
                Type = "album,Artist,track,playlist,show,episode"
            };

            var result = await SendAsync(query);

            result.albums.Should().NotBeNull();
            result.artists.items[0].name.Should().Be("TOOL");
            result.tracks.Should().NotBeNull();
            result.playlists.Should().NotBeNull();
            result.shows.Should().NotBeNull();
            result.episodes.Should().NotBeNull();
        }
    }
}
using AutoMapper;
using HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpfulWebsite_2.Application.Music.Queries.MusicSearch;
using HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch;

namespace HelpfulWebsite_2.Infrastructure.Mappings
{
    public static class MusicMapper
    {
        public static SpotifySearchQuery GetSpotifySearchQuery(MusicSearchQuery musicSearchQuery)
        {
            return new SpotifySearchQuery
            {
                Type = musicSearchQuery.ResultType,
                Query = musicSearchQuery.SearchText
            };
        }

        public static TrackListDto GetTrackList(SpotifySearchResponse spotifySearchResponse)
        {
            var trackListDto = new TrackListDto
            {
                Track = new List<TrackVm>()
            };

            foreach (var item in spotifySearchResponse.Tracks.Items)
            {
                trackListDto.Track.Add(new TrackVm 
                {
                    TrackName =  item.Name,
                    Duration = item.DurationMs,
                    PlayUri = item.Uri,
                    Popularity = item.Popularity,
                    ReleaseDate = item.ReleaseDate,
                    Language = item.Language,
                    Genres = item.Genres,
                    Album = item.Album.Name,
                    Artists = item.Artists.Select(artist => artist.Name).ToList()
                });
            }
            return trackListDto;
        }
    }
}

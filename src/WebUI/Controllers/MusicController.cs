using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpfulWebsite_2.Application.Music.Queries.MusicSearch;
using HelpfulWebsite_2.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using MediatR;

namespace HelpfulWebsite_2.WebUI.Controllers
{
    public class MusicController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<TrackListDto>> GetMusicSearchResponse([FromQuery] MusicSearchQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}

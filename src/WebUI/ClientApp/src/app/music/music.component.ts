import { Component } from '@angular/core';
import { MusicClient, TrackListDto } from '../web-api-client';

@Component({
  selector: 'music-component',
  templateUrl: './music.component.html'
})

export class MusicComponent {
  public tracks: TrackListDto;

  constructor(private client: MusicClient) {
    client.getMusicSearchResponse().subscribe(result => {
      this.tracks = result;
    }, error => console.error(error));
  }
}

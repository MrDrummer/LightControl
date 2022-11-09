import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SignalrService } from "../services/signalr.service";
import { MatButtonToggleChange } from "@angular/material/button-toggle";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  get pattern(): string {
    return this.signalRService.data?.pattern ?? 'solid';
  }

  constructor(public signalRService: SignalrService, private http: HttpClient) { }
  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addBroadcastListener();
    this.startHttpRequest();
  }
  private startHttpRequest = () => {
    this.http.get('https://localhost:5001/LightControl')
      .subscribe((res) => {
        console.log(res);
      })
  }

  public sendUpdate (data: MatButtonToggleChange) {
    console.log('data :', data);
    console.log('state changed :', this.pattern);
    this.signalRService.broadcastData({ pattern: data.value });
  }

}

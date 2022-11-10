import { Component } from '@angular/core';

import { SignalrService } from "../services/signalr.service";
import { MatButtonToggleChange } from "@angular/material/button-toggle";
import {LightControlUpdate} from "../_interfaces/LightControlUpdate.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  get data(): Partial<LightControlUpdate> {
    return this.signalRService.data ?? {};
  }

  constructor(public signalRService: SignalrService) { }
  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addBroadcastListener();
    this.signalRService.startHttpRequest();
  }

  public sendUpdate (data: MatButtonToggleChange) {
    console.log('data :', data);
    this.signalRService.broadcastData({ pattern: data.value });
  }

}

import { Component } from '@angular/core';
import { MatButtonToggleChange } from "@angular/material/button-toggle";

import { SignalrService } from "../services/signalr.service";
import { LightControlUpdate } from "../_interfaces/LightControlUpdate.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  get colour(): string {
    return `#${this.data.colour?.toString(16)}`;
  }

  get data(): Partial<LightControlUpdate> {
    return this.signalRService.data ?? {};
  }

  constructor(public signalRService: SignalrService) { }
  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addBroadcastListener();
    this.signalRService.startHttpRequest();
  }

  public setPattern (data: MatButtonToggleChange) {
    console.log('data :', data);
    this.signalRService.broadcastData({ pattern: data.value });
  }

  public setColour (data: string) {
    console.log('data :', data);

    const numberValue = parseInt(data.replace('#', '0x'), 16);
    this.signalRService.broadcastData({ colour: numberValue });
  }

}

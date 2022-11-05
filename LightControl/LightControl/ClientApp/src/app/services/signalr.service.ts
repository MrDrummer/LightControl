import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { LightControlUpdate } from '../_interfaces/LightControlUpdate.model';
@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public data?: LightControlUpdate;
  private hubConnection?: signalR.HubConnection
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/lightcontrolhub')
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public receivedLightControlData = () => {
    this.hubConnection?.on('ReceiveMessage', (data: LightControlUpdate) => {
      this.data = data;
      console.log(data);
    });
  }
}

import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { LightControlUpdate } from '../_interfaces/LightControlUpdate.model';
@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public data?: LightControlUpdate;
  private hubConnection?: signalR.HubConnection;
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/lightcontrolhub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addBroadcastListener = () => {
    console.log("addBroadcastListener:this.hubConnection", this.hubConnection);
    this.hubConnection?.on('ReceiveMessage', (data: LightControlUpdate) => {
      this.data = data;
      console.log('update :', data?.pattern);
    });
  }

  public broadcastData = (data: LightControlUpdate) => {
    this.hubConnection?.invoke('SendMessage', data).catch(err => console.error(err));
  }
}

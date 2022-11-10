import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { HttpClient } from '@angular/common/http';
import { LightControlUpdate } from '../_interfaces/LightControlUpdate.model';
@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public data?: LightControlUpdate;
  private hubConnection?: signalR.HubConnection;

  constructor(public http: HttpClient) { }

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
  public startHttpRequest = () => {
    this.http.get('https://localhost:5001/LightControl')
      .subscribe((res) => {
        console.log("init api response :", res);
        this.data = res as LightControlUpdate;
      })
  }

  public broadcastData = (data: LightControlUpdate) => {
    this.hubConnection?.invoke('SendMessage', data).catch(err => console.error(err));
  }
}

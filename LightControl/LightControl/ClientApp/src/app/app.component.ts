import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {SignalrService} from "./services/signalr.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(public signalRService: SignalrService, private http: HttpClient) { }
  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.receivedLightControlData();
    // this.startHttpRequest();
  }
  // private startHttpRequest = () => {
  //   this.http.get('https://localhost:5001/api/chart')
  //     .subscribe(res => {
  //       console.log(res);
  //     })
  // }
}

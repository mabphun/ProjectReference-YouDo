import { Injectable } from "@angular/core";
import * as signalR from "@aspnet/signalr";
import { APP_URLS } from "../app.urls";

const connection = new signalR.HubConnectionBuilder()
    .withUrl(APP_URLS.baseUrl + APP_URLS.signalR,{
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .build();

@Injectable({
    providedIn: 'root'
})
export class SignalRService{
    hubCon: signalR.HubConnection

    constructor(){
        this.hubCon = connection
    }

    startConnection(){
        connection
        .start()
        .then(() => {
            console.log('Hub Connection started!');
        })
        .catch(err => console.log('Error while starting connection: ' + err))
    }

    stopConnections(){
        connection.off('askServerResponse')
        connection.off('ReAuthUserResponse')
        connection.off('AuthUserResponse')
    }

    askServer() {
        connection.invoke('askServer', 'hey')
        .catch(err => console.log(err))
    }

    askServerListener() {
        connection.on('askServerResponse', (sometext) => {
            console.log(sometext);
        })
    }

}
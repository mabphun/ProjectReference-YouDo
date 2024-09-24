import { Injectable } from "@angular/core";
import { SignalRService } from "./signalr.service";
import { ApiService } from "./api.service";
import { UserConnection } from "../_models/userconnection";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    
    constructor(
        private _signalRService: SignalRService,
        private api: ApiService,
        private router: Router
    ){
    }

    async authUser(){
        let userid = this.api.getUserId()
        await this._signalRService.hubCon.invoke('AuthUser', userid)
        .then(() => console.log('Auth process started'))
        .catch(err => console.log(err))
    }

    authUserListener(){
        this._signalRService.hubCon.on('AuthUserResponse', (userconn: UserConnection) =>{
            console.log('Auth process was successful!');
            console.log(userconn);
            this.router.navigate(['/home'])
        })
    }

    async reAuthUser(){
        let userid = this.api.getUserId()
        await this._signalRService.hubCon.invoke('ReAuthUser', userid)
        .then(() => console.log('ReAuth process started'))
        .catch(err => console.log(err))
    }

    reAuthUserListener(){
        this._signalRService.hubCon.on('ReAuthUserResponse', (userconn: UserConnection) =>{
            console.log('ReAuth process was successful!');
            console.log(userconn);
        })
    }
}
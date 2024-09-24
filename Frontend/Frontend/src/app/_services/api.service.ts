import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    router: Router

    /*
    headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + this.getToken()
    })

    public getHeaders() : HttpHeaders{
        let token = localStorage.getItem('token')
        let temp = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        })
        return temp
    }
    */

    constructor(router: Router) {
        this.router = router
    }
    private isLocalStorageAvailable = typeof localStorage !== 'undefined';
    public isLoggedIn() : boolean {
        let token = null
        if (this.isLocalStorageAvailable){
            token = localStorage.getItem('token')
        }
        
        //console.log(token);
        // TODO check expiration date etc.
        return token !== null
    }

    public getUserId() : string{
        let id = null
        if (this.isLocalStorageAvailable){
            id = localStorage.getItem("userid")
        }

        return id !== null ? id : ""
    }

    public getUsername() : string{
        let username = null
        if (this.isLocalStorageAvailable) {
            username = localStorage.getItem("username")
        }

        return username !== null ? username : "Unknown"
    }

    public getToken() : string{
        let id = null
        if (this.isLocalStorageAvailable){
            id = localStorage.getItem("token")
        }
        
        return id !== null ? id : ""
    }

    public canActivate() : boolean {
        if (!this.isLoggedIn()) {
            this.router.navigate(['/login'])
            return false
        }
        return true
    }
}
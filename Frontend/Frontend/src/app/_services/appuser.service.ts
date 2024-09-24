import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable, debounceTime, distinctUntilChanged, switchMap } from "rxjs";
import { AppUserDto } from "../_dtos/appUserDto";
import { APP_URLS } from "../app.urls";
import { ApiService } from "./api.service";

@Injectable({
    providedIn: 'root'
})
export class AppUserService{
    private http = inject(HttpClient)
    private api = inject(ApiService)

    public getUsers() : Observable<Array<AppUserDto>>{
        let response = this.http.get<Array<AppUserDto>>(
            APP_URLS.baseUrl + APP_URLS.appUser
        )
        return response
    }

    public getCurrentUser() : Observable<AppUserDto>{
        let userid = this.api.getUserId()
        let response = this.http.get<AppUserDto>(
            APP_URLS.baseUrl + APP_URLS.appUser + userid
        )
        return response
    }
}
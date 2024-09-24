import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { APP_URLS } from "../app.urls";
import { CreateUserWorkLogDto } from "../_dtos/createUserWorkLogDto";
import { Observable } from "rxjs";
import { UserWorkLogDto } from "../_dtos/userWorkLogDto";

@Injectable({
    providedIn: 'root'
})
export class UserWorkLogService{
    private http = inject(HttpClient)

    public createUserWorkLog(createUWL: CreateUserWorkLogDto) : Observable<UserWorkLogDto>{
        let response = this.http.post<UserWorkLogDto>(
            APP_URLS.baseUrl + APP_URLS.userWorkLog,
            createUWL,
        )
        return response
    }


    public getUsersWorkLog(userid: string) : Observable<Array<UserWorkLogDto>>{
        let response = this.http.get<Array<UserWorkLogDto>>(
            APP_URLS.baseUrl + APP_URLS.userWorkLog + 'u/' + userid
        )
        return response
    }
}
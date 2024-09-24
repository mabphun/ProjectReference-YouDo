import { Injectable } from "@angular/core";

import * as _moment from 'moment';
// tslint:disable-next-line:no-duplicate-imports
import {default as _rollupMoment} from 'moment';

const moment = _rollupMoment || _moment;

@Injectable({
    providedIn: 'root'
})
export class DateConverter{

    public momentRef = moment

    public StringToUtcMomentJson(date: string) : string{
        return moment(date).utc().toJSON()
    }

    // public ConvertStringToMoment(date: string) : _moment.Moment{
    //     return moment(date, 'YYYY-MM-DD HH:mm:ss')
    // }

    public ConvertUtcToLocalDate(date: string) : string{
        return moment.utc(date).local().format('YYYY.MM.DD.')
    }

    public ConvertLocalToUtcDate(date:string) : string {
        return moment.utc(date, 'YYYY-MM-DD HH:mm:ss').format('YYYY.MM.DD.')
    }

    public ConvertUtcToLocalFullDate(date: string) : string{
        return moment.utc(date).local().format('YYYY.MM.DD. HH:mm:ss')
    }

    public ConvertFormattedUtcToLocalDate(date: string) : string{
        return moment.utc(date,'DD/MM/YYYY HH:mm:ss').local().format('YYYY.MM.DD.')
    }


    // Time converter
    public ConvertInputToTimeSpan(input: string) : void{
        
    }

    
}
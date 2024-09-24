import { Injectable } from "@angular/core";
import { TaskItemPriority } from "../_models/tasklistpriority";

@Injectable({
    providedIn: 'root'
})
export class PriorityConverter{
    public ConvertPriorityToString(priority: TaskItemPriority) : string {
        if (priority.toString() == '0'){
            return 'Low'
        }
        else if (priority.toString() == '1'){
            return 'Normal'
        }
        else if (priority.toString() == '2'){
            return 'High'
        }
        return 'Error with Priority convert! Current value is: ' + priority.toString()
    }
}
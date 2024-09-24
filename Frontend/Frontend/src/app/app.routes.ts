import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { ListComponent } from './list/list.component';
import { TaskComponent } from './task/task.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { ApiService } from './_services/api.service';
import { ProfileComponent } from './profile/profile.component';

export const routes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'lists', component: ListsComponent, canActivate: [ApiService] },
    { path: 'list/:id', component: ListComponent, canActivate: [ApiService] },
    { path: 'task/:id', component: TaskComponent, canActivate: [ApiService] },
    { path: 'statistics', component: StatisticsComponent, canActivate: [ApiService] },

    { path: 'profile', component: ProfileComponent, canActivate: [ApiService]},

    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'logout', component: LogoutComponent, canActivate: [ApiService] },
    
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

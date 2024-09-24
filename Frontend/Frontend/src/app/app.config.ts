import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './auth.interceptor';
import { provideCharts, withDefaultRegisterables } from 'ng2-charts';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    //provideClientHydration(), 
    provideAnimationsAsync(), 
    //provideHttpClient(withFetch()),
    provideHttpClient(
      withInterceptors([authInterceptor]),
      withFetch()
    ),
    provideCharts(withDefaultRegisterables())
  ]
};

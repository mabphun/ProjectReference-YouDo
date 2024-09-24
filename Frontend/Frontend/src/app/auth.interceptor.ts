import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const jwtToken = getJwtToken()
  //alert('interceptor')
  //console.log('interceptor');
  
  
  if (jwtToken){
    let cloned = req.clone({
      setHeaders: {
        Authorization: `Bearer ${jwtToken}`
      }
    })
    return next(cloned)
  }
  return next(req);
};

function getJwtToken(): string | null {
  let token = null
  if (typeof localStorage !== 'undefined'){
    token = localStorage.getItem('token')
  }
  return token
}

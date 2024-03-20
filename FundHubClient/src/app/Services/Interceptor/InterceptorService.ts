import {HttpEvent, HttpHandlerFn, HttpRequest} from "@angular/common/http";
import {Observable} from "rxjs";

export function loggingInterceptor(req: HttpRequest<any>, next: HttpHandlerFn): Observable<HttpEvent<any>> {
  /*
  if (typeof localStorage !== 'undefined') {
    let usertoken = localStorage.getItem('usertoken')
      const reqWithHeaderToken = req.clone({
        headers: req.headers.set('token', usertoken ),
      });
      return next(reqWithHeaderToken);
  }
  else {

  }
  */
  return next(req)
}

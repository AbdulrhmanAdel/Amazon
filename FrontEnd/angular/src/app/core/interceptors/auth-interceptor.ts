import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Observable} from "rxjs";
import {TokenService} from "../account/services/token-service";
import {Injectable} from "@angular/core";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private tokenService: TokenService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.tokenService.getToken();

    if (token == null) {
      return next.handle(req);
    }


    const updatedReq = req.clone( {
      headers: req.headers.append('Authorization', `Bearer ${token}`)
        .append('Accept-Language', `en`)
    });
    return next.handle(updatedReq);
  }
}

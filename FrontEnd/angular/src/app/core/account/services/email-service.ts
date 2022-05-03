import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {ApiResponse} from "../../responses/api-response";
import {BehaviorSubject, map, Observable} from "rxjs";
import {environment} from "../../../../environments/environment";

const baseUrl = environment.baseUrlV1;
@Injectable()
export class EmailService {

  constructor(private http: HttpClient) {
  }

  isEmailExists(email: string): Observable<boolean> {
    return  this.http.get<ApiResponse<boolean>>(`${baseUrl}/User/IsEmailExists?email=${email}`)
      .pipe(map(response => response.data));
  }
}

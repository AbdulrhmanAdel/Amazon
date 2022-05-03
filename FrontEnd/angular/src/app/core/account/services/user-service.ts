import {Injectable} from "@angular/core";
import {TokenService} from "./token-service";
import {UserLoginModel} from "../models/user-login-model";
import {BehaviorSubject, map, mergeMap, Observable, tap} from "rxjs";
import {ApiResponse} from "../../responses/api-response";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../../environments/environment";
import {UserSignupModel} from "../models/user-signup-model";
import {UserLoggedInModel} from "../models/user-loggedin-model";
import {AppState, CurrentUser} from "../../store/app-store";
import {Store} from "@ngrx/store";
import {CurrentUserLoadedAction} from "../../store/user/actions";

const baseUrl = environment.baseUrlV1;

@Injectable({providedIn: 'root'})
export class UserService {

  #currentUserSource = new BehaviorSubject<CurrentUser | null>(null);
  currentUser$ = this.#currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private tokenService: TokenService,
    private store: Store<AppState>) {
  }

  logIn(model: UserLoginModel): Observable<ApiResponse<UserLoggedInModel>> {
    return this.http.post<ApiResponse<any>>(`${baseUrl}/User/LogIn`, model)
      .pipe(tap(user => this.#currentUserSource.next(user.data)));
  }

  signUp(model: UserSignupModel): Observable<ApiResponse<UserLoggedInModel>> {
    const formData = new FormData();
    formData.append('email', model.email);
    formData.append('displayName', model.displayName);
    formData.append('password', model.password);
    formData.append('confirmPassword', model.confirmPassword);

    return this.http.post<ApiResponse<UserLoggedInModel>>(`${baseUrl}/User/SignUp`, formData, {})
      .pipe(tap(user => {
        this.#currentUserSource.next(user.data);
      }));
  }

  loadCurrentUser(): Observable<CurrentUser> {
    return this.http.get<ApiResponse<CurrentUser>>(`${baseUrl}/User/GetCurrentUser`)
      .pipe(
        map(response => response.data),
        tap(user => {
          this.store.dispatch(new CurrentUserLoadedAction(user));
          this.#currentUserSource.next(user);
        }));
  }

  logOut() {
    this.tokenService.removeToken();
    this.#currentUserSource.next(null);
  }

  isLoggedIn(): boolean {
    return this.tokenService.isTokenExists();
  }
}

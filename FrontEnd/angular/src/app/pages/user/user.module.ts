import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LoginComponent} from "./login/login.component";
import {UserRoutingModule} from "./user-routing-module";
import {FormsModule} from "@angular/forms";
import {StoreModule} from "@ngrx/store";
import currentUserReducer from '../../core/store/user/reducers';
import {EffectsModule} from "@ngrx/effects";
import {UserEffects} from "../../core/store/user/effects/user-effects";
import {TokenService} from "../../core/account/services/token-service";
import {UserService} from "../../core/account/services/user-service";
import {HttpClientModule} from "@angular/common/http";
import {SignupComponent} from './signup/signup.component';
import {EmailService} from "../../core/account/services/email-service";

@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    HttpClientModule,
    StoreModule.forFeature('currentUser', currentUserReducer),
    EffectsModule.forFeature([UserEffects])
  ],
  providers: [TokenService, UserService, EmailService],
  exports: []
})
export class UserModule {
}

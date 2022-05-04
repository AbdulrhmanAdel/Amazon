import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {StoreModule} from "@ngrx/store";
import {StoreDevtoolsModule} from "@ngrx/store-devtools";
import {EffectsModule} from "@ngrx/effects";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import interceptors from './core/interceptors/application-interceptors';
import { HeaderComponent } from './pages/header/header.component';
import {HttpClientModule} from "@angular/common/http";
import {routerReducer} from "@ngrx/router-store";
import {UserModule} from "./pages/user/user.module";
import {CartModule} from "./pages/cart/cart.module";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UserModule,
    CartModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    StoreModule.forRoot({router: routerReducer}),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument(),
  ],
  providers: [
    ...interceptors
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

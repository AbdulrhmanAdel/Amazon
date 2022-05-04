import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ShopComponent} from "./shop.component";
import {ShopRoutingModule} from "./shop-routing-module";
import {FormsModule} from "@angular/forms";
import {EffectsModule} from "@ngrx/effects";
import {CartEffects} from "../../core/store/cart/cart-effects";



@NgModule({
  declarations: [ShopComponent],
  imports: [
    CommonModule,
    ShopRoutingModule,
    FormsModule,
    EffectsModule.forFeature([CartEffects])
  ],
})
export class ShopModule { }

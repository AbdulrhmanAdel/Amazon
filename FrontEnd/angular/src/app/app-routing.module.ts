import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'user', loadChildren: () => import('./pages/user/user.module').then(m => m.UserModule)},
  {path: '', loadChildren: () => import('./pages/shop/shop.module').then(m => m.ShopModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/auth/auth.guard';
import { LoginComponent } from './management/user/login/login.component';
import { UserComponent } from './management/user/user.component';

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'user', component:UserComponent,},
  {path:'login', component:LoginComponent},
  {
    path: 'home',
    canActivate: [AuthGuard],
    loadChildren: () => import('./management/home/home.module').then(m => m.HomeModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

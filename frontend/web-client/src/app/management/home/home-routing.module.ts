import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/auth/auth.guard';
import { RoleConst } from 'src/environments/constant';
import { EmployeeComponent } from './employee/employee.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
    {
        path:'', component:HomeComponent,
        children:[
          {path:'employee', component:EmployeeComponent},
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
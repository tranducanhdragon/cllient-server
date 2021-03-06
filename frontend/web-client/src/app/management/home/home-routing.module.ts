import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/auth/auth.guard';
import { RoleConst } from 'src/environments/constant';
import { EmployeeComponent } from './employee/employee.component';
import { HomeComponent } from './home.component';
import { NKSLKComponent } from './nkslk/nkslk.component';
import { ThongkeComponent } from './thongke/thongke.component';
import { CongViecComponent } from './congviec/congviec.component';
import { SanPhamComponent } from './sanpham/sanpham.component';

const routes: Routes = [
    {
        path:'', component:HomeComponent,
        children:[
          {path:'employee', component:EmployeeComponent},
          {path:'nkslk', component:NKSLKComponent},
          {path:'thongke', component:ThongkeComponent},
          {path:'congviec', component:CongViecComponent},
          {path:'sanpham', component:SanPhamComponent},
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
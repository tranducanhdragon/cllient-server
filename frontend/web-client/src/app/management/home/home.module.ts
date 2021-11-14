import { NgModule } from '@angular/core';
import { HomeRoutingModule } from './home-routing.module';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home.component';
import { ToastModule } from 'primeng/toast';
import { HeaderComponent } from 'src/app/layout/header.component';
import { FooterComponent } from 'src/app/layout/footer.component';
import { EmployeeComponent } from './employee/employee.component';
import { CommonModule } from '@angular/common';
import { NKSLKComponent } from './nkslk/nkslk.component';
import { ThongkeComponent } from './thongke/thongke.component';
import { CongViecComponent } from './congviec/congviec.component';
import { SanPhamComponent } from './sanpham/sanpham.component';

@NgModule({
  declarations: [
    // layout
    HeaderComponent,
    FooterComponent,
    //component
    HomeComponent,
    EmployeeComponent,
    NKSLKComponent,
    ThongkeComponent,
    CongViecComponent,
    SanPhamComponent,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    NgbModule,
    ToastModule,
  ],
  providers: [],
  bootstrap: [HomeComponent]
})
export class HomeModule { }

import { NgModule } from '@angular/core';
import { HomeRoutingModule } from './home-routing.module';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home.component';
import { ToastModule } from 'primeng/toast';
import { HeaderComponent } from 'src/app/layout/header.component';
import { FooterComponent } from 'src/app/layout/footer.component';

@NgModule({
  declarations: [
    // layout
    HeaderComponent,
    FooterComponent,
    //component
    HomeComponent,
  ],
  imports: [
    HomeRoutingModule,
    FormsModule,
    NgbModule,
    ToastModule,
  ],
  providers: [],
  bootstrap: [HomeComponent]
})
export class HomeModule { }

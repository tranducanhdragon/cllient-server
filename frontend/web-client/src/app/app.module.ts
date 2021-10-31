import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { LoginComponent } from './management/user/login/login.component';
import { UserComponent } from './management/user/user.component';
import { HttpClientModule } from '@angular/common/http';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ToastModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

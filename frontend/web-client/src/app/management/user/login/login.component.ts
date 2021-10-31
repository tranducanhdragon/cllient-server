import { JsonpClientBackend } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { RoleConst } from 'src/environments/constant';
import { User } from 'src/model/user/user';
import { UserService } from 'src/service/user/user.service';

export enum UserState{
  login=1,
  register=2,
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [MessageService]
})
export class LoginComponent implements OnInit{
  user:User={};
  userState:UserState=UserState.login;
  state=UserState;

  constructor(
    private userService:UserService,
    private router: Router,
    private messageService: MessageService)
  {}

  ngOnInit(){

  }

  openRegister(){
    this.userState = this.state.register;
  }

  openLogin(){
    this.userState = this.state.login;
  }

  login(){
    this.userService.post('/api/User/login', this.user).subscribe(
      (res:any)=>{
        if(res && res.success){
          this.messageService.add({severity:'success', summary:'Thông báo', detail:'Đăng nhập thành công'});
          this.router.navigate(['/home']);
        }
        else{
          this.messageService.add({severity:'error', summary:'Thông báo', detail:'Đăng nhập thất bại'});
        }
      }
    )
  }
  register(){
    this.user.roleId=RoleConst.User;
    this.userService.post('/api/User/register', this.user).subscribe(
      (res:any)=>{
        if(res && res.success){
          this.messageService.add({severity:'success', summary:'Thông báo', detail:'Đăng ký thành công'});
        }
        else{
          this.messageService.add({severity:'error', summary:'Thông báo', detail:'Đăng ký thất bại'});
        }
      }
    )
  }

}

import { Component, ChangeDetectionStrategy } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/service/user/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent {
  constructor(
    private router: Router,
    private userService:UserService)
  {}
  logout(){
    debugger
    localStorage.removeItem("user");
    let user:any;
    this.userService.post("/api/User/logout", user).subscribe(
      (res:any)=>{
        this.router.navigate(['/login']);
      }
    )
  }
}

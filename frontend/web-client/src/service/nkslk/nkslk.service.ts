import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { RoleConst } from 'src/environments/constant';
import { NKSLK } from 'src/model/nkslk/nkslk';
import { BaseService } from '../base.service';
@Injectable({
  providedIn: 'root'
})
export class NKSLKService extends BaseService<NKSLK> {

  constructor(
    private http: HttpClient,
    private injector: Injector
  )
  {
    super(http, injector);
  }

//   roleMatch(userRoleId:any, roles:Array<number>): boolean {
//     if(roles && roles.includes(userRoleId)){
//       return true;
//     }
//     return false;
//   }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { RoleConst } from 'src/environments/constant';
import { NKSLK, NKSLKChiTiet, NKSLKChiTietCreate } from 'src/model/nkslk/nkslk';
import { BaseService } from '../base.service';
const BaseURL = 'http://localhost:44260';

@Injectable({
  providedIn: 'root'
})
export class NKSLKService{

  constructor(
    private http: HttpClient,
    private injector: Injector
  )
  {
  }
  getAllData(url:string){
    return this.http.get<NKSLKChiTiet[]>(BaseURL+url)
    .pipe(catchError(err => this.handleError(err, this.injector)));
  }
  postNKSLK(url: string, data:any): Observable<any> {
    return this.http.post(BaseURL+url, data)
        .pipe(catchError(err => this.handleError(err, this.injector)));
  }
  async handleError(error: any, injector: Injector) {
    console.error('Có lỗi xảy ra', error);
    return Promise.reject(error);
  }

//   roleMatch(userRoleId:any, roles:Array<number>): boolean {
//     if(roles && roles.includes(userRoleId)){
//       return true;
//     }
//     return false;
//   }
}

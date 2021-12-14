import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { RoleConst } from 'src/environments/constant';
import { SanPham } from 'src/model/sanpham/sanpham';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';

const BaseURL = 'http://localhost:44260';

@Injectable({
  providedIn: 'root'
})
export class SanPhamService extends BaseService<SanPham> {

  constructor(
    private http: HttpClient,
    private injector: Injector
  )
  {
    super(http, injector);
  }
  getDate(url: string, data:String): Observable<any> {
    
    return this.http.get(BaseURL+url+"?date=" + data)
        .pipe(catchError(err => this.handleErrorCustom(err, this.injector)));
  }

  getDateEnd(url: string, data:number): Observable<any> {
    
    return this.http.get(BaseURL+url+"?soNam=" + data)
        .pipe(catchError(err => this.handleErrorCustom(err, this.injector)));
  }

  async handleErrorCustom(error: any, injector: Injector) {
    console.error('Có lỗi xảy ra', error);
    return Promise.reject(error);
  }
  
  
}

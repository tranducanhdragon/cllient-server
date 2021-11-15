import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { RoleConst } from 'src/environments/constant';
import { SanPham } from 'src/model/sanpham/sanpham';
import { BaseService } from '../base.service';

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
}

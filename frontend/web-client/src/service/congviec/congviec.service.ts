import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { RoleConst } from 'src/environments/constant';
import { Employee } from 'src/model/employee/employee';
import { CongViec } from 'src/model/thongke/congviec';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class CongViecService extends BaseService<CongViec> {

  constructor(
    private http: HttpClient,
    private injector: Injector
  )
  {
    super(http, injector);
  }
}

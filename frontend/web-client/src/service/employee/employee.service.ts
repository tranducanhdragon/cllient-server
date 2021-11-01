import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { RoleConst } from 'src/environments/constant';
import { Employee } from 'src/model/employee/employee';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService<Employee> {

  constructor(
    private http: HttpClient,
    private injector: Injector
  )
  {
    super(http, injector);
  }
}

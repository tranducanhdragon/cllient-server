import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { Employee } from 'src/model/employee/employee';
import { EmployeeService } from 'src/service/employee/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees:Observable<Employee[]> | undefined;
  constructor(private employeeService:EmployeeService) { }

  ngOnInit(): void {
    this.getEmployees();
  }
  getEmployees(){
    debugger
    this.employees = this.employeeService.getAllData('/api/Employee/getall');
  }
}

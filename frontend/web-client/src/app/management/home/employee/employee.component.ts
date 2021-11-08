import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
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
  constructor(private employeeService:EmployeeService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getEmployees();
  }
  getEmployees(){
    debugger
    this.employees = this.employeeService.getAllData('/api/Employee/getall');
  }
  open(data:any){
    this.modalService.open(data);
  }
  deleteEmployee(employee:Employee){
    if (!employee.maNhanCong) {
      throw new Error("Unexpected error: Missing name");
  }
  
  let name1: string = employee.maNhanCong;
    this.employeeService.delete('/api/Employee/delete', name1);
  }
}

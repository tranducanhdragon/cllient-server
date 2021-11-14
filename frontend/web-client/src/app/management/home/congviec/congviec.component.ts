import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { CongViec } from 'src/model/congviec/congviec';
import { CongViecService } from 'src/service/congviec/congviec.service';

@Component({
  selector: 'app-employee',
  templateUrl: './congviec.component.html',
  styleUrls: ['./congviec.component.css']
})
export class CongViecComponent implements OnInit {
  employees:Observable<CongViec[]> | undefined;
  constructor(private employeeService:CongViecService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getEmployees();
  }
  getEmployees(){
    this.employees = this.employeeService.getAllData('/api/CongViec/getall');
  }
  open(data:any){
    this.modalService.open(data);
  }
  deleteEmployee(employee:CongViec){

  }
}

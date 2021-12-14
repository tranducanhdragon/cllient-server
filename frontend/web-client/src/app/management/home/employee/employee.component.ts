import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { Employee } from 'src/model/employee/employee';
import { EmployeeService } from 'src/service/employee/employee.service';

import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees:Observable<Employee[]> | undefined;
  employeesSapNghiHuu:Observable<Employee[]> | undefined;
  employees30_45:Observable<Employee[]> | undefined;
  employeesCa3:Observable<Employee[]> | undefined;
  employee:Employee={};
  constructor(private employeeService:EmployeeService,
    private modalService:NgbModal) { }
    
  ngOnInit(): void {
    this.getEmployees();
  }
  public getEmployees(){
    this.employees = this.employeeService.getAllData('/api/Employee/getall');
    this.employeesSapNghiHuu = this.employeeService.getAllData('/api/Employee/nhanCongSapNghiHuu');
    this.employees30_45 = this.employeeService.getAllData('/api/Employee/nhanCong30_45');
    this.employeesCa3 = this.employeeService.getAllData('/api/Employee/nhanCongCa3');
  }

  reloadAll(){

    (async () => {

      await delay(1000);
      this.getEmployees();
  })();
  }

  
  open(data:any){
    this.modalService.open(data);
  }
  deleteEmployee(employee:Employee){
    if (!employee.maNhanCong) {
      throw new Error("Unexpected error: Missing name");
    }
    let name1: string = employee.maNhanCong;
    // this.employeeService.deleteById('/api/Employee/deletebyid?mamanhancong=', name1);
    this.employeeService.deleteById('/api/Employee/deletebyid?manhancong=', name1).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
        }
      }
    )
    this.reloadAll();
    this.notifi("Đã xóa thành công");
  }

  createEmployee(){
    const app = document.getElementById("modalOne");
    app!.style.display = "block";
  }
  edit_employee(edit_employee: Employee){
    console.log(edit_employee);
    const app = document.getElementById("modal2");
    app!.style.display = "block";
    
    document.getElementById("edit_holder")?.setAttribute('value', edit_employee.maNhanCong as string);
    document.getElementById("edit_name")?.setAttribute('value', edit_employee.hoTen as string);
    document.getElementById("edit_ngaySinh")?.setAttribute('value', String(edit_employee.ngaySinh));
    document.getElementById("edit_gioiTinh")?.setAttribute('value', String(edit_employee.gioiTinh));
    document.getElementById("edit_phongBan")?.setAttribute('value', edit_employee.phongBan as string);
    document.getElementById("edit_chucVu")?.setAttribute('value', edit_employee.chucVu as string);
    document.getElementById("edit_queQuan")?.setAttribute('value', edit_employee.queQuan as string);
    document.getElementById("edit_luongBaoHiem")?.setAttribute('value', String(edit_employee.luongBaoHiem));

    // <input type="date" id="edit_ngaySinh" [(ngModel)]="employee.ngaySinh" >
    //     <input type="number" id="edit_gioiTinh" [(ngModel)]="employee.gioiTinh" >
    //     <input type="text" id="edit_phongBan" [(ngModel)]="employee.phongBan" >
    //     <input type="text" id="edit_chucVu" [(ngModel)]="employee.chucVu">
    //     <input type="text" id="edit_queQuan" [(ngModel)]="employee.queQuan" >
    //     <input type="number" id="edit_luongBaoHiem" [(ngModel)]="employee.luongBaoHiem" >
  }


  closePopup() {
    const app = document.getElementById("modalOne");
    app!.style.display = "none";
    const app1 = document.getElementById("modal2");
    app1!.style.display = "none";
  }
  editEmployee(employee: Employee){
    this.notifi("Tính năng đang hoàn thiệt! Vui lòng sử dụng sau ^^");
  }

  submitCreateEmployee(){
    console.log(this.employee);
    this.employeeService.post('/api/Employee/insert', this.employee).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
        }
      }
    )
    this.reloadAll();
    this.closePopup();
    this.notifi("Thêm công việc thành công");
  }
  
  notifi(content:string){
    window.alert(content);
  }

  submitEditEmployee(){
    
    // document.getElementById("edit_name")?.setAttribute('value', edit_employee.hoTen as string);
    // document.getElementById("edit_ngaySinh")?.setAttribute('value', String(edit_employee.ngaySinh));
    // document.getElementById("edit_gioiTinh")?.setAttribute('value', String(edit_employee.gioiTinh));
    // document.getElementById("edit_phongBan")?.setAttribute('value', edit_employee.phongBan as string);
    // document.getElementById("edit_chucVu")?.setAttribute('value', edit_employee.chucVu as string);
    // document.getElementById("edit_queQuan")?.setAttribute('value', edit_employee.queQuan as string);
    // document.getElementById("edit_luongBaoHiem")?.setAttribute('value', String(edit_employee.luongBaoHiem));
    this.employee.maNhanCong = (<HTMLInputElement>document.getElementById("edit_holder")).value;
    this.employee.hoTen = (<HTMLInputElement>document.getElementById("edit_name")).value;
    var a: string = (<HTMLInputElement>document.getElementById("edit_ngaySinh")).value;
    if (a == null){
      this.employee.ngaySinh = new Date;
    }
    else{
      this.employee.ngaySinh = new Date(a);
    }
    console.log((<HTMLInputElement>document.getElementById("edit_ngaySinh")).value);
    this.employee.gioiTinh = Number((<HTMLInputElement>document.getElementById("edit_gioiTinh")).value);
    this.employee.phongBan = (<HTMLInputElement>document.getElementById("edit_phongBan")).value;
    this.employee.chucVu = (<HTMLInputElement>document.getElementById("edit_chucVu")).value;
    this.employee.queQuan = (<HTMLInputElement>document.getElementById("edit_queQuan")).value;
    this.employee.luongBaoHiem = Number((<HTMLInputElement>document.getElementById("edit_luongBaoHiem")).value);

    console.log(this.employee);
    this.employeeService.post('/api/Employee/updateEmployee', this.employee).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
        }
      }
    )
    this.reloadAll();
    this.closePopup();
    this.notifi("Sửa công việc thành công");
  }


  
}

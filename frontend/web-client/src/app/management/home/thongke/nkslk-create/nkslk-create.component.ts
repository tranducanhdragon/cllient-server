import { Component, Input, OnInit } from '@angular/core';
import { Employee } from 'src/model/employee/employee';
import { NKSLKChiTiet, NKSLKChiTietCreate, NKSLKNhanCongChiTiet } from 'src/model/nkslk/nkslk';
import { CongViec } from 'src/model/thongke/congviec';
import { NhanCongThang, NKSLKNhanCong } from 'src/model/thongke/nkslknhancong';
import { EmployeeService } from 'src/service/employee/employee.service';
import { ThongKeService } from 'src/service/thongke/thongke.service';
import { NKSLKService } from 'src/service/nkslk/nkslk.service';

@Component({
  selector: 'app-nkslk-create',
  templateUrl: './nkslk-create.component.html',
  styleUrls: ['./nkslk-create.component.css']
})
export class NkslkCreateComponent implements OnInit {
  @Input() month:number=0;
  @Input() detail:NhanCongThang={};
  nkslk:NKSLKChiTietCreate={};
  congviecs:CongViec[]=[];
  congnhans:Employee[]=[];
  constructor(private thongkeService:ThongKeService,
    private employeeService:EmployeeService,
    private NKSLKService:NKSLKService) { }

  ngOnInit(): void {
    this.getAllCongViec();
    this.getAllNhanCong();
  }
  submitCreateNKSLK(){
    debugger
    let e = document.getElementById('ddCongViec') as HTMLInputElement;
    this.nkslk.MaNhanCong = this.detail.maNhanCong;
    this.nkslk.maCongViec = parseInt(e.value)??0;
    this.NKSLKService.postNKSLK('/api/NKSLK/insertnkslk',this.nkslk).subscribe(
      (res:any) => {
        if(res == true){
          alert("Success");
        }
      }
    )
  }
  getAllNhanCong(){
    this.employeeService.getAllData('/api/Employee/getall').subscribe(
      (res:any) => {
        this.congnhans = res;
      }
    );
  }
  getAllCongViec(){
    this.thongkeService.getAllData('/api/ThongKe/getallcongviec').subscribe(
      (res:any) => {
        if(res){
          this.congviecs = res;
        }
      }
    )
  }
}

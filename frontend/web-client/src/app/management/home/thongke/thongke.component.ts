import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CongViec } from 'src/model/thongke/congviec';
import { CongViecMaxSLK } from 'src/model/thongke/congviecmaxslk';
import { LuongNhanCong } from 'src/model/thongke/luongnhancong';
import { NhanCongThang } from 'src/model/thongke/nkslknhancong';
import { ThongKeService } from 'src/service/thongke/thongke.service';
import { NKSLKDetailComponent } from './nkslk-detail/nkslk-detail.component';

@Component({
  selector: 'app-thongke',
  templateUrl: './thongke.component.html',
  styleUrls: ['./thongke.component.css']
})
export class ThongkeComponent implements OnInit {
  congviecmaxslk:CongViecMaxSLK={};
  congviecdongiamax:CongViec={};
  congviecdongiamin:CongViec={};
  congvieclonhondontb:CongViec[]=[];
  congviecnhohondontb:CongViec[]=[];
  nhancongthang:NhanCongThang[]=[];
  month:number=1;
  congviecs:CongViec[]=[];
  luongnhancong:LuongNhanCong[]=[];
  constructor(private thongkeService:ThongKeService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getCongViecMaxSLK();
    this.getCongViecDonGiaMax();
    this.getCongViecDonGiaMin();
    this.getCongViecLonHonDonTB();
    this.getCongViecNhoHonDonTB();
    this.getAllCongViec();
  }
  getCongViecMaxSLK(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecmaxslk').subscribe(
      (res:any) => {
        if(res){
          this.congviecmaxslk = res;
        }
      }
    )
  }
  getCongViecDonGiaMax(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecdongiamax').subscribe(
      (res:any) => {
        if(res){
          this.congviecdongiamax = res;
        }
      }
    )
  }
  getCongViecDonGiaMin(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecdongiamin').subscribe(
      (res:any) => {
        if(res){
          this.congviecdongiamin = res;
        }
      }
    )
  }
  getCongViecLonHonDonTB(){
    this.thongkeService.getAllData('/api/ThongKe/getcongvieclonhondontb').subscribe(
      (res:any) => {
        if(res){
          this.congvieclonhondontb = res;
        }
      }
    )
  }
  getCongViecNhoHonDonTB(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecnhohondontb').subscribe(
      (res:any) => {
        if(res){
          this.congviecnhohondontb = res;
        }
      }
    )
  }
  getAllCongNhanThang(){
    this.thongkeService.get('/api/ThongKe/getallnhancongthang?thang='+this.month).subscribe(
      (res:any) => {
        if(res){
          this.nhancongthang = res;
        }
      }
    )
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
  getAllLuongCongNhanByThangCongViec(){
    let e = document.getElementById('ddCongViec') as HTMLInputElement;    
    this.thongkeService.getAllData('/api/ThongKe/getluongnhancongbythangcongviec?thang='+this.month+'&macongviec='+e.value).subscribe(
      (res:any) => {
        if(res){
          this.luongnhancong = res;
        }
      }
    )
  }
  openNKSLKDetail(data:any){
    let modalRef = this.modalService.open(NKSLKDetailComponent);
    modalRef.componentInstance.detail = data;
    modalRef.componentInstance.month = this.month;
  }
}

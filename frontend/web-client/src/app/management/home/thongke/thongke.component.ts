import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CongViec } from 'src/model/thongke/congviec';
import { CongViecMaxSLK } from 'src/model/thongke/congviecmaxslk';
import { NhanCongThang, NKSLKCongNhan } from 'src/model/thongke/nkslkcongnhan';
import { ThongKeService } from 'src/service/thongke/thongke.service';
import { DetailComponent } from './detail/detail.component';

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
  constructor(private thongkeService:ThongKeService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getCongViecMaxSLK();
    this.getCongViecDonGiaMax();
    this.getCongViecDonGiaMin();
    this.getCongViecLonHonDonTB();
    this.getCongViecNhoHonDonTB();
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
    this.thongkeService.post('/api/ThongKe/getallnhancongthang', this.month).subscribe(
      (res:any) => {
        if(res){
          this.nhancongthang = res;
        }
      }
    )
  }
  openDetail(data:any){
    let modalRef = this.modalService.open(DetailComponent);
    modalRef.componentInstance.detail = data;
  }
}

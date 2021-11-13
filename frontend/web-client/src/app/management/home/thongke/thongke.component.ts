import { Component, OnInit } from '@angular/core';
import { CongViec } from 'src/model/thongke/congviec';
import { CongViecMaxSLK } from 'src/model/thongke/congviecmaxslk';
import { NKSLKCongNhan } from 'src/model/thongke/nkslkcongnhan';
import { ThongKeService } from 'src/service/thongke/thongke.service';

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
  nkslkcongnhanthang:NKSLKCongNhan[]=[];
  month:number=1;
  constructor(private thongkeService:ThongKeService) { }

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
  getNKSLKCongNhanThang(){
    debugger
    this.thongkeService.post('/api/ThongKe/getnkslkcongnhanthang', this.month).subscribe(
      (res:any) => {
        if(res){
          this.nkslkcongnhanthang = res;
        }
      }
    )
  }
}

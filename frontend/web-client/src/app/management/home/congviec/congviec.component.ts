import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { CongViec } from 'src/model/congviec/congviec';
import { CongViecService } from 'src/service/congviec/congviec.service';

import { CongViecMaxSLK } from 'src/model/thongke/congviecmaxslk';
import { ThongKeService } from 'src/service/thongke/thongke.service';

@Component({
  selector: 'app-congviec',
  templateUrl: './congviec.component.html',
  styleUrls: ['./congviec.component.css']
})
export class CongViecComponent implements OnInit {
  congviecmaxslk:CongViecMaxSLK={};
  congviecdongiamax:CongViec={};
  congviecdongiamin:CongViec={};
  congViecs:Observable<CongViec[]> | undefined;
  constructor(private congViecService:CongViecService,
    private modalService:NgbModal,
    private thongkeService:ThongKeService) { }

  ngOnInit(): void {
    this.getCongViecs();
    this.getCongViecMaxSLK();
    this.getCongViecDonGiaMax();
    this.getCongViecDonGiaMin();
  }
  getCongViecs(){
    this.congViecs = this.congViecService.getAllData('/api/CongViec/getall');
  }
  open(data:any){
    this.modalService.open(data);
  }
    /* Huynh them goi api  */
  getCongViecMaxSLK(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecmaxslk').subscribe(
      (res:any) => {
        if(res){
          this.congviecmaxslk = res;
        }
      }
    )
  }
  /* Huynh them goi api  */
  getCongViecDonGiaMax(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecdongiamax').subscribe(
      (res:any) => {
        if(res){
          this.congviecdongiamax = res;
        }
      }
    )
  }
    /* Huynh them goi api  */
  getCongViecDonGiaMin(){
    this.thongkeService.getAllData('/api/ThongKe/getcongviecdongiamin').subscribe(
      (res:any) => {
        if(res){
          this.congviecdongiamin = res;
        }
      }
    )
  }
  deleteCongViec(congViec:CongViec){

  }
}

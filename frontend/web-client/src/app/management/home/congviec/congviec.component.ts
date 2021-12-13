import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { CongViec } from 'src/model/congviec/congviec';
import { CongViecService } from 'src/service/congviec/congviec.service';

import { CongViecMaxSLK } from 'src/model/thongke/congviecmaxslk';
import { ThongKeService } from 'src/service/thongke/thongke.service';

import { delay } from 'rxjs/operators';


@Component({
  selector: 'app-congviec',
  templateUrl: './congviec.component.html',
  styleUrls: ['./congviec.component.css']
})
export class CongViecComponent implements OnInit {
  congviecmaxslk:CongViecMaxSLK={};
  congviecdongiamax:CongViec={};
  congviecdongiamin:CongViec={};
  congvieclonhondontb:CongViec[]=[];
  congviecnhohondontb:CongViec[]=[];
  congViecs:Observable<CongViec[]> | undefined;
  congViec:CongViec={};
  congViecNeedUpdate:CongViec={};
  constructor(private congViecService:CongViecService,
    private modalService:NgbModal,
    private thongkeService:ThongKeService) { }

    

  ngOnInit(): void {
    this.getCongViecs();
    this.getCongViecMaxSLK();
    this.getCongViecDonGiaMax();
    this.getCongViecDonGiaMin();
    this.getCongViecLonHonDonTB();
    this.getCongViecNhoHonDonTB();
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

  insertCongViecToDb() {
    console.log(this.congViec);
    // huynh can phai check kieu so, dung format
    this.congViecService.post('/api/CongViec/createcongviec', this.congViec).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
        }
      }
    )

    //load lai data 
    this.reloadAll();
    // dong popup 
    this.closePopup();

    this.notifi("Thêm công việc thành công");
  }


  creatCongViec(){
    const app = document.getElementById("modalOne");
    app!.style.display = "block";
    
  }
  closePopup() {
    const app = document.getElementById("modalOne");
    app!.style.display = "none";
  }

  editCongViec(congViec: CongViec){

    this.congViecNeedUpdate = congViec;
    const app = document.getElementById("modalOneUpdate");
    app!.style.display = "block";
  }
  closePopupUpdateCongViec(){
    const app = document.getElementById("modalOneUpdate");
    app!.style.display = "none"
  }

  updateCongViec() {
    
    console.log(this.congViecNeedUpdate);
    this.congViecService.put('/api/CongViec/updateCongViec', this.congViecNeedUpdate).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
        }
      }
    )
     //load lai data 
     this.reloadAll();
     // dong popup 
     this.closePopupUpdateCongViec();
 
     this.notifi("Sửa công việc thành công");
  }

  deleteCongViec(congViec: CongViec){
    console.log(congViec);
    
    this.congViecService.delete('/api/CongViec/deleteCongViecWithId', (congViec.maCongViec??0).toString()).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
        }
      }
    )

    //load lai data 
    this.reloadAll();
    this.notifi("Đã xóa thành công");
  }

  reloadAll(){

    (async () => {

      await delay(1000);
      this.getCongViecs();
      this.getCongViecMaxSLK();
      this.getCongViecDonGiaMax();
      this.getCongViecDonGiaMin();
      this.getCongViecLonHonDonTB();
      this.getCongViecNhoHonDonTB();
  })();
    
  }


  notifi(content:string){
    window.alert(content);
  }
}

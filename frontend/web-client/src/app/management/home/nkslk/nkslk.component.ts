import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { NKSLK, NKSLKChiTiet } from 'src/model/nkslk/nkslk';
import { NhanCongThang } from 'src/model/thongke/nkslknhancong';
import { NKSLKService } from 'src/service/nkslk/nkslk.service';
import { ThongKeService } from 'src/service/thongke/thongke.service';
import { NKSLKDetailComponent } from '../thongke/nkslk-detail/nkslk-detail.component';
@Component({
  selector: 'app-nkslk',
  templateUrl: './nkslk.component.html',
  styleUrls: ['./nkslk.component.css']
})
export class NKSLKComponent implements OnInit {
  month:number=1;
  nhancongthang:NhanCongThang[]=[];
  NKSLKs:Observable<NKSLKChiTiet[]> | undefined;
  constructor(private NKSLKService:NKSLKService,
    private thongkeService:ThongKeService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getNKSLKs();
  }
  getNKSLKs(){
    this.NKSLKs = this.NKSLKService.getAllData('/api/NKSLK/getallnkslkchitiets');
  }
  open(data:any){
    this.modalService.open(data);
  }
  deleteNKSLK(NKSLK:NKSLK){
    // this.NKSLKService.delete('/api/NKSLK/delete', String(NKSLK.maNkslk));
  }
  openNKSLKDetail(data:any){
    let modalRef = this.modalService.open(NKSLKDetailComponent);
    modalRef.componentInstance.detail = data;
    modalRef.componentInstance.month = this.month;
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
}

import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { CongViec } from 'src/model/congviec/congviec';
import { CongViecService } from 'src/service/congviec/congviec.service';

@Component({
  selector: 'app-congviec',
  templateUrl: './congviec.component.html',
  styleUrls: ['./congviec.component.css']
})
export class CongViecComponent implements OnInit {
  congViecs:Observable<CongViec[]> | undefined;
  constructor(private congViecService:CongViecService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getCongViecs();
  }
  getCongViecs(){
    this.congViecs = this.congViecService.getAllData('/api/CongViec/getall');
  }
  open(data:any){
    this.modalService.open(data);
  }
  deleteCongViec(congViec:CongViec){

  }
}

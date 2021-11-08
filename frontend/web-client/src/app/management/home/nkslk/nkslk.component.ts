import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { NKSLK } from 'src/model/nkslk/nkslk';
import { NKSLKService } from 'src/service/nkslk/nkslk.service';
@Component({
  selector: 'app-nkslk',
  templateUrl: './nkslk.component.html',
  styleUrls: ['./nkslk.component.css']
})
export class NKSLKComponent implements OnInit {
  NKSLKs:Observable<NKSLK[]> | undefined;
  constructor(private NKSLKService:NKSLKService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getNKSLKs();
  }
  getNKSLKs(){
    debugger
    this.NKSLKs = this.NKSLKService.getAllData('/api/NKSLK/getall');
  }
  open(data:any){
    this.modalService.open(data);
  }
  deleteNKSLK(NKSLK:NKSLK){
    if (!NKSLK.maNkslk) {
      throw new Error("Unexpected error: Missing name");
  }
  
  let name1: number = NKSLK.maNkslk;
  
    this.NKSLKService.delete('/api/NKSLK/delete', String(name1));
  }
}

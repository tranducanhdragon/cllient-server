import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NhanCongThang, NKSLKNhanCong } from 'src/model/thongke/nkslknhancong';
import { ThongKeService } from 'src/service/thongke/thongke.service';

@Component({
  selector: 'app-detail',
  templateUrl: './nkslk-detail.component.html',
  styleUrls: ['./nkslk-detail.component.css']
})
export class NKSLKDetailComponent implements OnInit {
  @Input() detail:NhanCongThang={};
  @Input() month:number=0;
  nkslkNhanCong:NKSLKNhanCong[]=[];
  constructor(public activeModal: NgbActiveModal,
    private thongkeService:ThongKeService) {

  }

  ngOnInit(): void {
    this.getNKSLKNhanCongThang();
  }
  getNKSLKNhanCongThang(){
    this.thongkeService.getNKSLKNhanCongThang('/api/ThongKe/getnkslknhancongthang', this.detail.maNhanCong??0, this.month).subscribe(
      (res:any) => {
        if(res){
          this.nkslkNhanCong = res;
        }
      }
    )
  }
}

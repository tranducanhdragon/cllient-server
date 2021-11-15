import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NhanCongThang } from 'src/model/thongke/nkslkcongnhan';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  @Input() detail:NhanCongThang={};
  constructor(public activeModal: NgbActiveModal,
    ) { }

  ngOnInit(): void {
    
  }

}

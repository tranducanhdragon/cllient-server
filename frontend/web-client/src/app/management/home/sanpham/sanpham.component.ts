import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { SanPham } from 'src/model/sanpham/sanpham';
import { SanPhamService } from 'src/service/sanpham/sanpham.service';

@Component({
  selector: 'app-sanpham',
  templateUrl: './sanpham.component.html',
  styleUrls: ['./sanpham.component.css']
})
export class SanPhamComponent implements OnInit {
  sanPhams:Observable<SanPham[]> | undefined;
  constructor(private sanPhamService:SanPhamService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getSanPhams();
  }
  getSanPhams(){
    this.sanPhams = this.sanPhamService.getAllData('/api/SanPham/getall');
  }
  open(data:any){
    this.modalService.open(data);
  }
  
  creatSanPham(){
    this.notifi("Tính năng đang hoàn thiệt! Vui lòng sử dụng sau ^^");
  }

  editSanPham(sanPham: SanPham){
    this.notifi("Tính năng đang hoàn thiệt! Vui lòng sử dụng sau ^^");
  }
  deleteSanPham(sanPham:SanPham){
    this.notifi("Tính năng đang hoàn thiệt! Vui lòng sử dụng sau ^^");
  }

  notifi(content:string){
    window.alert(content);
  }
}

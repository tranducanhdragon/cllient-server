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
  
  sanPhamsBeforeDate:SanPham[]=[];
  dateSanPhamDangKyTruocNgay:string="2019-08-15";

  sanPhamsCoHanSuDung:SanPham[]=[];
  soNamSuDung:number=1;
  
  constructor(private sanPhamService:SanPhamService,
    private modalService:NgbModal) { }

  ngOnInit(): void {
    this.getSanPhams();
    this.getSanPhamDangKyTruocNgay();
    this.getSanPhamHanSuDungTrenSoNam();
  }
  getSanPhams(){
    this.sanPhams = this.sanPhamService.getAllData('/api/SanPham/getall');
  }

  getSanPhamDangKyTruocNgay() {

    this.sanPhamService.getDate('/api/SanPham/getSanPhamCoNgayDangKyTruocNgay',
    this.dateSanPhamDangKyTruocNgay).subscribe(
      (res:any) => {
        if(res){
          this.sanPhamsBeforeDate = res;
        }
        if(this.sanPhamsBeforeDate.length == 0) {
          this.notifi("Không có danh mục sản phẩm nào có ngày đăng ký trước ngày " + this.dateSanPhamDangKyTruocNgay)
        }
      }
    )

  }

  getSanPhamHanSuDungTrenSoNam(){

    this.sanPhamService.getDateEnd('/api/SanPham/getSanPhamCoHanSuDungTrenNam',
    this.soNamSuDung).subscribe(
      (res:any) => {
        if(res){
          this.sanPhamsCoHanSuDung = res;
        }
        if(this.sanPhamsCoHanSuDung.length == 0) {
          this.notifi("Không có danh mục các sản phẩm nào có hạn sử dụng trên "+ this.soNamSuDung +" năm từ ngày sản xuất.")
        }
      }
    )
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

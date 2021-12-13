import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { DataResponse } from 'src/model/dataresponse';
import { SanPham } from 'src/model/sanpham/sanpham';
import { SanPhamService } from 'src/service/sanpham/sanpham.service';

import { delay } from 'rxjs/operators';

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

  sanPhamNew:SanPham = {};
  sanPhamUpdate:SanPham = {};

  hanSuDung?:string ="";
  ngaySanXuat?:string="";
  ngayDangKy?:string="";
  
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
    const app = document.getElementById("modalOneSanPham");
    app!.style.display = "block";
  }


  closePopup() {
    const app = document.getElementById("modalOneSanPham");
    app!.style.display = "none";

    const appUpdateSp = document.getElementById("modalOneSanPhamUpdate");
    appUpdateSp!.style.display = "none";
  }

  editSanPham(sanPham: SanPham){
    console.log(sanPham);
    this.sanPhamUpdate = sanPham;

    this.hanSuDung =  this.sanPhamUpdate.hanSuDung?.toString().replace("T00:00:00","");
    this.ngaySanXuat =  this.sanPhamUpdate.ngaySanXuat?.toString().replace("T00:00:00","");
    this.ngayDangKy =  this.sanPhamUpdate.ngayDangKy?.toString().replace("T00:00:00","");

    const app = document.getElementById("modalOneSanPhamUpdate");
    app!.style.display = "block";
  }
  deleteSanPham(sanPham:SanPham){
    

    console.log(sanPham);
    
    this.sanPhamService.delete('/api/SanPham/deleteSanPhamWithId', (sanPham.maSanPham??0).toString()).subscribe(
      (res:any) => {
        console.log(res);
        if(!res){
          this.notifi("Sản phẩm này không xóa được.");
        }
        else {
          this.modalService.dismissAll();
          //load lai data 
          this.reloadAll();
          this.notifi("Đã xóa thành công");
        }
      }
    )
  }

  notifi(content:string){
    window.alert(content);
  }

  insertSanPhamToDb(){
    console.log(this.sanPhamNew);

    this.sanPhamService.post('/api/SanPham/createsanpham', this.sanPhamNew).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
          //load lai data 
          this.reloadAll();
          // dong popup 
          this.closePopup();

          this.notifi("Thêm sản phẩm thành công");
        } else {
          this.notifi("Thêm sản phẩm thất bại");
        }
      }
    )

  }

  reloadAll(){
    (async () => {

      await delay(1000);
      this.getSanPhams();
      this.getSanPhamDangKyTruocNgay();
      this.getSanPhamHanSuDungTrenSoNam();
  })(); 
   
  }

  updateSanPhamToDb() {

    this.sanPhamUpdate.hanSuDung = new Date(this.hanSuDung!);
    this.sanPhamUpdate.ngayDangKy = new Date(this.ngayDangKy!);
    this.sanPhamUpdate.ngaySanXuat= new Date(this.ngaySanXuat!);
    console.log(this.sanPhamUpdate)
    
    this.sanPhamService.put('/api/SanPham/updateSanPham', this.sanPhamUpdate).subscribe(
      (res:any) => {
        if(res){
          this.modalService.dismissAll();
          //load lai data 
          this.reloadAll();
          // dong popup 
          this.closePopup();
      
          this.notifi("Sửa sản phẩm thành công");
        } else {
          this.notifi("Sửa sản phẩm thất bại");
        }
      }
    )
  }
}

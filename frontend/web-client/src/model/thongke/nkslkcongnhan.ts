import { TimeSpan } from "./timespand";

export class NKSLKCongNhan{
    hoTen?:string;
    ngaySinh?:Date;
    phongBan?:string;
    chucVu?:string;
    gioiTinh?:number;
    ngayNKSLK?:number;
    gioBatDau?:TimeSpan=TimeSpan.zero;
    gioKetThuc?:TimeSpan=TimeSpan.zero;
}
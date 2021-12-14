import { TimeSpan } from "./timespand";

export class NKSLKNhanCong{
    hoTen?:string;
    ngaySinh?:Date;
    phongBan?:string;
    chucVu?:string;
    tenCongViec?:string;
    gioBatDau?:TimeSpan;
    gioKetThuc?:TimeSpan;
}
export class NhanCongThang{
    hoTen?:string;
    ngaySinh?:Date;
    phongBan?:string;
    chucVu?:string;
    gioiTinh?:number;
    ngayNKSLK?:number;
    maNhanCong?:number;
}
import { NumberLiteralType, StringLiteralLike } from "typescript";
import { TimeSpan } from "../thongke/timespand";

export interface NKSLK{
    ngay?: Date,
    maNkslk?: number,
}
export class NKSLKChiTiet{
    maNkslk?:number;
    maNhanCong?:number;
    gioBatDau?:TimeSpan;
    gioKetThuc?:TimeSpan;
    maChiTiet?:number;
    ngay?:string;
    maCongViec?:number;
}
export class NKSLKChiTietCreate{
    MaNhanCong?:number;
    gioBatDau?:TimeSpan;
    gioKetThuc?:TimeSpan;
    maCongViec?:number;
}

export class NKSLKNhanCongChiTiet{
    hoTen?:string;
    ngaySinh?:Date;
    phongBan?:string;
    chucVu?:string;
    tenCongViec?:string;
    gioBatDau?:TimeSpan;
    gioKetThuc?:TimeSpan;
    maCongViec?:number;
}
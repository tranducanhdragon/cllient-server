import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';

const BaseURL = 'http://localhost:44260';
@Injectable({
  providedIn: 'root'
})
export class ThongKeService{

  constructor(
    private _http: HttpClient,
    private _injector: Injector){

  }
  getAllData(url: string): Observable<any> {
    return this._http.get(BaseURL+url)
        .pipe(catchError(err => this.handleError(err, this._injector)));
  }
  post(url: string, data:any): Observable<any> {
    return this._http.post(BaseURL+url, data)
        .pipe(catchError(err => this.handleError(err, this._injector)));
  }
  get(url:string, param?:any):Observable<any>{
    return this._http.get(BaseURL + url, param)
        .pipe(catchError(err => this.handleError(err, this._injector)));
  }
  getNKSLKNhanCongThang(url:string, manhancong:number, thang:number){
    let params = new HttpParams();
    params = params.append('manhancong', manhancong);
    params = params.append('thang', thang);
    return this._http.get(BaseURL+url,{params:params})
        .pipe(catchError(err => this.handleError(err, this._injector)));
  }
  async handleError(error: any, injector: Injector) {
    console.error('Có lỗi xảy ra', error);
    return Promise.reject(error);
}
}

import { HttpClient } from '@angular/common/http';
import { Injector } from '@angular/core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/internal/operators/catchError';
import { DataResponse } from '../model/dataresponse';

const BaseURL = 'https://localhost:44366';

@Injectable()
export  class BaseService<T> {
    constructor(
        private _http: HttpClient,
        private _injector: Injector)
    {

    }

    post(url: string, item: T): Observable<DataResponse> {

        return this._http.post<DataResponse>(BaseURL+url, item)
            .pipe(catchError(err => this.handleError(err, this._injector)));
    }

    getAllData(url: string): Observable<any> {
        return this._http.get<DataResponse>(BaseURL+url)
            .pipe(catchError(err => this.handleError(err, this._injector)));
    }

    getById(url: string, id: string): Observable<DataResponse> {
        const apiUrl = BaseURL+url + `/${id}`;
        return this._http.get<DataResponse>(apiUrl)
            .pipe(catchError(err => this.handleError(err, this._injector)));
    }
    put(url: string, item: T): Observable<DataResponse> {

        return this._http.put<DataResponse>(BaseURL+url, item)
            .pipe(catchError(err => this.handleError(err, this._injector)));
    }
    delete(url: string, id: string): Observable<DataResponse> {
        const apiUrl = BaseURL+url + `/${id}`;
        return this._http.delete<DataResponse>(apiUrl)
            .pipe(catchError(err => this.handleError(err, this._injector)));

    }

    deleteMany(url: string, listId: any): Observable<DataResponse> {
        const apiUrl = BaseURL+url + `/deletemany`;
        return this._http.put<DataResponse>(apiUrl, listId)
            .pipe(catchError(err => this.handleError(err, this._injector)));
    }

    async handleError(error: any, injector: Injector) {
        console.error('Có lỗi xảy ra', error);
        return Promise.reject(error);
    }
}
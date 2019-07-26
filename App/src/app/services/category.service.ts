import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppSettings } from '../models/app-settings';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }
  private _urlBase = `${AppSettings.API_ENDPOINT}categories`;
  private _urlUpload = `${this._urlBase}/upload`;

  add(category: Category, files: File[]): Observable<Boolean> {

    const formdata: FormData = new FormData();
    formdata.append('data', JSON.stringify(category));

    if (files !== null) {
      files.forEach(file => {
        formdata.append(file.name, file);
      });
    }
    console.log( 'elarreglo', formdata);
    return this.http.post<boolean>(this._urlBase, formdata);
  }

  upload(formData :FormData){
    return this.http.post(this._urlUpload, formData, { reportProgress: true, observe: 'events' });
  }
}

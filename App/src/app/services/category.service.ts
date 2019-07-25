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
  private _url = `${AppSettings.API_ENDPOINT}categories`;

  add(category: Category, files: File[]): Observable<Boolean> {

    const formdata: FormData = new FormData();
    formdata.append('data', JSON.stringify(category));

    if (files !== null) {
      files.forEach(file => {
        formdata.append(file.name, file);
      });
    }
    console.log( 'elarreglo', formdata);
    return this.http.post<boolean>(this._url, formdata);
  }
}

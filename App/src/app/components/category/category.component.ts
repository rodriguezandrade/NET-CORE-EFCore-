import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';
import { HttpEventType } from '@angular/common/http';
import { AppSettings } from 'src/app/models/app-settings';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  private _urlPath = `${AppSettings.URL_PATH}`;
  categoryForm: FormGroup;
  fileArray: File[] = [];
  progress: number;
  message: string;
  onUploadFinished: any;
  constructor(private _categoryService: CategoryService) { }

  ngOnInit() {
    this.categoryForm = this.createFormGroup();
  }

  createFormGroup() {
    return new FormGroup({
      name: new FormControl()
    });
  }

  cleanArrayImage() {
    this.fileArray = [];
  }

  onFileChanged(event) {
    let file = event.target.files[0];
    this.fileArray.push(file);
    console.log('areglo condata', this.fileArray);

    file = [];
    console.log('file limpiado', file);

  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });

    this._categoryService.upload(formData).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response) {
        this.message = 'Upload success.';
        this.onUploadFinished.emit(event.body);
      }
    });
  }

  public createImgPath = (serverPath: string) => {  
    return `${this._urlPath} ${serverPath}`;
  }

  onSubmit() {
    const form: Category = Object.assign({}, this.categoryForm.value);
    this._categoryService.add(form, this.fileArray).subscribe(data => {
      console.log(data);
    })
  }

}

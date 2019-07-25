import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categoryForm: FormGroup;
  fileArray: File[] = [];
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

  onSubmit() {
    const form: Category = Object.assign({}, this.categoryForm.value);
    this._categoryService.add(form, this.fileArray).subscribe(data => {
      console.log(data);
    })
  }

}

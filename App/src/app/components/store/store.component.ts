import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  
  storeForm:FormGroup;
  constructor() {
    this.storeForm= this.createFormGroup();

   }
  
  ngOnInit() {
  }

  createFormGroup ()
  {
    return new FormGroup({
      nombre: new FormControl(),
      RFC: new FormControl(),
      ubicacion: new FormControl(),
      categoria: new FormControl()
    });

  }

onSubmit(){
  console.log(this.storeForm.value);
}

}

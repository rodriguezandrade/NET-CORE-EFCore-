import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent, } from './app.component';
import { MAIN_ROUTES, routingComponents } from './app.routing';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    NavbarComponent,
    AppComponent,
    routingComponents //Componentes
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    MAIN_ROUTES,
    HttpClientModule,
    RouterModule.forRoot([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

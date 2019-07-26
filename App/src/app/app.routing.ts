import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CategoryComponent } from './components/category/category.component';
import { StoreComponent } from './components/store/store.component';


const routes: Routes = [
    { path: 'Categories', component: CategoryComponent },
    { path: 'Stores', component: StoreComponent},
    { path: '**', component: CategoryComponent },
    {
        path: '**',
        redirectTo: '/',
        pathMatch: 'full'
    }
];



export const MAIN_ROUTES = RouterModule.forChild(routes);
export const routingComponents = [CategoryComponent, StoreComponent];
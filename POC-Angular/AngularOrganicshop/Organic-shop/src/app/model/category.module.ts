import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class CategoryModule { }
export interface Category{
  id:number;
  title:string;
  description:string;
}
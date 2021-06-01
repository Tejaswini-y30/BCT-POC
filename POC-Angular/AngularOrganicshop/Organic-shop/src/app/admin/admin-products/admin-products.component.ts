import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataTableResource } from 'angular7-data-table';
import { Subscription } from 'rxjs';
import { count } from 'rxjs/operators';
import { Product } from 'src/app/model/product.module';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit , OnDestroy{
  products:Product[];
  filteredProducts: Product[];
  subcription: Subscription;
  tableResource:DataTableResource<Product>;
  items:Product[]= [];
  itemCount:number;
  constructor(private productservice : ProductService) { 

    this.subcription=this.productservice.getAll().subscribe((data: any)=>{
      this.filteredProducts=this.products=data;
      this.initializeTable(data);
      
    });
    this.products
  }
  private initializeTable(products:Product[]){
    this.tableResource= new DataTableResource(products);
    this.tableResource.query({ offset:0})
      .then(items => this.items = items);
    this.tableResource.count()
      .then(count => this.itemCount =count)
  }

  reloadItems(params :any){
    if(!this.tableResource) return;
    this.tableResource.query(params)
      .then(items => this.items = items);
  }

  filter(query:string){
    console.log(query) 
    this.filteredProducts= query ?
    this.products.filter(p=> p.title.toLowerCase().includes(query.toLowerCase())) :
     this.products

    this.initializeTable(this.filteredProducts)
  }

  ngOnDestroy(){
    this.subcription.unsubscribe();
  }

  ngOnInit(): void {
  }

}

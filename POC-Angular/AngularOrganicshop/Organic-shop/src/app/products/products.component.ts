import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../model/product.module';

import { ProductService } from '../services/product.service';
import {switchMap} from 'rxjs/operators';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit , OnDestroy {
  products: Product[]=[];
  filteredProducts :Product[]=[];
  cart:any;
  subscription:Subscription;

  category:any;
  constructor( route: ActivatedRoute, productservice : ProductService, private cartservice : ShoppingCartService) { 
    
    
    
    productservice.getAll().pipe(switchMap((products:any)=>{
      //console.log( products);
      
      this.products=products;
      return route.queryParamMap;})).subscribe(params=>{
        this.category=params.get('category');
        this.filteredProducts=(this.category)?this.products.filter(p=>p.category===this.category):this.products;
      })
  }
  
  async ngOnInit() {
    this.subscription= (await this.cartservice.getItems()).subscribe(
      (data :any) =>{
        this.cart=data;
        //console.log(this.cart)
      }
    ) 
    
  }
  ngOnDestroy(){
    this.subscription.unsubscribe;
  }

}

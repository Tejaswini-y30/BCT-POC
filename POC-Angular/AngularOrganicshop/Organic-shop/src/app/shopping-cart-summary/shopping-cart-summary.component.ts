import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../model/product.module';
import { OrderService } from '../services/order.service';
import { ProductService } from '../services/product.service';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-shopping-cart-summary',
  templateUrl: './shopping-cart-summary.component.html',
  styleUrls: ['./shopping-cart-summary.component.css']
})
export class ShoppingCartSummaryComponent implements OnInit {
  cart:any;
  product:Product[]=[];
  totalprice:number=0;
  totalcount:number=0;
  constructor( private shoppingcartservice: ShoppingCartService,productservice: ProductService,private router :Router ,private orderservice : OrderService) {
    productservice.getAll().subscribe((products:any)=>{
      
      this.product=products;
      return this.product
   })
  
}
  reloadComponent() {  
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/shopping-cart'],{queryParamsHandling:'preserve'});
}

  ngOnInit(): void {
   
    this.shoppingcartservice.getItems().subscribe( data =>
      {
        this.cart=data;
        for (let i in this.cart){
          let d1=this.product.find((temp:any)=>temp.id==this.cart[i].id)  
          if (!d1) return
          this.cart[i]=({"id":this.cart[i].id,"quantity":this.cart[i].quantity,"title":d1.title,"price":this.cart[i].quantity * d1.price})
          this.totalprice += this.cart[i].price
          this.totalcount += this.cart[i].quantity
        }
      })
     
  }

  
    

  

}

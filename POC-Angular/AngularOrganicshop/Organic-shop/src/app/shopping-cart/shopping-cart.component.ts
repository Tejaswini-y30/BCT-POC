import { Component, OnInit } from '@angular/core';
import { Product } from '../model/product.module';
import { ProductService } from '../services/product.service';
import { ShoppingCartService } from '../services/shopping-cart.service';
import {switchMap} from 'rxjs/operators';
import { Router } from '@angular/router';
@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cart:any;
  product:Product[]=[];
  totalprice:number=0;
  totalcount:number=0;
  selectproduct:Product[]=[];
  constructor( private shoppingcartservice: ShoppingCartService,productservice: ProductService,private router :Router) {
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
        //console.log(this.cart.length)
        for (let i in this.cart){
          let d1=this.product.find((temp:any)=>temp.id==this.cart[i].id)  
          if (!d1) return
          this.cart[i]=({"id":this.cart[i].id,"quantity":this.cart[i].quantity,"title":d1.title,"imageUrl":d1.imageUrl,"price":this.cart[i].quantity * d1.price})
          this.totalprice += this.cart[i].price
          this.totalcount += this.cart[i].quantity
        }
      })
     
  }
  clearAll(){
    this.shoppingcartservice.clearAll();
    //this.reloadComponent()
    
  }
  removefromshipCart(id : any){
    this.shoppingcartservice.removefromshipcart(id)
  }
  addToshipCart(id : any){
    this.shoppingcartservice.addtoshipcart(id)
  }
}

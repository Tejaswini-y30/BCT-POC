import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../model/product.module';
import { ShoppingCartService } from '../services/shopping-cart.service';

@Component({
  selector: 'app-product-quantity',
  templateUrl: './product-quantity.component.html',
  styleUrls: ['./product-quantity.component.css']
})
export class ProductQuantityComponent  {
  @Input('product') product: Product;
  @Input('shopping-cart') shoppingCart : any; 
  item:any;
  constructor(private cartservice : ShoppingCartService,private router: Router) { }


  addToCart(){
    
      this.cartservice.addToCart(this.product);
     // this.getQuantity()
     //window.location.reload(); 
     window.location.reload(); 

  }
  removefromCart(){
    this.cartservice.removeFromCart(this.product);
    window.location.reload(); 
  }
  
  getQuantity(){
    
     if (!this.shoppingCart) return 0;
    //console.log(this.shoppingCart)
    /*for(let i of this.shoppingCart ){
      if (this.product.id == i.id){
        this.item=i;
      }      
    }*/
    if (this.shoppingCart.find((temp:any)=>temp.id==this.product.id)){
      let d1=this.shoppingCart.find((temp:any)=>temp.id==this.product.id)
      this.item=d1.quantity
      
    }
        //
    //console.log(this.item.quantity)
    return this.item ? this.item :0;
  }
}

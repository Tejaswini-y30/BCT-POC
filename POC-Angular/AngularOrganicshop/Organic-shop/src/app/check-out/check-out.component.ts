import { Component, OnDestroy, OnInit } from '@angular/core';
import { Product } from '../model/product.module';
import { ProductService } from '../services/product.service';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { Subscription } from 'rxjs';
import { CheckoutService } from '../services/checkout.service';
import { OrderService } from '../services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.css']
})
export class CheckOutComponent implements OnInit, OnDestroy {
  product:Product[]=[];
  shipping = {
    UserId:localStorage.getItem('Id'),
    name:"",
    address1:"",
    address2:"",
    city:""
  }
  Order = {
    id:"",
    name:"",
    quantity:"",
    price:"",
    date:""
  }
  shippingdetails = {
    name:"",
    date:"",
    quantity:0,
    price:0
  }
  totalprice:number=0;
  totalcount:number=0;
 // orders=[]
  userId:any;
  cart:any;
  subscription:Subscription;
  constructor(private shoppingcartservice:ShoppingCartService, productservice: ProductService,private router:Router ,private orderservice: OrderService,private checkoutservice :CheckoutService) { 
    productservice.getAll().subscribe((products:any)=>{
      
      this.product=products;
      return this.product
   })
   
   if(!this.shipping.UserId){
    this.router.navigate(['/login']);
   }
  }
  placeOrder() {
    this.checkoutservice.create(this.shipping)
    this.orderItems()
    this.shoppingcartservice.clearAll()
    //this.router.navigate(['/my/orders']);
    
  }  

  orderItems(){
    this.shoppingcartservice.getItems().subscribe( data =>
      {
        

        this.cart=data;
        for (let i in this.cart){
          let d1=this.product.find((temp:any)=>temp.id==this.cart[i].id)  
          if (!d1) return
          this.cart[i]=({"id":this.cart[i].id,"quantity":this.cart[i].quantity,"title":d1.title,"price":this.cart[i].quantity * d1.price})
          this.totalprice += this.cart[i].price
          this.totalcount += this.cart[i].quantity
          this.Order.id=this.cart[i].id
          this.Order.quantity=this.cart[i].quantity
          this.Order.price=this.cart[i].price
          this.Order.name=this.shipping.name
          this.Order.date= (new Date().getDate()).toString()+"/"+(new Date().getMonth()).toString()+"/"+(new Date().getFullYear()).toString()
          console.log(this.Order.date)
          this.orderservice.create(this.Order)
        }
        
        this.orderdetails()
      })
  }
  
  orderdetails(){
    this.shippingdetails.name=this.Order.name
    this.shippingdetails.date=this.Order.date
    this.shippingdetails.quantity=this.totalcount
    this.shippingdetails.price=this.totalprice
    console.log(this.shippingdetails)
    this.orderservice.createDetails(this.shippingdetails)
  }
  ngOnInit(): void {
    //let cart$=this.shoppingCartService.getrcreateCart()
    //this.subscription=cart$.subscribe((cart:any)=>this.cart=cart)
  }
  ngOnDestroy(){
    //this.subscription.unsubscribe()
  }

}

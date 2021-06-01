import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import { take } from 'rxjs/operators';
import { Product } from '../model/product.module';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  apiUrl="https://localhost:5001/api";
  cartId:number;
  my:any;
  l:number;
  qn:number;
  constructor(private http:HttpClient,private router :Router) { }
  reloadComponent() {  
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/'],{queryParamsHandling:'preserve'});
  }
  reloadShoppingcartdeleteComponent() {  
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/shopping-cart'],{queryParamsHandling:'preserve'});
}


  private create(){
  let cartId =localStorage.getItem('cartId');
  if(!cartId){
    this.cartId=1;
  }
    return this.http.post(`${this.apiUrl}/Cart/`,{"id":this.cartId })

  }
  getItems(){
    return this.http.get(`${this.apiUrl}/CartItem`)
  }
  async addToCart(product : Product){
    let item = this.getItems();
    item.pipe(take(1)).subscribe((data :any) =>{
      if (data.find((temp:any)=>temp.id==product.id)){
        let d1=data.find((temp:any)=>temp.id==product.id)
        return this.http.put(`${this.apiUrl}/CartItem/`+product.id,{"id":product.id ,"quantity": d1.quantity +1}).subscribe(
          data=>
          {console.log(data)
            
           // this.reloadComponent()
         })
      }
      else{
        return this.http.post(`${this.apiUrl}/CartItem`,{"id":product.id ,"quantity":1 }).subscribe(
          data=>{//console.log(data)
           
            //this.reloadComponent()
         })
      }
    })
      /*this.my=data;
      this.l=this.my.length;
      //console.log(data) 
      //console.log(this.my)   
      for (let i = 0; i <this.l ; i++){
        if (this.my[i].id==product.id){
          this.qn=this.my[i].quantity + 1
          console.log("quantity",this.qn)
          
          return this.http.put(`${this.apiUrl}/CartItem/`+product.id,{"id":productId ,"quantity":this.qn}).subscribe(
            data=>{console.log(data)
           })
        }
      }
      return this.http.put(`${this.apiUrl}/CartItem/`+productId,{"id":productId ,"quantity":1 }).subscribe(
        data=>{console.log(data)
       })
   
    })*/

    

    //return this.http.post(`${this.apiUrl}/CartItem`,{"id": productId})
  }

  async removeFromCart(product : Product){
    let item = this.getItems();
    item.pipe(take(1)).subscribe((data :any) =>{
      
        let d1=data.find((temp:any)=>temp.id==product.id)
        if (d1.quantity>1){
          return this.http.put(`${this.apiUrl}/CartItem/`+product.id,{"id":product.id ,"quantity": d1.quantity -1}).subscribe(
            data=>
            {//console.log(data)
             // this.reloadComponent()
          })
        }
        else{
          return this.http.delete(`${this.apiUrl}/cartItem/`+product.id).subscribe(
            data=>
            {//console.log(data)
              //this.reloadComponent()
          })
        }
    })
      
  }

  
  removefromshipcart(id :any){
    let item = this.getItems();
    item.pipe(take(1)).subscribe((data :any) =>{
      
        let d1=data.find((temp:any)=>temp.id==id)
        if (d1.quantity>1){
          return this.http.put(`${this.apiUrl}/CartItem/`+id,{"id":id ,"quantity": d1.quantity -1}).subscribe(
            data=>
            {//console.log(data)
              this.reloadShoppingcartdeleteComponent()
          })
        }
        else{
          return this.http.delete(`${this.apiUrl}/cartItem/`+id).subscribe(
            data=>
            {//console.log(data)
              this.reloadShoppingcartdeleteComponent()
          })
        }
    })
  }

  addtoshipcart(id :any){
    let item = this.getItems();
    item.pipe(take(1)).subscribe((data :any) =>{
      if (data.find((temp:any)=>temp.id==id)){
        let d1=data.find((temp:any)=>temp.id==id)
        return this.http.put(`${this.apiUrl}/CartItem/`+id,{"id":id ,"quantity": d1.quantity +1}).subscribe(
          data=>
          {//console.log(data)
            
           // this.reloadComponent()
           this.reloadShoppingcartdeleteComponent()
         })
      }
      else{
        return this.http.post(`${this.apiUrl}/CartItem`,{"id":id ,"quantity":1 }).subscribe(
          data=>{//console.log(data)
           
            //this.reloadComponent()
            this.reloadShoppingcartdeleteComponent()
         })
      }
    })
  }


  clearAll(){
    let item = this.getItems();
    item.pipe(take(1)).subscribe((data :any) =>{
      for ( let item in data){
        console.log(data[item])
        this.http.delete(`${this.apiUrl}/cartItem/`+data[item].id).subscribe(
          data=>
          {//console.log(data)
            //this.reloadShoppingcartdeleteComponent()
        })
      }
      window.location.reload(); 
      return "Deleted All"
    })
  }

 getrcreateCart(){
    let cartId = localStorage.getItem('cartId');
    if(!cartId){
      this.create().subscribe((result:any) =>{
        localStorage.setItem('cartId', result.id);
        //console.log(result.id)
        return this.getcart(result.id)
      })
    }
      return this.getcart(cartId)
    
  }
  getcart(cardId :any){
    //let cardId = this.create();
     return this.http.get(`${this.apiUrl}/cartId`)
     
  }
}

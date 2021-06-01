import { Component, OnInit } from '@angular/core';
import {UserService} from '../services/user.service';
import {Router, NavigationEnd,ActivatedRoute} from '@angular/router';
import { ShoppingCartService } from '../services/shopping-cart.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  username : string=localStorage.getItem('name')|| 'user';
  role : string ='customer';
  isAdmin:boolean=false;
  cartItemCount : number;
  constructor( public userService:UserService,private router: Router, private activatedRoute: ActivatedRoute, private shoppingcartservice : ShoppingCartService) {
   }
   reloadComponent() {  
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/'],{queryParamsHandling:'preserve'});
}

  ngOnInit(): void {

    this.shoppingcartservice.getItems().subscribe( (cart: any)=> {
      this.cartItemCount=0;
      for (let pro in cart){
        this.cartItemCount = this.cartItemCount + cart[pro].quantity
      }
      //console.log("nav-cart",this.cartItemCount)
    });

    //console.log(localStorage.getItem('role'))
    if(localStorage.getItem('role')=='admin'){
      this.isAdmin=true;
    }
    this.router.navigate([this.router.url]) 
    //console.log(this.userService.isloggedIn())
    
    
    
  }
logout(){
  this.userService.logout()
  window.location.reload();
}
}

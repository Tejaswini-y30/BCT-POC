import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot,Router, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import {UserService} from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGaurdGuard implements CanActivate {
  constructor(private userService:UserService,private router:Router){

  }
  canActivate(route:ActivatedRouteSnapshot,state:RouterStateSnapshot){
    if(this.userService.isloggedIn()){
      return true
    }
    else
    {
      this.router.navigate(['/login'],{queryParams:{returnUrl:state.url}});
      return false;
    }
  }
}

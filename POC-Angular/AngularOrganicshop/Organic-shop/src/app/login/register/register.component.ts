import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  newuser={
    "fullname":"",
    "email":"",
    "password":"",
    "role":"customer"

  }
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  constructor(public userService:UserService,private router:Router) { }

  ngOnInit(): void {
  }
  register(){
    this.userService.register(this.newuser)
    this.router.navigate(['/login']);
  }
}

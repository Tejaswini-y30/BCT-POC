import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {UserService} from '../services/user.service';
import {Router, NavigationEnd,ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  config:{
    name:string;
    userId:string;
    token:string;
  }
  data={
    email:'',
    password:''
  }
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  constructor(public userService:UserService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
   
  }
  onSubmit(event :any){
    let returnUrl=this.route.snapshot.queryParamMap.get('returnUrl')||'/';
    console.log(this.data)
        this.userService.login(this.data).subscribe(
          (data: any) =>{
            localStorage.setItem('Id',data.id)
            localStorage.setItem('role',data.role);
            localStorage.setItem('email',data.email);
            localStorage.setItem('name',data.fullname);
            console.log(data)
          },
          error=>{
            console.log(error);
          })  
          window.location.reload();  
      }
  /*data={
        email:'',
        password:'',
        token:''
      }
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  constructor(private Auth: AuthService) { }

  ngOnInit(): void {
  }

  

  loginUser(event :any){
    
    event.preventDefault()
    const target = event.target
    const username = target.querySelector('#email').value
    const password = target.querySelector('#password').value
    this.Auth.getUserDetails(username, password)
  }*/
}

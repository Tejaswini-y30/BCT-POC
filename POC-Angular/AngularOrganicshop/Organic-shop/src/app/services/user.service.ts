import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { catchError } from 'rxjs/operators';
import {environment} from 'src/environments/environment';
import {User} from 'src/app/model/user.module';
import {throwError,BehaviorSubject} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl="https://localhost:5001/api";
  User: User={
    fullName:"",
    email:"",
    password:""

  };
  
  constructor(private http:HttpClient) { }
  register(data:any){
    console.log(data)
    return this.http.post(`${this.apiUrl}/user/Register`,data).subscribe(data =>{
      console.log(data)
    })
  }
  login(user :any){
    //return this.http.post(environment.apiUrl+'/User/Login',{Email:user.email,Password:user.password})
    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};
    /*return this.http.post(environment.apiUrl+'/User/Login',{
      Email :email,
      Password :password}),{
        headers : new HttpHeaders({
          'Content-Type': 'application/json'
        })
    }*/
    /*this.http.get(this.apiUrl+'/User').subscribe(
      data => {
        console.log(data)
      })*/
    //return this.http.get(environment.apiUrl+'Product')
    
    return this.http.post(`${this.apiUrl}/User/Login`,user)
  }


  loginUser(token : any){
    localStorage.setItem("token",token)
    return true;
  }
  isloggedIn(){
    let token= localStorage.getItem("token");
    if (token==undefined || token=='' || token == null)
    {
      return false;
    }
    else{
      return true;
    }
  }
  logout(){
    localStorage.removeItem("name");
    localStorage.removeItem("role");
    localStorage.removeItem("email");
    localStorage.removeItem("token");
    localStorage.removeItem("Id")

    return true;
  }
  /*
  getAccessToken(){
    return localStorage.getItem('token');
  }
  isLoggedIn():boolean{
    var userPayload = this.getUserPayload();
    if (userPayload)
      return userPayload.exp > Date.now() / 1000;
    else
      return false;

  }
  logout(){
    this.deleteToken();
    localStorage.removeItem('name')
    setTimeout(()=>{window.location.reload()},1000);
  }
  }*/
}

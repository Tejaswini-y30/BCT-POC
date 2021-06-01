import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  apiUrl="https://localhost:5001/api";
  constructor(private http: HttpClient) { }
  create(details : any){
    console.log(details )
    return this.http.post(`${this.apiUrl}/OrderItem`,details).subscribe(data=>{
      console.log(data)
    })  
  }
  createDetails(details : any){
    console.log(details )
    return this.http.post(`${this.apiUrl}/Order`,details).subscribe(data=>{
      console.log(data)
    })  
  }
  getdetails(){
    return this.http.get(this.apiUrl+'/Order');
  }
  getAll(){
    return this.http.get(this.apiUrl+'/OrderItem');
  }
}

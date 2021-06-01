import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  apiUrl="https://localhost:5001/api";
  constructor(private http:HttpClient) { }
  create(details : any){
    console.log(details )
    return this.http.post(`${this.apiUrl}/Shipping`,details).subscribe(data=>{
      console.log(data)
    })  
  }
  getAll(){
    return this.http.get(this.apiUrl+'/Shipping');
  }

  get(Id:any){
    return this.http.get(this.apiUrl+'/Shipping/'+Id);
  }
  update(Id: any, details : any){
    return this.http.put(`${this.apiUrl}/Shipping/`+Id,details).subscribe(data=>{
      console.log(data)
    })
  }

  delete(Id: any){
    //console.log(productId)
    return this.http.delete(this.apiUrl+'/Shipping/'+Id).subscribe(() => console.log('Delete successful'));
  }

}

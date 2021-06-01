import { Injectable } from '@angular/core';
import {HttpClient,HttpErrorResponse,HttpHeaders} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  apiUrl="https://localhost:5001/api";
  constructor(private http:HttpClient) { }
  create(product : any){
    console.log(product)
    return this.http.post(`${this.apiUrl}/Product`,product).subscribe(data=>{
      console.log(data)
    })    /*return this.http.post(this.apiUrl+'/Product',product).subscribe(
      data =>{
        console.log(data)
      }
    )*/
    /*return this.http.post(this.apiUrl+'/Product',product),{
        headers : new HttpHeaders({
          'Content-Type': 'application/json'
        })
    
  }*/
  }

  getAll(){
    return this.http.get(this.apiUrl+'/Product');
  }

  get(productId:any){
    return this.http.get(this.apiUrl+'/Product/'+productId);
  }
  update(productId: any, product:any){
    return this.http.put(`${this.apiUrl}/Product/`+productId,product).subscribe(data=>{
      console.log(data)
    })
  }

  delete(productId:any){
    console.log(productId)
    return this.http.delete(this.apiUrl+'/Product/'+productId).subscribe(() => console.log('Delete successful'));
  }

}

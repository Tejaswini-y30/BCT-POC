import { query } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl="https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  getAll(){
    return this.http.get(this.apiUrl+'/category');
  }
}

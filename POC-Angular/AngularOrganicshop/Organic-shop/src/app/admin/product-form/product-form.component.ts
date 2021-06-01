import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import {Category} from 'src/app/model/category.module';
import {Product} from 'src/app/model/product.module';
import { ProductService } from 'src/app/services/product.service';
import {Router, NavigationEnd,ActivatedRoute} from '@angular/router';
import { take } from 'rxjs/operators';
@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories : Category[];
  product:Product={
    id:0,
    title :"",
    price :0,
    category :"",
    imageUrl :""
  };
  id;
  constructor( private router: Router, private route : ActivatedRoute , categoryservice : CategoryService, private productservice : ProductService) { 
    categoryservice.getAll().subscribe((data: any)=>{
      this.categories=data;
    });
    this.categories
   this.id =this.route.snapshot.paramMap.get('id');
    if (this.id) this.productservice.get(this.id).pipe(take(1)).subscribe(
      (p:any) => this.product =p);
  }
  reloadComponent() {  
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/'],{queryParamsHandling:'preserve'});
}
  save(event :any){
   // console.log(data)
    //console.log(this.product)
    if(this.id){
      this.productservice.update(this.id,this.product)
      this.reloadComponent(); 
    }
    else{
      this.productservice.create(this.product)
      this.reloadComponent();  
    }
    
    this.router.navigate(['/admin/products'])
  }
  delete(){
    if(!confirm("Are you sure you want to delete this product")) return;
    this.productservice.delete(this.id);
    this.router.navigate(['/admin/products'])
    
  }
  ngOnInit(): void {
  }

}

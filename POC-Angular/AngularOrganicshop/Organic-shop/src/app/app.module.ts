import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { HomeComponent } from './home/home.component';
import { CheckOutComponent } from './check-out/check-out.component';
//import { OrderSuccessComponent } from './order-success/order-success.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AdminProductsComponent } from './admin/admin-products/admin-products.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router'; 
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { FormsModule }   from '@angular/forms';
import { UserService } from './services/user.service';
import { AuthGaurdGuard } from './services/auth-gaurd.guard';
import { TokenInterceptorService } from './services/tokeninterceptor.service';
import { ProductFormComponent } from './admin/product-form/product-form.component'
import { CategoryService } from './services/category.service';
import { ProductService } from './services/product.service';
import { CustomFormsModule } from 'ng2-validation';
import { DataTableModule } from 'angular7-data-table';
import { DataTablesModule } from 'angular-datatables';
import { ProductFilterComponent } from './products/product-filter/product-filter.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { ShoppingCartService } from './services/shopping-cart.service';
import { ProductQuantityComponent } from './product-quantity/product-quantity.component';
import { OrderService } from './services/order.service';
import { ShoppingCartSummaryComponent } from './shopping-cart-summary/shopping-cart-summary.component';
import { RegisterComponent } from './login/register/register.component';
@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ShoppingCartComponent,
    HomeComponent,
    CheckOutComponent,
   // OrderSuccessComponent,
    LoginComponent,
    NavbarComponent,
    AdminProductsComponent,
    AdminOrdersComponent,
    MyOrdersComponent,
    ProductFormComponent,
    ProductFilterComponent,
    ProductCardComponent,
    ProductQuantityComponent,
    ShoppingCartSummaryComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CustomFormsModule,
    FormsModule ,
    NgbModule,
    DataTableModule,
    DataTablesModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: ProductsComponent  },
      { path: 'products', component: ProductsComponent },
      { path: 'shopping-cart', component: ShoppingCartComponent },
      { path: 'check-out', component: CheckOutComponent },
     // { path: 'order-success', component: OrderSuccessComponent },
      { path: 'my/orders', component: MyOrdersComponent},
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'admin/orders', component: AdminOrdersComponent },
      { path: 'admin/product/new', component: ProductFormComponent },
      { path: 'admin/product/:id', component: ProductFormComponent },
      { path: 'admin/products', component: AdminProductsComponent},
    ])
  ],
  providers: [ 
    UserService,
    CategoryService,
    ProductService,
    ShoppingCartService,
    OrderService,
    AuthGaurdGuard,
    {
      provide:HTTP_INTERCEPTORS,
      useClass:TokenInterceptorService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

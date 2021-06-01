import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent implements OnInit {
  orderlist:any;
  constructor(private orderservice: OrderService) { }
  
  ngOnInit(): void {
    this.orderservice.getdetails().subscribe(data => {
        this.orderlist=data
        console.log(this.orderlist)
      })
  }

}

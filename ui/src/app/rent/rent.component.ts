import { Component, OnInit } from '@angular/core';
import  {Bike} from "../interfaces/bike";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import  {CrudService} from "../services/crud.service";


@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.css']
})
export class RentComponent implements OnInit {

  flag:boolean=false
  // @ts-ignore
  bikes:Bike[];
  // @ts-ignore
  bike:Bike={}
  rentForm:FormGroup=this.RentForm();
  constructor(private fb:FormBuilder , private service:CrudService) { }

  ngOnInit(): void {
    this.GetBikes()
  }
  RentForm(){
    return this.fb.group({
      name:['', [Validators.required ]],
      type:['', Validators.required],
      price:['', [Validators.required ,Validators.min(0.001)]],
    })
  }
  SubmitRent(){
    this.GetDataFromForm();
    this.service.createRentBike(this.bike.name,this.bike.type,this.bike.price).subscribe(res=> {
      this.bikes.unshift(res)
    });
    this.rentForm.reset({name:'',type:'',price:''})


  }
   DeleteBike(id:number){
     this.service.deleteThisBike(id).subscribe(() => {
       this.bikes = this.bikes.filter(t => t.id !== id)
     });

  }
  ChangeRentBike(id:number,bike:Bike){
    this.service.changeRent(id,bike).subscribe();
  }
  GetDataFromForm(){
    this.bike.name=this.rentForm.get('name')?.value;this.bike.type=this.rentForm.get('type')?.value;this.bike.price=this.rentForm.get('price')?.value;
  }
  GetBikes(){
    this.flag=!this.flag
    this.service.getAllBikes().subscribe(data=>{this.bikes=data});
  }

}

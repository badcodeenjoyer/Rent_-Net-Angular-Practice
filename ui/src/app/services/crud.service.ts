import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Observable} from "rxjs";
import {Bike} from "../interfaces/bike";

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  // @ts-ignore
  bike:Bike;
  baseUrl:string="http://localhost:5101/api/BikeModels/"
  constructor(private  http:HttpClient) { }

  getAllBikes():Observable<Bike[]>{
   return   this.http.get<Bike[]>(this.baseUrl)
  }
  deleteThisBike(bikeId:number):Observable<Bike>{
    return   this.http.delete<Bike>(this.baseUrl+bikeId)
  }
  createRentBike(Name:string,Type:string ,Price:number){
      // @ts-ignore
    this.bike={name:Name,type:Type,rented:false,price:Price};
    return this.http.post<Bike>(this.baseUrl,this.bike);
  }
  changeRent(bikeId:number,bike:Bike):Observable<Bike>{
    bike.rented=!bike.rented;
    return this.http.put<Bike>(this.baseUrl+bikeId,bike);
  }

  genId<T extends Bike >(myTable: T[]): number {
    return myTable.length > 0 ? Math.max(...myTable.map(t => t.id)) + 1 : 11;
  }
}

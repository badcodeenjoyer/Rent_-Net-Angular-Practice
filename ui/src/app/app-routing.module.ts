import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RentComponent} from "./rent/rent.component";
import {ErrorComponent} from "./error/error.component";
import {HomeComponent} from "./home/home.component";

const routes: Routes = [
  {path:'',component:HomeComponent },
  {path:'rent',component:RentComponent},
  {path: 'error', component: ErrorComponent},
  {path: '**', redirectTo: 'error'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

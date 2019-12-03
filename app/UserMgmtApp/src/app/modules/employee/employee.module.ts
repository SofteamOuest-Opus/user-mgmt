import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employee.component';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component: EmployeeComponent, pathMatch: 'full' },
  { path: '**', component: EmployeeComponent } // TODO NotFoundComponent
];

@NgModule({
  declarations: [EmployeeComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ]
})

export class EmployeeModule { }

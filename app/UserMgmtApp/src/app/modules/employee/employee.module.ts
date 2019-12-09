import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employee.component';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';


const routes: Routes = [
  { path: '', component: EmployeeComponent, pathMatch: 'full' },
  { path: '**', component: EmployeeComponent } // TODO NotFoundComponent
];

@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeEditComponent,

    
  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,

  ]
})

export class EmployeeModule { }

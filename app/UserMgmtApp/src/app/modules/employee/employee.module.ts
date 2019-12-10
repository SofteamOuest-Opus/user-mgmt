import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employee.component';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { SharedModule } from '@shared/shared.module';



const routes: Routes = [
  { path: '', component: EmployeeComponent },
  { path: 'edit', component: EmployeeEditComponent },
  // { path: '**', component: EmployeeComponent } // TODO NotFoundComponent


];

@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeEditComponent,

  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule 

  ]
})

export class EmployeeModule { }

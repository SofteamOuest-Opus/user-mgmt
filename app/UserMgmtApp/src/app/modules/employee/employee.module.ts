import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from '@employee/employee.component';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeEditComponent } from '@employee/employee-edit/employee-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { SharedModule } from '@shared/shared.module';
import { EmployeeListComponent } from '@employee/employee-list/employee-list.component';


const routes: Routes = [
  { path: '', component: EmployeeComponent },
  { path: 'edit', component: EmployeeEditComponent },
  { path: 'list', component: EmployeeListComponent },
  { path: '**', component: EmployeeComponent } // TODO NotFoundComponent

];

@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeEditComponent,
    EmployeeListComponent,

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

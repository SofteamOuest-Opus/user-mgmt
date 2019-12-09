import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from '@models/employee.model';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  public infosMessage: string = 'Pour mettre à jour votre profil, veuillez contacter votre HR Manager.';

  constructor(
    private router: Router,

  ) { }

  public ngOnInit(): void {

  }

  public save(emp: Employee): void {
    // TODO traitements
    // console.log('click save !!!');

    // Redirection
    this.router.navigate[('/employee')];
  }
}

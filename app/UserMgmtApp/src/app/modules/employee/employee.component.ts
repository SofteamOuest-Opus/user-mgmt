import { Component, OnInit } from '@angular/core';
import { UserContextService } from 'src/app/services/user-context.service';
import { Employee } from '@models/index.ts';



@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  public employeeDisplay: Employee;

  constructor(
    private userContextService: UserContextService,

  ) { }

  public ngOnInit(): void {
    this.employeeDisplay = this.userContextService.getCurrentUserInfos();
    console.log('employeeDisplay', this.employeeDisplay);
  }
}

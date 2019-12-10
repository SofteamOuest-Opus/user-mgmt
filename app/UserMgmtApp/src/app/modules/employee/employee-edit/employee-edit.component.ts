import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as data from '@assets/json/data.json';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserContextService } from '@services/user-context.service';
import { EmployeeShort } from '@models/employee-short.model';


@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  public infosMessage: string = (data as any).employee_edit_infos;
  public employeeEditForm: FormGroup;
  public showImgEditForm: boolean = false;

  private employeeEdit: EmployeeShort;

  constructor(
    private router: Router,
    private userContextService: UserContextService,

  ) { }

  public ngOnInit(): void {
    this.employeeEditForm = this.createFormGroup();
    this.employeeEdit = this.userContextService.getCurrentUserShortInfos();
    this.initialyzeFormGroup();
  }

  public onSubmit(event: Event): void {
    // TODO traitements
    console.log(this.employeeEditForm.value);

    // Redirection
    this.router.navigate[('/employee')];
  }

  public editPhoto(): void {
    this.showImgEditForm = true;

  }

  private createFormGroup(): FormGroup {
    return new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      email: new FormControl('', Validators.compose([Validators.required, Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')]))
    });
  }

  private initialyzeFormGroup(): void {
    this.employeeEditForm.setValue(this.employeeEdit);
  }
}

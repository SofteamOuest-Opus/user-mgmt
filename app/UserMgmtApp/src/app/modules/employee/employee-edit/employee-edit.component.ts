import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as data from '@assets/json/data.json';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserContextService } from '@services/user-context.service';
import { EmployeeShort } from '@models/index.ts';


@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  public infosMessage: string = (data as any).employee_edit_infos;
  public employeeEditForm: FormGroup;
  public showImgEditForm: boolean = false;
  public employeeEdit: EmployeeShort;

  public photoName: string = `profile1.jpg`;
  public photoUrl: string = `assets/img/${this.photoName}`;

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
    // TODO traitements => API
    console.log(this.employeeEditForm.value);

    // Redirection
    this.router.navigate[('/employee')];
  }

  public editPhoto(): void {
    this.showImgEditForm = true;

  }

  public setUpFormVisibility(visibility: boolean): void {
    this.showImgEditForm = visibility;
  }

  private createFormGroup(): FormGroup {
    let regExMailValidator = new RegExp('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$');
    return new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
      email: new FormControl('', Validators.compose([Validators.required, Validators.pattern(regExMailValidator)]))
    });
  }

  private initialyzeFormGroup(): void {
    this.employeeEditForm.setValue(this.employeeEdit);
  }
}

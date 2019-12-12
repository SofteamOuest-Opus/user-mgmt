import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms'
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,

  ) {
    this.loginForm = this.createFormGroup()
  }

  public createFormGroup(): FormGroup {
    return new FormGroup({
      userName: new FormControl(),
      password: new FormControl()
    });
  }

  public ngOnInit(): void {

  }

  public onSubmit(event: Event): void {
    this.authenticationService.setConnected();
    this.router.navigate(['/employee']);
  }

}

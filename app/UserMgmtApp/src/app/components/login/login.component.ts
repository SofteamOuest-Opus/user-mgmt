import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms'
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';
import { HostListener } from "@angular/core";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public loginFormHeightPosition: string = '0';
  private screenHeight: number = 0;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,

  ) {
    this.loginForm = this.createFormGroup();
  }

  @HostListener('window:resize', ['$event'])
  getScreenSize(event?) {
    this.screenHeight = window.innerHeight;
    this.getLoginFormPosition(this.screenHeight);
  }

  public createFormGroup(): FormGroup {
    return new FormGroup({
      userName: new FormControl(),
      password: new FormControl()
    });
  }

  public ngOnInit(): void {
    this.getScreenSize();
  }

  public onSubmit(event: Event): void {
    this.authenticationService.setConnected();
    this.router.navigate(['/employee']);
  }

  private getLoginFormPosition(heightScreen: number) {

    let loginFormElement: HTMLElement = document.getElementById("loginForm");
    let loginFormElementHeight: number = loginFormElement.offsetHeight;

    let headerElement: HTMLElement = document.getElementById("header");
    let headerElementHeight: number = headerElement.offsetHeight;

    let footerElement: HTMLElement = document.getElementById("footer");
    let footerElementHeight: number = footerElement.offsetHeight;

    let loginFormPositionCalculated: number = (((this.screenHeight - loginFormElementHeight) - headerElementHeight) - footerElementHeight);
    loginFormPositionCalculated = loginFormPositionCalculated / 2;

    if (loginFormPositionCalculated > 0)
      this.loginFormHeightPosition = `${loginFormPositionCalculated}px`;

  }
}

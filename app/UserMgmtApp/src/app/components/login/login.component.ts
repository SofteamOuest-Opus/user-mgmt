import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';


const containerHeightKey: string = 'containerHeightKey';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  private contentHeight: number = 0;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,

  ) {
    this.loginForm = this.createFormGroup();
    this.getContentHeight();
  }

  public createFormGroup(): FormGroup {
    return new FormGroup({
      userName: new FormControl(),
      password: new FormControl()
    });
  }

  public ngOnInit(): void {
    this.setLoginFormPosition();
  }


  public onSubmit(event: Event): void {
    this.authenticationService.setConnected();
    this.router.navigate(['/employee']);
  }

  private setLoginFormPosition(): void {

    let loginFormElement: HTMLElement = document.getElementById("loginForm");
    let loginFormElementHeight: number = loginFormElement.offsetHeight;

    // --- login form vertical position: ( Content height - Login Form Height ) / 2
    let loginFormPositionCalculated: number = (this.contentHeight - loginFormElementHeight) / 2;

    if (loginFormPositionCalculated > 0) {
      let paddingTop: string = `${loginFormPositionCalculated}px`;
      (document.querySelector('#loginForm') as HTMLElement).style.paddingTop = paddingTop;
    }
  }

  private getContentHeight(): void {
    if (sessionStorage.getItem(containerHeightKey))
      this.contentHeight = +sessionStorage.getItem(containerHeightKey);
  }

}

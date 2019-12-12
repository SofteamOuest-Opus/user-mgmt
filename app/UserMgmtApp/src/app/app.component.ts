import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,

  ) { }

  public ngOnInit(): void {
    let isLogin: boolean = this.authenticationService.getConnected();
    this.redirectLogin(isLogin);
  }

  private redirectLogin(isLogin: boolean): void {
    if (!isLogin)
      this.router.navigate(['/']);
  }

}

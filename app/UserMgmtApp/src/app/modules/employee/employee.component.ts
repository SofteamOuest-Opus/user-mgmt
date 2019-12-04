import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,

  ) { }

  ngOnInit() {
  }

  public logout(): void {
    this.authenticationService.setIsConnected(false);
    this.router.navigate(['/']);
  }

}

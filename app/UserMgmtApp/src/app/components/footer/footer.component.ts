import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  constructor(
    public authenticationService: AuthenticationService,
    private router: Router,
  ) { }

  ngOnInit() {

  }

  public logout(): void {
    this.authenticationService.setIsConnected(false);
    this.router.navigate(['/']);
  }

}

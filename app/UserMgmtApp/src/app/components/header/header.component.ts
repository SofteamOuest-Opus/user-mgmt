import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public headerTitlePart1: string = 'Softeam';
  public headerTitlePart2: string = 'Digital';

  constructor(
    public authenticationService: AuthenticationService,
    private router: Router,
  ) { }

  public ngOnInit(): void {
 
  }

  public hideNavbarCollapse() {
    let navbarCollapse = document.querySelector('.navbar-collapse');
    navbarCollapse.classList.remove('show');
  }

  public logout(): void {
    this.authenticationService.logOut();
    this.router.navigate(['/']);
  }

}

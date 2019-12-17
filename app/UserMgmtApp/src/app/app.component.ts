import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@services/authentication.service';
import { Router } from '@angular/router';
import { HostListener } from "@angular/core";

const containerHeightKey: string = 'containerHeightKey';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  private containerMinHeightCalculated: number;

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,

  ) { }

  public ngOnInit(): void {
    let isLogin: boolean = this.authenticationService.getConnected();
    this.redirectLogin(isLogin);
  }

  public ngAfterViewInit(): void {
    this.getContainerHeight();
    // Add style
    let minHeight: string = `${this.containerMinHeightCalculated}px`;
    (document.querySelector('#sd-container') as HTMLElement).style.minHeight = minHeight;
  }

  @HostListener('window:resize', ['$event'])

  private getContainerHeight(event?: any): void {

    // getHeaderHeight
    let headerElement: HTMLElement = document.getElementById("header");
    let headerElementHeight: number = headerElement.offsetHeight;

    // getFooterHeight
    let footerElement: HTMLElement = document.getElementById("footer");
    let footerElementHeight: number = footerElement.offsetHeight;

    let screenHeight: number = window.innerHeight;
    let screenWidth: number = window.innerWidth;

    this.containerMinHeightCalculated = screenHeight - (headerElementHeight + footerElementHeight);

    // Save in SessionStorage
    sessionStorage.setItem(containerHeightKey, this.containerMinHeightCalculated.toString());

    // TEMP
    this.showResponsiveBreakpoints(screenWidth);
  }

  private redirectLogin(isLogin: boolean): void {
    if (!isLogin)
      this.router.navigate(['/']);
  }

  // Help for adjust sreen size
  private showResponsiveBreakpoints(screenWidth: number): void {

    if (0 < screenWidth && screenWidth < 576) {
      console.log(screenWidth, ' --> xs');
    }
    if (576 < screenWidth && screenWidth < 768) {
      console.log(screenWidth, ' --> sm');
    }
    if (768 < screenWidth && screenWidth < 992) {
      console.log(screenWidth, ' --> md');
    }
    if (992 < screenWidth && screenWidth < 1200) {
      console.log(screenWidth, ' --> lg');
    }
    if (screenWidth > 1200) {
      console.log(screenWidth, ' --> xl');
    }
  }

}

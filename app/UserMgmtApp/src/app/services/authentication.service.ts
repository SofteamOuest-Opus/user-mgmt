import { Injectable } from '@angular/core';


const loginKey: string = 'UserMgmtLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private _isConnected: boolean = false;


  constructor() {
    if (this.getSessionStorageItem())
      this._isConnected = true;
  }

  public isConnected(): boolean {

    return this._isConnected;
  }

  public setIsConnected() {
    this._isConnected = true;
    this.setSessionStorageKey();
  }

  public logOut(): void {
    this._isConnected = false;
    this.removeSessionStorageKey();
  }

  private setSessionStorageKey(): void {
    sessionStorage.setItem(loginKey, 'connected');
  }

  private removeSessionStorageKey(): void {
    sessionStorage.clear();
  }

  private getSessionStorageItem(): boolean {
    return sessionStorage.getItem(loginKey) === 'connected';
  }

}

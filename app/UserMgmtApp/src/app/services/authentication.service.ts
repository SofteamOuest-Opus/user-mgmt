import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private _isConnected: boolean = false;

  isConnected() {
    return this._isConnected;
  }

  setIsConnected(val: boolean) {
    this._isConnected = val;
    console.log('_isConnected : ', this._isConnected);
  }

  constructor() { }


}

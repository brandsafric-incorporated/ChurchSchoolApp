import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private authenticationService: AuthenticationService) { }

  canActivate(): boolean {
    if (this.authenticationService.isLoggedIn())
      return true;

    this.authenticationService.startAuthentication();

    return false;
  }
}

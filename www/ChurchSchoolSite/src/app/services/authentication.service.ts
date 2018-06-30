import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User } from 'oidc-client';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private userManager = new UserManager(getClientSettings());
  private user: User = null;


  constructor() {
    this.userManager.getUser().then(_user => {
      this.user = _user;
    });
  }

  isLoggedIn(): boolean {
    return this.user != null && !this.user.expired;
  }

  getClaims(): any {
    return this.user.profile;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }


  startAuthentication(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  completeAuthentication(): Promise<void> {
    return this.userManager.signinRedirectCallback().then(_user => {
      this.user = _user;
    });
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'http://localhost:5000/',
    client_id: 'seminario-web-app',
    redirect_uri: 'http://localhost:4200/auth-callback',
    post_logout_redirect_uri: 'http://localhost:4200/',
    response_type: "id_token token",
    scope: "openid profile ChurchSchoolApi",
    filterProtocolClaims: true,
    loadUserInfo: true
  }
}

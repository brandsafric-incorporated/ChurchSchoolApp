import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProtectedComponent } from './protected/protected.component';
import { Route } from '@angular/compiler/src/core';
import { AuthGuardService } from './services/auth-guard.service';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { StudentComponent } from './student/student.component';


const routes: Routes = [
  {
    path: '',
    children: []
  },
  {
    path: 'protected',
    component: ProtectedComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'student',
    component: StudentComponent,
    canActivate: [AuthGuardService]
  }
  ,
  {
    path: 'auth-callback',
    component: AuthCallbackComponent
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

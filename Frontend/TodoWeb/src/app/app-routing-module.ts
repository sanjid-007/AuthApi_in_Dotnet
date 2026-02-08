import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './components/signup/signup';
import { Signin } from './components/signin/signin';
import { AuthGuard } from './guards/auth-guard';
import { Tasks } from './components/tasks/tasks';

const routes: Routes = [
  { path: '', redirectTo: '/signup', pathMatch: 'full' },
  { path: 'signin', component: Signin },
  { path: 'signup', component: SignupComponent },
  {path: 'tasks', component: Tasks, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '/signup' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

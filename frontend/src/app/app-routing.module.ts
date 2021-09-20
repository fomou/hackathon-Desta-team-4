import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LogginComponent } from './loggin/loggin.component';
import { SignupComponent } from './signup/signup.component';
import { ProfileComponent } from './profile/profile.component';
import { DirectoryComponent } from './directory/directory.component';
import { ForumComponent } from './forum/forum.component';


const routes: Routes = [
  {
    path: 'home', component: HomeComponent
  },
{
  path: '', redirectTo: 'home', pathMatch: 'full'
  },
  {
    path: 'login', component: LogginComponent
  },
  {
    path:'signup', component:SignupComponent, pathMatch:'full',
  },
  {
    path:'profile', component:ProfileComponent
  },
  {
    path:'directory', component:DirectoryComponent, pathMatch:'full'
  },
  {
    path:'forum', component:ForumComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

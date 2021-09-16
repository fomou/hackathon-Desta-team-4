import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LogginComponent } from './loggin/loggin.component';


const routes: Routes = [
  {
    path: 'home', component: HomeComponent
  },
{
  path:'',redirectTo:'home',pathMatch:'full'
  },
  {
    path:'login', component:LogginComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFireModule } from '@angular/fire';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { HttpClientModule } from '@angular/common/http';
//import { AgmCoreModule } from '@agm/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { environment } from '../environments/environment';
import { HomeComponent } from './home/home.component';
import { LogginComponent } from './loggin/loggin.component';
import { FooterComponent } from './footer/footer.component';
import { SignupComponent } from './signup/signup.component';
import { ProfileComponent } from './profile/profile.component';
import { DirectoryComponent } from './directory/directory.component';
import { ChatComponent } from './chat/chat.component';
import { ForumComponent } from './forum/forum.component';
import { EventsComponent } from './events/events.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LogginComponent,
    FooterComponent,
    SignupComponent,
    ProfileComponent,
    DirectoryComponent,
    ChatComponent,
    ForumComponent,
    EventsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    //AgmCoreModule.forRoot({
   //   apiKey: ''
   // })
    AngularFireModule.initializeApp(environment.firebase),

    AngularFireDatabaseModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

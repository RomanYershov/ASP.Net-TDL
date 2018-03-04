import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import {FormsModule} from '@angular/forms';
import { RouterModule , Routes} from '@angular/router'


import { AppComponent } from './app.component';
import { TodoComponent } from './todo/todo.component';
import { TodoService } from './shared/todo.service';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginService } from './shared/login.service';
import { SearchPipe } from './shared/search.pipe';


const appRoutes:Routes = [
  {path: 'login',component: LoginComponent},
  {path: 'todo', component: TodoComponent},
  {path: 'registration', component:RegistrationComponent}
]


@NgModule({
  declarations: [
    AppComponent,
    TodoComponent,
    LoginComponent,
    RegistrationComponent,
    SearchPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [TodoService, LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }

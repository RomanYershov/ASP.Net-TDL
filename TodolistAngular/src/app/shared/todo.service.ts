import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from "@angular/http";
import { Todo } from './Todo';
import { Router } from '@angular/router';


@Injectable()
export class TodoService {
  todo: Todo = new Todo();
  url: string = "http://localhost:55070/api/todolist/";
  

  constructor(private http: Http, private router: Router) { }

  setHeaders(token: string){
    return  new RequestOptions({
      headers:
        new Headers({ "Authorization": "bearer" + " " + token })
    });
  }


  GetTodos() {
    if (localStorage.length == 0) this.router.navigate(['todo'])
    const options = this.setHeaders(localStorage.getItem("accessToken"));
    return this.http.get(this.url, options)
      .toPromise()
      .then(res => res.json());
  }



  AddTodo(todo: Todo) {
    if (todo.id != 0) {
      todo.id = 0;
      todo.isDone = false;
    }
    const options = this.setHeaders(localStorage.getItem("accessToken"));
    return this.http.post(this.url, todo, options).map(res => res.json());
  }

 

  EditTodo(id: number, todo: Todo) {
    const options = this.setHeaders(localStorage.getItem("accessToken"));
    return this.http.put("http://localhost:55070/api/edit/" + id, todo, options);
  }


  DeleteTodo(id: number) {
    const options = this.setHeaders(localStorage.getItem("accessToken"));
    return this.http.get("http://localhost:55070/api/delete/" + id, options);
  }



  GetTodoById(id: number) {
    const options = this.setHeaders(localStorage.getItem("accessToken"));
    return this.http.get(this.url + id, options)
      .toPromise()
      .then(res => res.json());
  }


  Toggle(id: number) {
    const options = this.setHeaders(localStorage.getItem("accessToken"));
    return this.http.get("http://localhost:55070/api/toggle/" + id, options)
      .toPromise();
  }

}

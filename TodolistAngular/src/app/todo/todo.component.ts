import { Component, OnInit } from '@angular/core';
import { TodoService } from '../shared/todo.service';
import { Todo } from '../shared/Todo';
import { Http, RequestOptions, Headers } from '@angular/http';
import { HttpHeaders } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';




@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})


export class TodoComponent implements OnInit {
  todos: Todo[];
  todo: Todo = new Todo();
  isEdit: boolean = false;
  id: number;
  searchStr:string = '';
  constructor(private todoService: TodoService, private http: Http) { }

  ngOnInit() {
    this.LoadTodos();
  }

  LoadTodos() {
    this.todoService.GetTodos()
      .then((data: any) => {
        this.todos = data;
      });
  }

  deleteTodo(id: number) {
    this.todoService.DeleteTodo(id)
      .subscribe(res => {
        this.LoadTodos();
      });
  }

  async addTodo() {
    await this.todoService.AddTodo(this.todo)
      .subscribe(res => this.LoadTodos())
  }

  getTodoById(id: number) {
    this.todos.forEach(todo => { if (todo.id == id) this.todo = todo });
    this.id = id;
    this.isEdit = true;
  }



  editTodo() {
    this.isEdit = false;
    this.todoService.EditTodo(this.id, this.todo)
      .subscribe(res => {
        this.LoadTodos();
      });
  }


  onchange(id: number) {
    this.todoService.Toggle(id)
      .then(res => {
        this.LoadTodos();
      });
  }


}

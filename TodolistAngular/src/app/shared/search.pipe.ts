import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(todos, value):any{
    return todos.filter(todo => {
         return todo.name.includes(value);
    });
  }

}

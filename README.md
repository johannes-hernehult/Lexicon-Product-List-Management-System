# To be done... 


## Test UML Diagram

classDiagram
  class TodoList {
    -items: List~TodoItem~
    +Add(item) void
    +Remove(item) void
  }
  class TodoItem {
    -title: string
    -isDone: bool
    +MarkDone() void
  }
  TodoList "1" *-- "*" TodoItem

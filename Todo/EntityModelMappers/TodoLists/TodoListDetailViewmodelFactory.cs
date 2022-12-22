using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailViewmodelFactory
    {
        public static TodoListDetailViewmodel Create(TodoList todoList, string userName)
        {
            var items = todoList.Items
                .Select(item => TodoItemSummaryViewmodelFactory.Create(item, userName))
                .OrderBy(item => item.IsDone).ThenBy(item => item.Importance)
                .ToList();
            return new TodoListDetailViewmodel(todoList.TodoListId, todoList.Title, items);
        }
    }
}
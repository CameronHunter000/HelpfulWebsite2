using System.Collections.Generic;
using HelpfulWebsite_2.Application.TodoLists.Queries.ExportTodos;

namespace HelpfulWebsite_2.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}

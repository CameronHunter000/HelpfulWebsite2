using HelpfulWebsite_2.Application.Common.Mappings;
using HelpfulWebsite_2.Domain.Entities;

namespace HelpfulWebsite_2.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}

using System.Collections.Generic;
using HelpfulWebsite_2.Domain.Common;
using HelpfulWebsite_2.Domain.ValueObjects;

namespace HelpfulWebsite_2.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}

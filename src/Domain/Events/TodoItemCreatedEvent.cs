using HelpfulWebsite_2.Domain.Common;
using HelpfulWebsite_2.Domain.Entities;

namespace HelpfulWebsite_2.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}

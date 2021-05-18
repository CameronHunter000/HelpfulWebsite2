using System.Threading.Tasks;
using FluentAssertions;
using HelpfulWebsite_2.Application.Common.Exceptions;
using HelpfulWebsite_2.Application.TodoItems.Commands.CreateTodoItem;
using HelpfulWebsite_2.Application.TodoItems.Commands.DeleteTodoItem;
using HelpfulWebsite_2.Application.TodoLists.Commands.CreateTodoList;
using HelpfulWebsite_2.Domain.Entities;
using NUnit.Framework;

namespace HelpfulWebsite_2.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}

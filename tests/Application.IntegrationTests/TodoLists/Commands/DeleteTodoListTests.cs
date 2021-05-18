using System.Threading.Tasks;
using FluentAssertions;
using HelpfulWebsite_2.Application.Common.Exceptions;
using HelpfulWebsite_2.Application.TodoLists.Commands.CreateTodoList;
using HelpfulWebsite_2.Application.TodoLists.Commands.DeleteTodoList;
using HelpfulWebsite_2.Domain.Entities;
using NUnit.Framework;

namespace HelpfulWebsite_2.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteTodoListCommand 
            { 
                Id = listId 
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}

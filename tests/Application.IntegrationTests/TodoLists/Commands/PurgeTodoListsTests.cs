﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using HelpfulWebsite_2.Application.Common.Exceptions;
using HelpfulWebsite_2.Application.Common.Security;
using HelpfulWebsite_2.Application.TodoLists.Commands.CreateTodoList;
using HelpfulWebsite_2.Application.TodoLists.Commands.PurgeTodoLists;
using HelpfulWebsite_2.Domain.Entities;
using NUnit.Framework;

namespace HelpfulWebsite_2.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class PurgeTodoListsTests : TestBase
    {
        [Test]
        public void ShouldDenyAnonymousUser()
        {
            var command = new PurgeTodoListsCommand();

            command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<UnauthorizedAccessException>();
        }

        [Test]
        public async Task ShouldDenyNonAdministrator()
        {
            await RunAsDefaultUserAsync();

            var command = new PurgeTodoListsCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ForbiddenAccessException>();
        }

        [Test]
        public async Task ShouldAllowAdministrator()
        {
            await RunAsAdministratorAsync();

            var command = new PurgeTodoListsCommand();

            FluentActions.Invoking(() => SendAsync(command))
                .Should().NotThrow<ForbiddenAccessException>();
        }

        [Test]
        public async Task ShouldDeleteAllLists()
        {
            await RunAsAdministratorAsync();

            await SendAsync(new CreateTodoListCommand
            {
                Title = "New List #1"
            });

            await SendAsync(new CreateTodoListCommand
            {
                Title = "New List #2"
            });

            await SendAsync(new CreateTodoListCommand
            {
                Title = "New List #3"
            });

            await SendAsync(new PurgeTodoListsCommand());

            var count = await CountAsync<TodoList>();

            count.Should().Be(0);
        }
    }
}

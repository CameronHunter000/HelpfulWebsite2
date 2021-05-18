using System.Globalization;
using CsvHelper.Configuration;
using HelpfulWebsite_2.Application.TodoLists.Queries.ExportTodos;

namespace HelpfulWebsite_2.Infrastructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}

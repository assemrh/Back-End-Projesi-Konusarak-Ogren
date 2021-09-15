using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Seeds
{
    public class AppContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Users.Any())
                {
                    var usersData = File.ReadAllText("./Seeds/Data/Users.json");
                    var users = JsonSerializer.Deserialize<List<User>>(usersData);
                    foreach (var item in users)
                    {
                        context.Users.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Exams.Any())
                {
                    var ExamsData = File.ReadAllText("./Seeds/Data/Exams.json");
                    var Exams = JsonSerializer.Deserialize<List<Exam>>(ExamsData);
                    foreach (var item in Exams)
                    {
                        context.Exams.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }

        }
    }
}

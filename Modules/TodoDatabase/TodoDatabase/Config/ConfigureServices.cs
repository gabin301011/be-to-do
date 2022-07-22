using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoDatabase.Database;
using TodoDatabase.Repositories.Assignments;
using TodoDatabase.Repositories.HistoryAssignments;
using TodoDatabase.Services.Assignments;
using TodoDatabase.Services.HistoryAssignments;

namespace TodoDatabase.Config {
    public static class ConfigureServices {
        public static void AddTodo(this IServiceCollection services, string connectionString) {
            services.InitDbContext(connectionString);
            services.InitRepositories();
            services.InitServices();
            services.InitBff();
        }
        private static void InitDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TodoDbContext>(options => {
#if RELEASE
                options.UseNpgsql(connectionString);
#else
                options.UseNpgsql(connectionString,
                    configuration => {
                        options.EnableSensitiveDataLogging();
                    });
#endif
            }, ServiceLifetime.Transient);
        }

        private static void InitRepositories(this IServiceCollection services) {
            services.AddTransient<IAssignmentRepo, AssignmentRepo>();
            services.AddTransient<IHistoryAssignmentRepo, HistoryAssignmentRepo>();
        }

        private static void InitServices(this IServiceCollection services) {
            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddTransient<IHistoryAssignmentService, HistoryAssignmentService>();
        }

        private static void InitBff(this IServiceCollection services) { }
    }
}

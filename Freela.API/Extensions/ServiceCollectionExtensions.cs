using Freela.Core.Repositories;
using Freela.Core.Services;
using Freela.Infra.Auth;
using Freela.Infra.MessageBus;
using Freela.Infra.Payments;
using Freela.Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Freela.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();

            return services;
        }
    }
}

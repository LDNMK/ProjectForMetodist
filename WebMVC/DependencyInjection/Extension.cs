using AutoMapper;
using FaitLogic.Logic;
using FaitLogic.Logic.ILogic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Extension
    {
        public static void AddCoreLogic(this IServiceCollection services)
        {
            services.AddScoped<IStudentCardLogic, StudentCardLogic>();
            services.AddScoped<IGroupLogic, GroupLogic>();
            services.AddScoped<IYearPlanLogic, YearPlanLogic>();
            services.AddScoped<ITransferLogic, TransferLogic>();
            services.AddScoped<IProgressLogic, ProgressLogic>();
            services.AddScoped<IReportLogic, ReportLogic>();
        }

        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

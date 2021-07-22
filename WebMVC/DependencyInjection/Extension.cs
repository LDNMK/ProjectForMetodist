using AutoMapper;
using Fait.DAL.Repository;
using Fait.DAL.Repository.IRepository;
using FaitLogic.Logic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Extension
    {
        //public static void AddRepositories(this IServiceCollection services)
        //{
        //    services.AddScoped<IStudentRepository, StudentRepository>();
        //    services.AddScoped<IGroupRepository, GroupRepository>();
        //    services.AddScoped<IYearPlanRepository, YearPlanRepository>();
        //    services.AddScoped<IActualGroupRepository, ActualGroupRepository>();
        //    services.AddScoped<ISubjectRepository, SubjectRepository>();
        //}

        public static void AddCoreLogic(this IServiceCollection services)
        {
            services.AddScoped<StudentCardLogic>();
            services.AddScoped<GroupLogic>();
            services.AddScoped<YearPlanLogic>();
            services.AddScoped<TransferLogic>();
            services.AddScoped<ProgressLogic>();
            services.AddScoped<ReportLogic>();
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

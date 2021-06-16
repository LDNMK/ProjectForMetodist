﻿using AutoMapper;
using FaitLogic.Logic;
using FaitLogic.Repository;
using FaitLogic.Repository.IRepository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Extension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentCardRepository, StudentCardRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IYearPlanRepository, YearPlanRepository>();
            services.AddScoped<IActualGroupRepository, ActualGroupRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
        }

        public static void AddCoreLogic(this IServiceCollection services)
        {
            services.AddScoped<StudentCardLogic>();
            services.AddScoped<GroupLogic>();
            services.AddScoped<YearPlanLogic>();
            services.AddScoped<TransferLogic>();
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
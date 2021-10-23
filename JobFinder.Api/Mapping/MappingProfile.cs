using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobFinder.Api.Dtos;
using JobFinder.Core.Models;

namespace JobFinder.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Job, JobDto>();
            CreateMap<Job, JobWithOrgDto>();
            CreateMap<Organization, OrganizationDto>();
            CreateMap<Organization, OrganizationWithJobsDto>();
            CreateMap<EmploymentType, EmploymentTypeDto>();
            CreateMap<Technology, TechnologyDto>();
            CreateMap<ExperienceLevel, ExperienceLevelDto>();
            CreateMap<ReqResBon, ReqResBonDto>();
            CreateMap<Job, JobWithAllDto>();

            // Resource to Domain


        }
    }
}
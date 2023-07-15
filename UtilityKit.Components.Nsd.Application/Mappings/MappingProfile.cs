using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Chart.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<WidgetDto, Widget>().ReverseMap();
            CreateMap<ChartDTO, Chart>().ReverseMap();


            //CreateMap<ConfigurationDefinitionDto, ConfigurationDefinitionItem>().ReverseMap();
            // CreateMap<DataSourceDto, DataSource>().ReverseMap();
            // CreateMap<TableDto, Table>().ReverseMap();
            // CreateMap<FeatureClassDto, FeatureClass>().ReverseMap();
            // CreateMap<FieldDto, Field>().ReverseMap();
            // CreateMap<MapRecordDto, MapRecord>().ReverseMap();
            // CreateMap<GetMapRecordDto, MapRecord>().ReverseMap();
            // CreateMap<ATLProjectDto, ATLProject>().ReverseMap();
            // CreateMap<FieldMapDto, FieldMap>().ReverseMap();
            // CreateMap<ReplacementFilterDto, ReplacementFilter>().ReverseMap();
            // CreateMap<ZConditionDto, ZCondition>().ReverseMap();
            // CreateMap<GetFieldMapForEditDto, FieldMap>().ReverseMap();
            // CreateMap<ContainmentSettingsDto, ContainmentSettings>().ReverseMap();
            // CreateMap<ContainmentTargetDto, ContainmentTarget>().ReverseMap();
            // CreateMap<StructureSettingsDto, StructureSettings>().ReverseMap();
            // CreateMap<StructureTargetDto, StructureTarget>().ReverseMap();
            // CreateMap<AssemblySettingsDto, AssemblySettings>().ReverseMap();
            // CreateMap<AssemblyTargetDto, AssemblyTarget>().ReverseMap();
            // CreateMap<DestinationDto, Destination>().ReverseMap();
            // CreateMap<SourceDataDto, SourceData>().ReverseMap();
            // CreateMap<TerminalSettingsDto, TerminalSettings>().ReverseMap();
            // CreateMap<ZValueSettingsDto, ZValueSettings>().ReverseMap();
            // CreateMap<CompletenessCriteriaDto, CompletenessCriteria>().ReverseMap();
            // CreateMap<ProjectReportDto, ProjectReport>().ReverseMap();

            // CreateMap<GetConfigureThreeDForEditDto, MapRecord>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MapRecordId))
            //     .ReverseMap();

            // CreateMap<GetConfigureTerminalForEditDto, MapRecord>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MapRecordId))
            //    .ReverseMap();

            // CreateMap<GetContainmentSettingsForEditDto, MapRecord>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MapRecordId))
            //     .ReverseMap();

            // CreateMap<GetStructureSettingsForEditDto, MapRecord>()
            //  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MapRecordId))
            //  .ReverseMap();

            // CreateMap<GetAssemblySettingsForEditDto, MapRecord>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MapRecordId))
            //.ReverseMap();
        }
    }
}

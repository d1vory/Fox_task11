using AutoMapper;
using Shared2.DTO.FinancialOperation;
using Shared2.DTO.OperationType;

namespace Task11.DTO;

public class DomainToResponseMappingProfile: Profile
{
    public DomainToResponseMappingProfile()
    {
        CreateMap<Models.OperationType, OperationTypeDto>();
        CreateMap<CreateOperationTypeDto, Models.OperationType>();
        CreateMap<UpdateOperationTypeDto, Models.OperationType>();
        
        CreateMap<Models.FinancialOperation, FinancialOperationDto>();
        CreateMap<CreateFinancialOperationDto, Models.FinancialOperation>();
        CreateMap<UpdateFinancialOperationDto, Models.FinancialOperation>();
    }
    
}
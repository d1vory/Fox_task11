using AutoMapper;
using Task11.DTO.OperationType;

namespace Task11.DTO;

public class DomainToResponseMappingProfile: Profile
{
    public DomainToResponseMappingProfile()
    {
        CreateMap<Models.OperationType, OperationTypeDto>();
    }
    
}
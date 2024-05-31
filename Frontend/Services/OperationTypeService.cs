using System.Net.Http.Json;
using Shared2.DTO.OperationType;

namespace Frontend.Services;

public class OperationTypeService
{
    private HttpClient _httpClient;

    public OperationTypeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OperationTypeDto[]?> List()
    {
        return await _httpClient.GetFromJsonAsync<OperationTypeDto[]>("api/operation_type");
    }

    public async Task<UpdateOperationTypeDto> Retrieve(int id)
    {
        var obj = await _httpClient.GetFromJsonAsync<UpdateOperationTypeDto>($"api/operation_type/{id}/");
        if (obj == null)
        {
            throw new ApplicationException("Not found");
        }

        return obj;
    }
    
    public async Task<OperationTypeDto> Create(CreateOperationTypeDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/operation_type", dto);
        if (response.IsSuccessStatusCode)
        {
            var newObj = await response.Content.ReadFromJsonAsync<OperationTypeDto>();
            if (newObj != null)
            {
                return newObj;
            }
        }
        var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        throw new ApplicationException(error?["message"]);
    }


    
    public async Task<OperationTypeDto> Update(UpdateOperationTypeDto dto, int id)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/operation_type/{id}/", dto);
        if (response.IsSuccessStatusCode)
        {
            var newObj = await response.Content.ReadFromJsonAsync<OperationTypeDto>();
            if (newObj != null)
            {
                return newObj;
            }
        }
        var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
        throw new ApplicationException(error?["message"]);
    }
}
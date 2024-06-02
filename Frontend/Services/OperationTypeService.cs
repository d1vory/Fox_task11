using System.Net;
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

    public async Task<List<OperationTypeDto>?> List()
    {
        return await _httpClient.GetFromJsonAsync<List<OperationTypeDto>>("api/operation_type");
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
        await ProcessInvalidResponse(response);
        throw new ApplicationException("Error occured!");
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
        await ProcessInvalidResponse(response);
        throw new ApplicationException("Error occured!");
    }

    public async Task<bool> Delete(OperationTypeDto dto)
    {
        var response = await _httpClient.DeleteAsync($"api/operation_type/{dto.Id}/");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        await ProcessInvalidResponse(response);
        return false;
    }

    private async Task ProcessInvalidResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            throw new ApplicationException(error?["Message"]);
        }
    }
    
}
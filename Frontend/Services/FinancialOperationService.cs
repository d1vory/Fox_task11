using System.Net;
using System.Net.Http.Json;
using Shared2.DTO.FinancialOperation;

namespace Frontend.Services;

public class FinancialOperationService
{
    private HttpClient _httpClient;

    public FinancialOperationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FinancialOperationDto>?> List()
    {
        return await _httpClient.GetFromJsonAsync<List<FinancialOperationDto>>("api/operation");
    }

    public async Task<UpdateFinancialOperationDto> Retrieve(int id)
    {
        var obj = await _httpClient.GetFromJsonAsync<UpdateFinancialOperationDto>($"api/operation/{id}/");
        if (obj == null)
        {
            throw new ApplicationException("Not found");
        }

        return obj;
    }
    
    public async Task<FinancialOperationDto> Create(CreateFinancialOperationDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/operation", dto);
        if (response.IsSuccessStatusCode)
        {
            var newObj = await response.Content.ReadFromJsonAsync<FinancialOperationDto>();
            if (newObj != null)
            {
                return newObj;
            }
        }
        await ProcessInvalidResponse(response);
        throw new ApplicationException("Error occured!");
    }
    
    public async Task<FinancialOperationDto> Update(UpdateFinancialOperationDto dto, int id)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/operation/{id}/", dto);
        if (response.IsSuccessStatusCode)
        {
            var newObj = await response.Content.ReadFromJsonAsync<FinancialOperationDto>();
            if (newObj != null)
            {
                return newObj;
            }
        }
        await ProcessInvalidResponse(response);
        throw new ApplicationException("Error occured!");
    }

    public async Task<bool> Delete(FinancialOperationDto dto)
    {
        var response = await _httpClient.DeleteAsync($"api/operation/{dto.Id}/");
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
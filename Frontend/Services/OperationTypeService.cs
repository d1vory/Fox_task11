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
        throw new Exception(error?["message"]);
    }
}
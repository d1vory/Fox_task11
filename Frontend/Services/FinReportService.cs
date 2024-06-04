using System.Globalization;
using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using Shared2.DTO.Reports;

namespace Frontend.Services;

public class FinReportService
{
    private HttpClient _httpClient;

    public FinReportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<FinOpReportDto> GetPeriodicReport(DateTime startDate, DateTime? endDate = null)
    {
        var query = new Dictionary<string, string?>
        {
            ["startDate"] = startDate.Date.ToString(CultureInfo.InvariantCulture)
        };
        if (endDate.HasValue)
        {
            query["endDate"] = endDate.Value.Date.ToString(CultureInfo.InvariantCulture);
        }

        var url = QueryHelpers.AddQueryString("api/reports/operations", query);
        var res = await _httpClient.GetFromJsonAsync<FinOpReportDto>(url);
        if (res == null)
        {
            throw new ApplicationException("Could not get data");
        }

        return res;
    }
    
}
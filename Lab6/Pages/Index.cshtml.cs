using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab6.Models;

namespace Lab6.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public AppSettings AppSettings { get; }
    public string CurrentEnvironment { get; }

    public IndexModel(AppSettings appSettings, ILogger<IndexModel> logger, IWebHostEnvironment env)
    {
        AppSettings = appSettings;
        _logger = logger;
        CurrentEnvironment = env.EnvironmentName;
    }

    public void OnGet()
    {
        _logger.LogInformation("Current Environment: {Environment}", CurrentEnvironment);
        _logger.LogInformation("Application Name: {AppName}", AppSettings.ApplicationName);
        _logger.LogInformation("API Endpoint: {ApiEndpoint}", AppSettings.ApiEndpoint);
        _logger.LogInformation("Connection Timeout: {Timeout}", AppSettings.ConnectionTimeout);
        _logger.LogInformation("Feature X Enabled: {FeatureX}", AppSettings.EnableFeatureX);
        _logger.LogInformation("Debug Mode: {DebugMode}", AppSettings.DebugMode);
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ErrorHandling.Utils;

public class BlazorSchoolErrorBoundary : ErrorBoundary
{
    [Inject]
    public ExceptionRecorderService ExceptionRecorderService { get; set; } = default!;

    public BlazorSchoolErrorBoundary()
    {
        MaximumErrorCount = 2;
    }

    protected override Task OnErrorAsync(Exception exception)
    {
        ExceptionRecorderService.Exceptions.Add(exception);

        return Task.CompletedTask;
    }
}
using Microsoft.JSInterop;
namespace AttendancePayrollWebServerApp.Helper
{
    public static class IJSRuntimeExtentioncs 
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
         {
           await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
         }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

    }
}
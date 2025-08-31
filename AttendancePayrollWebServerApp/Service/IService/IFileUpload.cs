using Microsoft.AspNetCore.Components.Forms;

namespace AttendancePayrollWebServerApp.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);

        //Task<string> UploadFileToEmployee (IBrowserFile file);

        bool DeleteFile(string filePath);


    }
}

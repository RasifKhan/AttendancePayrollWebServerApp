using AttendancePayrollWebServerApp.Pages.Company;
using AttendancePayrollWebServerApp.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
namespace AttendancePayrollWebServerApp.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string filePath)
        {
            if (File.Exists(_webHostEnvironment.WebRootPath + filePath))
            {
                File.Delete(_webHostEnvironment.WebRootPath + filePath);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name);
            var fileName = Guid.NewGuid().ToString().ToString() + fileInfo.Extension;
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\employeeTemp";
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }
            var filePath = Path.Combine(folderDirectory, fileName);
            await using FileStream fs = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
            var fullPath = $"/images/employeeTemp/{fileName}";
            return fullPath;
        }

        private void DeleteAllFilesInDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {

                    string[] files = Directory.GetFiles(directoryPath);
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }
                else
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting files in {directoryPath}: {ex.Message}");
            }
        }


        //public async Task<string> UploadFileToEmployee(IBrowserFile file)
        //{
        //    FileInfo fileInfo = new(file.Name);
        //    var fileName = Guid.NewGuid().ToString().ToString() + fileInfo.Extension;
        //    var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\employeeTemp";
        //    if (!Directory.Exists(folderDirectory))
        //    {
        //        Directory.CreateDirectory(folderDirectory);
        //    }
        //    var filePath = Path.Combine(folderDirectory, fileName);
        //    await using FileStream fs = new FileStream(filePath, FileMode.Create);
        //    await file.OpenReadStream().CopyToAsync(fs);
        //    var fullPath = $"/images/employeeTemp/{fileName}";
        //    return fullPath;
        //}


    }
}


 














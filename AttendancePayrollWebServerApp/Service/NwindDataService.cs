using AttendancePayrollWebServerApp.Models;

namespace AttendancePayrollWebServerApp.Service
{
    public  class NwindDataService
    {
        public Task<IEnumerable<EditableEmployee>> GetEmployeesEditableAsync(CancellationToken ct = default)
        {
            // Return your data here
            return null;
        }
        public Task InsertEmployeeAsync(IDictionary<string, object> newValues)
        {
            // Change your data here
            return null;
        }
        public Task InsertEmployeeAsync(EditableEmployee newDataItem)
        {
            // Change your data here
            return null;
        }
        public Task RemoveEmployeeAsync(EditableEmployee dataItem)
        {
            // Change your data here
            return null;
        }
        public Task UpdateEmployeeAsync(EditableEmployee dataItem, IDictionary<string, object> newValues)
        {
            // Change your data here
            return null;
        }
        public Task UpdateEmployeeAsync(EditableEmployee dataItem, EditableEmployee newDataItem)
        {
            // Change your data here
            return null;
        }
    }
}

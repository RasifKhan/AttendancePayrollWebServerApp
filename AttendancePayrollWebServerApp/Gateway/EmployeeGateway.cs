using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;


namespace AttendancePayrollWebServerApp.Gateway
{
    public class EmployeeGateway : Gateway
    {

        public async Task<Alert> Save(Employee employee, string existCondition = "")
        {
            try
            {
                if (existCondition != "")
                {
                    if (await IsExist(existCondition) == true)
                    {
                        return new Alert("warning", "The record is already exist");
                    }
                }

                Query = "INSERT INTO Employee (EmployeeId,EmployeeName,DesignationId,CompanyId,DepartmentId,SectionId,SalarySectionId,FloorCatItemId,LineCatItemId,ShiftTypeMasterId,ShiftDetailId,Sex,DateOfBirth,Religion,Blood,MobileNo,EmergencyContact,Mail,EmployeeNameBan,FatherName,MotherName,SpouseName,FatherNameBan,MotherNameBan,SpouseNameBan,PermanentAddress,PermanentAddressBan,PresentAddress,PresentAddressBan,MaritalStatus,NID,BirthCertificateNo,PassportNo,DrivingLicenseNo,BodySign,JoinDate,ReleaseYN,ReleaseDate,Salary,BasicSalary,OverTimeYN,LunchYN,ConfirmYN,ConfirmDate,TransportYN,PaySource,ActiveYN,CardID,SN,EmployeeTypeCatItemId,AppointmentType,HeistEducationCatItemId,ProvidentFundYN,SalaryBuyer,JoiningDateBuyer,BuyerShow,BankName,BankAccNo,BGMEAID,TinNo,RegistrationNo,PhysicalStrength,Experience,ImmageUrl) VALUES(TRIM(@employeeId),@employeeName,@designationId,@companyId,@departmentId,@sectionId,@salarySectionId,@floorCatItemId,@lineCatItemId,@shiftTypeMasterId,@shiftDetailId,@sex,@dateOfBirth,@religion,@blood,@mobileNo,@emergencyContact,@mail,@employeeNameBan,@fatherName,@motherName,@spouseName,@fatherNameBan,@motherNameBan,@spouseNameBan,@permanentAddress,@permanentAddressBan,@presentAddress,@presentAddressBan,@maritalStatus,@nID,@birthCertificateNo,@passportNo,@drivingLicenseNo,@bodySign,@joinDate,@releaseYN,@releaseDate,@salary,@basicSalary,@overTimeYN,@lunchYN,@confirmYN,@confirmDate,@transportYN,@paySource,@activeYN,@cardID,@sN,@employeeTypeCatItemId,@appointmentType,@heistEducationCatItemId,@providentFundYN,@salaryBuyer,@joiningDateBuyer,@buyerShow,@bankName,@bankAccNo,@bGMEAID,@tinNo,@registrationNo,@physicalStrength,@experience,@immageUrl)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                Command.Parameters.AddWithValue("@employeeName", employee.EmployeeName);
                Command.Parameters.AddWithValue("@designationId", employee.DesignationId);
                Command.Parameters.AddWithValue("@companyId", employee.CompanyId);
                Command.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
                Command.Parameters.AddWithValue("@sectionId", employee.SectionId);
                Command.Parameters.AddWithValue("@salarySectionId", employee.SalarySectionId);
                Command.Parameters.AddWithValue("@floorCatItemId", employee.FloorCatItemId);
                Command.Parameters.AddWithValue("@lineCatItemId", employee.LineCatItemId);
                Command.Parameters.AddWithValue("@shiftTypeMasterId", employee.ShiftTypeMasterId);
                //Command.Parameters.AddWithValue("@shiftDetailId", employee.ShiftDetailId);
                Command.Parameters.AddWithValue("@shiftDetailId", (object)employee.ShiftDetailId ?? DBNull.Value);
                Command.Parameters.AddWithValue("@sex", employee.Sex);
                Command.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
                Command.Parameters.AddWithValue("@religion", employee.Religion);
                Command.Parameters.AddWithValue("@blood", employee.Blood);
                Command.Parameters.AddWithValue("@mobileNo", employee.MobileNo);
                Command.Parameters.AddWithValue("@emergencyContact", employee.EmergencyContact);
                Command.Parameters.AddWithValue("@mail", employee.Mail);
                Command.Parameters.AddWithValue("@employeeNameBan", employee.EmployeeNameBan);
                Command.Parameters.AddWithValue("@fatherName", employee.FatherName);
                Command.Parameters.AddWithValue("@motherName", employee.MotherName);
                Command.Parameters.AddWithValue("@spouseName", employee.SpouseName);
                Command.Parameters.AddWithValue("@fatherNameBan", employee.FatherNameBan);
                Command.Parameters.AddWithValue("@motherNameBan", employee.MotherNameBan);
                Command.Parameters.AddWithValue("@spouseNameBan", employee.SpouseNameBan);
                Command.Parameters.AddWithValue("@permanentAddress", employee.PermanentAddress);
                Command.Parameters.AddWithValue("@permanentAddressBan", employee.PermanentAddressBan);
                Command.Parameters.AddWithValue("@presentAddress", employee.PresentAddress);
                Command.Parameters.AddWithValue("@presentAddressBan", employee.PresentAddressBan);
                Command.Parameters.AddWithValue("@maritalStatus", employee.MaritalStatus);
                Command.Parameters.AddWithValue("@nID", employee.NID);
                Command.Parameters.AddWithValue("@birthCertificateNo", employee.BirthCertificateNo);
                Command.Parameters.AddWithValue("@passportNo", employee.PassportNo);
                Command.Parameters.AddWithValue("@drivingLicenseNo", employee.DrivingLicenseNo);
                Command.Parameters.AddWithValue("@bodySign", employee.BodySign);
                Command.Parameters.AddWithValue("@joinDate", employee.JoinDate);
                Command.Parameters.AddWithValue("@releaseYN", employee.ReleaseYN);
                Command.Parameters.AddWithValue("@releaseDate", employee.ReleaseDate);
                Command.Parameters.AddWithValue("@salary", employee.Salary);
                Command.Parameters.AddWithValue("@basicSalary", employee.BasicSalary);
                Command.Parameters.AddWithValue("@overTimeYN", employee.OverTimeYN);
                Command.Parameters.AddWithValue("@lunchYN", employee.LunchYN);
                Command.Parameters.AddWithValue("@confirmYN", employee.ConfirmYN);
                Command.Parameters.AddWithValue("@confirmDate", employee.ConfirmDate);
                Command.Parameters.AddWithValue("@transportYN", employee.TransportYN);
                Command.Parameters.AddWithValue("@paySource", employee.PaySource);
                Command.Parameters.AddWithValue("@activeYN", employee.ActiveYN);
                Command.Parameters.AddWithValue("@cardID", employee.CardID);
                Command.Parameters.AddWithValue("@sN", employee.SN);
                Command.Parameters.AddWithValue("@employeeTypeCatItemId", employee.EmployeeTypeCatItemId);
                Command.Parameters.AddWithValue("@appointmentType", employee.AppointmentType);
                Command.Parameters.AddWithValue("@heistEducationCatItemId", employee.HeistEducationCatItemId);
                Command.Parameters.AddWithValue("@providentFundYN", employee.ProvidentFundYN);
                Command.Parameters.AddWithValue("@salaryBuyer", employee.SalaryBuyer);
                Command.Parameters.AddWithValue("@joiningDateBuyer", employee.JoiningDateBuyer);
                Command.Parameters.AddWithValue("@buyerShow", employee.BuyerShow);
                Command.Parameters.AddWithValue("@bankName", employee.BankName);
                Command.Parameters.AddWithValue("@bankAccNo", employee.BankAccNo);
                Command.Parameters.AddWithValue("@bGMEAID", employee.BGMEAID);
                Command.Parameters.AddWithValue("@tinNo", employee.TinNo);
                Command.Parameters.AddWithValue("@registrationNo", employee.RegistrationNo);
                Command.Parameters.AddWithValue("@physicalStrength", employee.PhysicalStrength);
                Command.Parameters.AddWithValue("@experience", employee.Experience);
                Command.Parameters.AddWithValue("@immageUrl", employee.ImmageUrl);
                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();
                if (rowAffected > 0)
                {
                    return new Alert("success", "Saved successfully");
                }
                return new Alert("warning", "Not Saved");
            }
            catch (SqlException sqlEx)
            {
                return new Alert("danger", $"Database Error: {sqlEx.Message}\nError Code: {sqlEx.Number}");
            }
            catch (Exception exception)
            {
                return new Alert("danger", $"Failed To Save: {exception.Message}");
            }
            finally
            {
                ConnectionClose();
            }
        }

        


        public async Task<Alert> Edit(Employee employee, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Employee SET EmployeeName=@empIoyeeName,DesignationId=@designationId,CompanyId=@companyId,DepartmentId=@departmentId,SectionId=@sectionId,SalarySectionId=@salarySectionId,FloorCatItemId=@floorCatItemId,LineCatItemId=@lineCatItemId,ShiftTypeMasterId=@shiftTypeMasterId,ShiftDetailId=@shiftDetailId, Sex=@sex,DateOfBirth=@dateOfBirth,Religion=@religion,Blood=@blood,MobileNo=@mobileNo,EmergencyContact=@emergencyContact,Mail=@mail,EmployeeNameBan=@employeeNameBan,FatherName=@fatherName,MotherName=@motherName,SpouseName=@spouseName,FatherNameBan=@fatherNameBan,MotherNameBan=@motherNameBan,SpouseNameBan=@spouseNameBan,PermanentAddress=@permanentAddress,PermanentAddressBan=@permanentAddressBan,PresentAddress=@presentAddress,PresentAddressBan=@presentAddressBan,MaritalStatus=@maritalStatus,NID=@nID,BirthCertificateNo=@birthCertificateNo,PassportNo=@passportNo,DrivingLicenseNo=@drivingLicenseNo,BodySign=@bodySign,JoinDate=@joinDate,ReleaseYN=@releaseYN,ReleaseDate=@releaseDate,Salary=@salary,BasicSalary=@basicSalary,OverTimeYN=@overTimeYN,LunchYN=@lunchYN,ConfirmYN=@confirmYN,ConfirmDate=@confirmDate,TransportYN=@transportYN,PaySource=@paySource,ActiveYN=@activeYN,CardID=@cardID,SN=@sN,EmployeeTypeCatItemId=@employeeTypeCatItemId,AppointmentType=@appointmentType,HeistEducationCatItemId=@heistEducationCatItemId,ProvidentFundYN=@providentFundYN,SalaryBuyer=@salaryBuyer,JoiningDateBuyer=@joiningDateBuyer,BuyerShow=@buyerShow,BankName=@bankName,BankAccNo=@bankAccNo,BGMEAID=@bGMEAID,TinNo=@tinNo,RegistrationNo=@registrationNo,PhysicalStrength=@physicalStrength,Experience=@experience, ImmageUrl=@immageUrl WHERE EmployeeId = @empIoyeeId";
                }
                else
                {
                    Query = "UPDATE Employee SET EmployeeName=@empIoyeeName,DesignationId=@designationId,CompanyId=@companyId,DepartmentId=@departmentId,SectionId=@sectionId,SalarySectionId=@salarySectionId,FloorCatItemId=@floorCatItemId,LineCatItemId=@lineCatItemId,ShiftTypeMasterId=@shiftTypeMasterId,ShiftDetailId=@shiftDetailId, Sex=@sex,DateOfBirth=@dateOfBirth,Religion=@religion,Blood=@blood,MobileNo=@mobileNo,EmergencyContact=@emergencyContact,Mail=@mail,EmployeeNameBan=@employeeNameBan,FatherName=@fatherName,MotherName=@motherName,SpouseName=@spouseName,FatherNameBan=@fatherNameBan,MotherNameBan=@motherNameBan,SpouseNameBan=@spouseNameBan,PermanentAddress=@permanentAddress,PermanentAddressBan=@permanentAddressBan,PresentAddress=@presentAddress,PresentAddressBan=@presentAddressBan,MaritalStatus=@maritalStatus,NID=@nID,BirthCertificateNo=@birthCertificateNo,PassportNo=@passportNo,DrivingLicenseNo=@drivingLicenseNo,BodySign=@bodySign,JoinDate=@joinDate,ReleaseYN=@releaseYN,ReleaseDate=@releaseDate,Salary=@salary,BasicSalary=@basicSalary,OverTimeYN=@overTimeYN,LunchYN=@lunchYN,ConfirmYN=@confirmYN,ConfirmDate=@confirmDate,TransportYN=@transportYN,PaySource=@paySource,ActiveYN=@activeYN,CardID=@cardID,SN=@sN,EmployeeTypeCatItemId=@employeeTypeCatItemId,AppointmentType=@appointmentType,HeistEducationCatItemId=@heistEducationCatItemId,ProvidentFundYN=@providentFundYN,SalaryBuyer=@salaryBuyer,JoiningDateBuyer=@joiningDateBuyer,BuyerShow=@buyerShow,BankName=@bankName,BankAccNo=@bankAccNo,BGMEAID=@bGMEAID,TinNo=@tinNo,RegistrationNo=@registrationNo,PhysicalStrength=@physicalStrength,Experience=@experience, ImmageUrl=@immageUrl WHERE " + condition;
                }
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@empIoyeeId", employee.EmployeeId);
                Command.Parameters.AddWithValue("@empIoyeeName", employee.EmployeeName);
                Command.Parameters.AddWithValue("@designationId", employee.DesignationId);
                Command.Parameters.AddWithValue("@companyId", employee.CompanyId);
                Command.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
                Command.Parameters.AddWithValue("@sectionId", employee.SectionId);
                Command.Parameters.AddWithValue("@salarySectionId", employee.SalarySectionId);
                Command.Parameters.AddWithValue("@floorCatItemId", employee.FloorCatItemId);
                Command.Parameters.AddWithValue("@lineCatItemId", employee.LineCatItemId);
                Command.Parameters.AddWithValue("@shiftTypeMasterId", employee.ShiftTypeMasterId);
                Command.Parameters.AddWithValue("@shiftDetailId", (object)employee.ShiftDetailId ?? DBNull.Value);
                Command.Parameters.AddWithValue("@sex", employee.Sex);
                Command.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
                Command.Parameters.AddWithValue("@religion", employee.Religion);
                Command.Parameters.AddWithValue("@blood", employee.Blood);
                Command.Parameters.AddWithValue("@mobileNo", employee.MobileNo);
                Command.Parameters.AddWithValue("@emergencyContact", employee.EmergencyContact);
                Command.Parameters.AddWithValue("@mail", employee.Mail);
                Command.Parameters.AddWithValue("@employeeNameBan", employee.EmployeeNameBan);
                Command.Parameters.AddWithValue("@fatherName", employee.FatherName);
                Command.Parameters.AddWithValue("@motherName", employee.MotherName);
                Command.Parameters.AddWithValue("@spouseName", employee.SpouseName);
                Command.Parameters.AddWithValue("@fatherNameBan", employee.FatherNameBan);
                Command.Parameters.AddWithValue("@motherNameBan", employee.MotherNameBan);
                Command.Parameters.AddWithValue("@spouseNameBan", employee.SpouseNameBan);
                Command.Parameters.AddWithValue("@permanentAddress", employee.PermanentAddress);
                Command.Parameters.AddWithValue("@permanentAddressBan", employee.PermanentAddressBan);
                Command.Parameters.AddWithValue("@presentAddress", employee.PresentAddress);
                Command.Parameters.AddWithValue("@presentAddressBan", employee.PresentAddressBan);
                Command.Parameters.AddWithValue("@maritalStatus", employee.MaritalStatus);
                Command.Parameters.AddWithValue("@nID", employee.NID);
                Command.Parameters.AddWithValue("@birthCertificateNo", employee.BirthCertificateNo);
                Command.Parameters.AddWithValue("@passportNo", employee.PassportNo);
                Command.Parameters.AddWithValue("@drivingLicenseNo", employee.DrivingLicenseNo);
                Command.Parameters.AddWithValue("@bodySign", employee.BodySign);
                Command.Parameters.AddWithValue("@joinDate", employee.JoinDate);
                Command.Parameters.AddWithValue("@releaseYN", employee.ReleaseYN);
                Command.Parameters.AddWithValue("@releaseDate", employee.ReleaseDate);
                Command.Parameters.AddWithValue("@salary", employee.Salary);
                Command.Parameters.AddWithValue("@basicSalary", employee.BasicSalary);
                Command.Parameters.AddWithValue("@overTimeYN", employee.OverTimeYN);
                Command.Parameters.AddWithValue("@lunchYN", employee.LunchYN);
                Command.Parameters.AddWithValue("@confirmYN", employee.ConfirmYN);
                Command.Parameters.AddWithValue("@confirmDate", employee.ConfirmDate);
                Command.Parameters.AddWithValue("@transportYN", employee.TransportYN);
                Command.Parameters.AddWithValue("@paySource", employee.PaySource);
                Command.Parameters.AddWithValue("@activeYN", employee.ActiveYN);
                Command.Parameters.AddWithValue("@cardID", employee.CardID);
                Command.Parameters.AddWithValue("@sN", employee.SN);
                Command.Parameters.AddWithValue("@employeeTypeCatItemId", employee.EmployeeTypeCatItemId);
                Command.Parameters.AddWithValue("@appointmentType", employee.AppointmentType);
                Command.Parameters.AddWithValue("@heistEducationCatItemId", employee.HeistEducationCatItemId);
                Command.Parameters.AddWithValue("@providentFundYN", employee.ProvidentFundYN);
                Command.Parameters.AddWithValue("@salaryBuyer", employee.SalaryBuyer);
                Command.Parameters.AddWithValue("@joiningDateBuyer", employee.JoiningDateBuyer);
                Command.Parameters.AddWithValue("@buyerShow", employee.BuyerShow);
                Command.Parameters.AddWithValue("@bankName", employee.BankName);
                Command.Parameters.AddWithValue("@bankAccNo", employee.BankAccNo);
                Command.Parameters.AddWithValue("@bGMEAID", employee.BGMEAID);
                Command.Parameters.AddWithValue("@tinNo", employee.TinNo);
                Command.Parameters.AddWithValue("@registrationNo", employee.RegistrationNo);
                Command.Parameters.AddWithValue("@physicalStrength", employee.PhysicalStrength);
                Command.Parameters.AddWithValue("@experience", employee.Experience);
                Command.Parameters.AddWithValue("@immageUrl", employee.ImmageUrl);
                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();
                if (rowAffected > 0)
                {
                    return new Alert("success", "Updated");
                }
                return new Alert("warning", "Not Updated");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Updated\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Alert> Delete(string empIoyeeId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Employee WHERE EmployeeId = @empIoyeeId";
                }
                else
                {
                    Query = "DELETE Employee WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@empIoyeeId", empIoyeeId);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Deleted");
                }
                return new Alert("warning", "Not Deleted");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Delete\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<bool> IsExist(string employeeId = "")
        {
            try
            {
                if (employeeId == "")
                {
                    Query = "SELECT 1 FROM Employee";
                }
                if(employeeId !="" )
                {
                    // Query = $"SELECT 1 FROM Employee WHERE EmployeeId='{employeeId}'";
                    Query = $"SELECT 1 FROM Employee WHERE EmployeeId = '{employeeId.Trim()}'"; //$"SELECT 1 FROM Employee WHERE EmployeeId = '{TRIM(employeeId)}'";
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                bool exist = Reader.HasRows;
                Reader.Close();
                ConnectionClose();
                return exist;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<Employee> GetEmployee(string empIoyeeId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Employee WHERE EmployeeId = @empIoyeeId";
                }
                else
                {
                    Query = "SELECT * FROM Employee WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@empIoyeeId", empIoyeeId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Employee employee = new Employee();
                while (Reader.Read())
                {
                    employee.EmployeeId = Reader["EmployeeId"].ToString();
                    employee.EmployeeName = Reader["EmployeeName"].ToString();
                    employee.DesignationId = (int)Reader["DesignationId"];
                    employee.CompanyId = (int)Reader["CompanyId"];
                    employee.DepartmentId = (int)Reader["DepartmentId"];
                    employee.SectionId = (int)Reader["SectionId"];
                    employee.SalarySectionId = (int)Reader["SalarySectionId"];
                    employee.FloorCatItemId = (int)Reader["FloorCatItemId"];
                    employee.LineCatItemId = (int)Reader["LineCatItemId"];


                    employee.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    // employee.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    //employee.ShiftDetailId = Reader["ShiftDetailId"] != DBNull.Value ? (int)Reader["ShiftDetailId"] : default(int);
                    employee.ShiftDetailId = Reader["ShiftDetailId"] != DBNull.Value ? (int?)Reader["ShiftDetailId"] : null;

                    employee.Sex = Reader["Sex"].ToString();
                    employee.DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    employee.Religion = Reader["Religion"].ToString();
                    employee.Blood = Reader["Blood"].ToString();
                    employee.MobileNo = Reader["MobileNo"].ToString();
                    employee.EmergencyContact = Reader["EmergencyContact"].ToString();
                    employee.Mail = Reader["Mail"].ToString();
                    employee.EmployeeNameBan = Reader["EmployeeNameBan"].ToString();
                    employee.FatherName = Reader["FatherName"].ToString();
                    employee.MotherName = Reader["MotherName"].ToString();
                    employee.SpouseName = Reader["SpouseName"].ToString();
                    employee.FatherNameBan = Reader["FatherNameBan"].ToString();
                    employee.MotherNameBan = Reader["MotherNameBan"].ToString();
                    employee.SpouseNameBan = Reader["SpouseNameBan"].ToString();
                    employee.PermanentAddress = Reader["PermanentAddress"].ToString();
                    employee.PermanentAddressBan = Reader["PermanentAddressBan"].ToString();
                    employee.PresentAddress = Reader["PresentAddress"].ToString();
                    employee.PresentAddressBan = Reader["PresentAddressBan"].ToString();
                    employee.MaritalStatus = Reader["MaritalStatus"].ToString();
                    employee.NID = Reader["NID"].ToString();
                    employee.BirthCertificateNo = Reader["BirthCertificateNo"].ToString();
                    employee.PassportNo = Reader["PassportNo"].ToString();
                    employee.DrivingLicenseNo = Reader["DrivingLicenseNo"].ToString();
                    employee.BodySign = Reader["BodySign"].ToString();
                    employee.JoinDate = (DateTime)Reader["JoinDate"];
                    employee.ReleaseYN = Reader["ReleaseYN"].ToString();
                    employee.ReleaseDate = (DateTime)Reader["ReleaseDate"];
                    employee.Salary = (decimal)Reader["Salary"];
                    employee.BasicSalary = (decimal)Reader["BasicSalary"];
                    employee.OverTimeYN = Reader["OverTimeYN"].ToString();
                    employee.LunchYN = Reader["LunchYN"].ToString();
                    employee.ConfirmYN = Reader["ConfirmYN"].ToString();
                    employee.ConfirmDate = (DateTime)Reader["ConfirmDate"];
                    employee.TransportYN = Reader["TransportYN"].ToString();
                    employee.PaySource = Reader["PaySource"].ToString();
                    employee.ActiveYN = Reader["ActiveYN"].ToString();
                    employee.CardID = Reader["CardID"].ToString();

                    employee.SN = (decimal)Reader["SN"];
                    employee.EmployeeTypeCatItemId = (int)Reader["EmployeeTypeCatItemId"];
                    

                    employee.AppointmentType = Reader["AppointmentType"].ToString();
                    employee.HeistEducationCatItemId = (int)Reader["HeistEducationCatItemId"];
                    employee.ProvidentFundYN = Reader["ProvidentFundYN"].ToString();

                    employee.SalaryBuyer = (decimal)Reader["SalaryBuyer"];
                    employee.JoiningDateBuyer = (DateTime)Reader["JoiningDateBuyer"];
                    employee.BuyerShow = Reader["BuyerShow"].ToString();
                    employee.BankName = Reader["BankName"].ToString();
                    employee.BankAccNo = Reader["BankAccNo"].ToString();
                    employee.BGMEAID = Reader["BGMEAID"].ToString();

                    employee.TinNo = Reader["TinNo"].ToString();
                    employee.RegistrationNo = Reader["RegistrationNo"].ToString();

                    employee.PhysicalStrength = Reader["PhysicalStrength"].ToString();
                    employee.Experience = Reader["Experience"].ToString();
                    employee.ImmageUrl = Reader["ImmageUrl"].ToString();
                    




                }
                Reader.Close();
                ConnectionClose();
                return employee;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Employee\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<List<Employee>> GetEmployeeList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Employee order by SN";
                }
                else
                {
                    Query = "SELECT * FROM Employee WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Employee> employeeList = new List<Employee>();
                while (Reader.Read())
                {
                    Employee employee = new Employee();

                    employee.EmployeeId = Reader["EmployeeId"].ToString();
                    employee.EmployeeName = Reader["EmployeeName"].ToString();
                    employee.DesignationId = (int)Reader["DesignationId"];
                    employee.CompanyId = (int)Reader["CompanyId"];
                    employee.DepartmentId = (int)Reader["DepartmentId"];
                    employee.SectionId = (int)Reader["SectionId"];
                    employee.SalarySectionId = (int)Reader["SalarySectionId"];
                    employee.FloorCatItemId = (int)Reader["FloorCatItemId"];
                    employee.LineCatItemId = (int)Reader["LineCatItemId"];
                    employee.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    employee.Sex = Reader["Sex"].ToString();
                    employee.DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    employee.Religion = Reader["Religion"].ToString();
                    employee.Blood = Reader["Blood"].ToString();
                    employee.MobileNo = Reader["MobileNo"].ToString();
                    employee.EmergencyContact = Reader["EmergencyContact"].ToString();
                    employee.Mail = Reader["Mail"].ToString();
                    employee.EmployeeNameBan = Reader["EmployeeNameBan"].ToString();
                    employee.FatherName = Reader["FatherName"].ToString();
                    employee.MotherName = Reader["MotherName"].ToString();
                    employee.SpouseName = Reader["SpouseName"].ToString();
                    employee.FatherNameBan = Reader["FatherNameBan"].ToString();
                    employee.MotherNameBan = Reader["MotherNameBan"].ToString();
                    employee.SpouseNameBan = Reader["SpouseNameBan"].ToString();
                    employee.PermanentAddress = Reader["PermanentAddress"].ToString();
                    employee.PermanentAddressBan = Reader["PermanentAddressBan"].ToString();
                    employee.PresentAddress = Reader["PresentAddress"].ToString();
                    employee.PresentAddressBan = Reader["PresentAddressBan"].ToString();
                    employee.MaritalStatus = Reader["MaritalStatus"].ToString();
                    employee.NID = Reader["NID"].ToString();
                    employee.BirthCertificateNo = Reader["BirthCertificateNo"].ToString();
                    employee.PassportNo = Reader["PassportNo"].ToString();
                    employee.DrivingLicenseNo = Reader["DrivingLicenseNo"].ToString();
                    employee.BodySign = Reader["BodySign"].ToString();
                    employee.JoinDate = (DateTime)Reader["JoinDate"];
                    employee.ReleaseYN = Reader["ReleaseYN"].ToString();
                    employee.ReleaseDate = (DateTime)Reader["ReleaseDate"];
                    employee.Salary = (decimal)Reader["Salary"];
                    employee.BasicSalary = (decimal)Reader["BasicSalary"];
                    employee.OverTimeYN = Reader["OverTimeYN"].ToString();
                    employee.LunchYN = Reader["LunchYN"].ToString();
                    employee.ConfirmYN = Reader["ConfirmYN"].ToString();
                    employee.ConfirmDate = (DateTime)Reader["ConfirmDate"];
                    employee.TransportYN = Reader["TransportYN"].ToString();
                    employee.PaySource = Reader["PaySource"].ToString();
                    employee.ActiveYN = Reader["ActiveYN"].ToString();
                    employee.CardID = Reader["CardID"].ToString();
                    employee.SN = (decimal)Reader["SN"];
                    employee.EmployeeTypeCatItemId = (int)Reader["EmployeeTypeCatItemId"];
                    employee.AppointmentType = Reader["AppointmentType"].ToString();
                    employee.HeistEducationCatItemId = (int)Reader["HeistEducationCatItemId"];
                    employee.ProvidentFundYN = Reader["ProvidentFundYN"].ToString();
                    employee.SalaryBuyer = (decimal)Reader["SalaryBuyer"];
                    employee.JoiningDateBuyer = (DateTime)Reader["JoiningDateBuyer"];
                    employee.BuyerShow = Reader["BuyerShow"].ToString();
                    employee.BankName = Reader["BankName"].ToString();
                    employee.BankAccNo = Reader["BankAccNo"].ToString();
                    employee.BGMEAID = Reader["BGMEAID"].ToString();
                    employee.TinNo = Reader["TinNo"].ToString();
                    employee.RegistrationNo = Reader["RegistrationNo"].ToString();
                    employee.PhysicalStrength = Reader["PhysicalStrength"].ToString();
                    employee.Experience = Reader["Experience"].ToString();
                    employeeList.Add(employee);
                }
                Reader.Close();
                ConnectionClose();
                return employeeList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Employee List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Employee>> GetEmployeeListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Employee";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Employee WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Employee> employeeList = new List<Employee>();
                while (Reader.Read())
                {
                    Employee employee = new Employee();

                    SkipOnError(() => employee.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => employee.EmployeeName = Reader["EmployeeName"].ToString());
                    SkipOnError(() => employee.DesignationId = (int)Reader["DesignationId"]);
                    SkipOnError(() => employee.CompanyId = (int)Reader["CompanyId"]);
                    SkipOnError(() => employee.DepartmentId = (int)Reader["DepartmentId"]);
                    SkipOnError(() => employee.SectionId = (int)Reader["SectionId"]);
                    SkipOnError(() => employee.SalarySectionId = (int)Reader["SalarySectionId"]);
                    SkipOnError(() => employee.FloorCatItemId = (int)Reader["FloorCatItemId"]);
                    SkipOnError(() => employee.LineCatItemId = (int)Reader["LineCatItemId"]);


                    SkipOnError(() => employee.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"]);
                 
                   


                    SkipOnError(() => employee.Sex = Reader["Sex"].ToString());
                    SkipOnError(() => employee.DateOfBirth = (DateTime)Reader["DateOfBirth"]);
                    SkipOnError(() => employee.Religion = Reader["Religion"].ToString());
                    SkipOnError(() => employee.Blood = Reader["Blood"].ToString());
                    SkipOnError(() => employee.MobileNo = Reader["MobileNo"].ToString());
                    SkipOnError(() => employee.EmergencyContact = Reader["EmergencyContact"].ToString());
                    SkipOnError(() => employee.Mail = Reader["Mail"].ToString());
                    SkipOnError(() => employee.EmployeeNameBan = Reader["EmployeeNameBan"].ToString());
                    SkipOnError(() => employee.FatherName = Reader["FatherName"].ToString());
                    SkipOnError(() => employee.MotherName = Reader["MotherName"].ToString());
                    SkipOnError(() => employee.SpouseName = Reader["SpouseName"].ToString());
                    SkipOnError(() => employee.FatherNameBan = Reader["FatherNameBan"].ToString());
                    SkipOnError(() => employee.MotherNameBan = Reader["MotherNameBan"].ToString());
                    SkipOnError(() => employee.SpouseNameBan = Reader["SpouseNameBan"].ToString());
                    SkipOnError(() => employee.PermanentAddress = Reader["PermanentAddress"].ToString());
                    SkipOnError(() => employee.PermanentAddressBan = Reader["PermanentAddressBan"].ToString());
                    SkipOnError(() => employee.PresentAddress = Reader["PresentAddress"].ToString());
                    SkipOnError(() => employee.PresentAddressBan = Reader["PresentAddressBan"].ToString());
                    SkipOnError(() => employee.MaritalStatus = Reader["MaritalStatus"].ToString());
                    SkipOnError(() => employee.NID = Reader["NID"].ToString());
                    SkipOnError(() => employee.BirthCertificateNo = Reader["BirthCertificateNo"].ToString());
                    SkipOnError(() => employee.PassportNo = Reader["PassportNo"].ToString());
                    SkipOnError(() => employee.DrivingLicenseNo = Reader["DrivingLicenseNo"].ToString());
                    SkipOnError(() => employee.BodySign = Reader["BodySign"].ToString());
                    SkipOnError(() => employee.JoinDate = (DateTime)Reader["JoinDate"]);
                    SkipOnError(() => employee.ReleaseYN = Reader["ReleaseYN"].ToString());
                    SkipOnError(() => employee.ReleaseDate = (DateTime)Reader["ReleaseDate"]);
                    SkipOnError(() => employee.Salary = (decimal)Reader["Salary"]);
                    SkipOnError(() => employee.BasicSalary = (decimal)Reader["BasicSalary"]);
                    SkipOnError(() => employee.OverTimeYN = Reader["OverTimeYN"].ToString());
                    SkipOnError(() => employee.LunchYN = Reader["LunchYN"].ToString());
                    SkipOnError(() => employee.ConfirmYN = Reader["ConfirmYN"].ToString());
                    SkipOnError(() => employee.ConfirmDate = (DateTime)Reader["ConfirmDate"]);
                    SkipOnError(() => employee.TransportYN = Reader["TransportYN"].ToString());
                    SkipOnError(() => employee.PaySource = Reader["PaySource"].ToString());
                    SkipOnError(() => employee.ActiveYN = Reader["ActiveYN"].ToString());
                    SkipOnError(() => employee.CardID = Reader["CardID"].ToString());
                  
                    SkipOnError(() => employee.SN = (decimal)Reader["SN"]);
                    SkipOnError(() => employee.EmployeeTypeCatItemId = (int)Reader["EmployeeTypeCatItemId"]);
                    SkipOnError(() => employee.AppointmentType = Reader["AppointmentType"].ToString());
                    SkipOnError(() => employee.HeistEducationCatItemId = (int)Reader["HeistEducationCatItemId"]);
                    SkipOnError(() => employee.ProvidentFundYN = Reader["ProvidentFundYN"].ToString());
                   
                    SkipOnError(() => employee.SalaryBuyer = (decimal)Reader["SalaryBuyer"]);
                    SkipOnError(() => employee.JoiningDateBuyer = (DateTime)Reader["JoiningDateBuyer"]);
                    SkipOnError(() => employee.BuyerShow = Reader["BuyerShow"].ToString());
                    SkipOnError(() => employee.BankName = Reader["BankName"].ToString());
                    SkipOnError(() => employee.BankAccNo = Reader["BankAccNo"].ToString());
                    SkipOnError(() => employee.BGMEAID = Reader["BGMEAID"].ToString());

                    SkipOnError(() => employee.TinNo = Reader["TinNo"].ToString());
                    SkipOnError(() => employee.RegistrationNo = Reader["RegistrationNo"].ToString());

                    SkipOnError(() => employee.PhysicalStrength = Reader["PhysicalStrength"].ToString());
                    SkipOnError(() => employee.Experience = Reader["Experience"].ToString());

                    employeeList.Add(employee);
                }
                Reader.Close();
                ConnectionClose();
                return employeeList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Employee List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        private void SkipOnError(Action action)
        {
            try
            {
                action();
            }
            catch
            {
            }
        }


        //*******************************************************//
    }

}

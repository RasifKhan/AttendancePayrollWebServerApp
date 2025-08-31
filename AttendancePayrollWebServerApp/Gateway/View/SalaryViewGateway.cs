using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.Pages.CategoryAndItems;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;




namespace AttendancePayrollWebServerApp.Gateway.View
{
    public class SalaryViewGateway  : Gateway
    {


        public async Task<Alert> Save(SalaryView salaryView, string existCondition = "")
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

                Query = "INSERT INTO SalaryView (Sn,SalStr,FromDate,ToDate,PayDate,EmployeeId,DepartmentId,DepartmentName,SectionId,SectionName,FloorCatItemId,Floor,LineCatItemId,Line,SalarySectionId,SalarySection,DesignationId,Designation,GradeCatItemId,Grade,EmployeeTypeCatItemId,Type,PaySource,ActiveYN,BankInfoId,AccNo,Holiday,WorkingDay,WeeklyHolidayMax,HolidayMax,Present,Absent,AbsentStr,AbsentNewJoin,AbsentNewJoinStr,AbsentRelease,AbsentReleaseStr,AbsentTotal,AbsentTotalStr,Late,LateHour,LateStr,TotalPresent,CL,SL,EL,ML,LeaveWithoutPay,OL,TotalLeave,LeaveStr,GrandTotalPresent,PayDays,PaySalary,OverTime,OverTimeAmount,ExtraOT,ExtraOTAmount,ExtraOTStr,AdditionalOverTime,AdditionalOTStr,DeductOT,DeductOTStr,TotalOT,OTRate,OTAmount,OTStr,TotalNight,NightRate,NightAllowance,AttendanceBonus,ProductionBonus,HolidayAllowance,HolidayAllowanceStr,MobileAllowance,TransAllowancePay,TransAllowancePayStr,OtherAllowance,OtherAllowanceStr,Arear,ArearStr,MaternityLeave,MaternityLeaveStr,TotalAmount,PayTotal,AbsentDeduct,AbsentDeductNewJoin,AbsentDeductRelease,AbsentDeductTotal,LateDeduct,LateDeductStr,LeaveDeduct,LeaveDeductStr,TransportDeduct,TransportDeductStr,OtherDeduct,OtherDeductStr,Tax,TaxStr,ProvidentFund,ProvidentFundStr,Lunch,LunchStr,Advance,AdvanceStr,Loan,LoanStr,MobbileDeduct,MobbileDeductStr,SecurityDeduct,SecurityDeductStr,Stamp,TotalDeduct,NetPay,NetPayStr,Cash,Bank,Paid,Due,Remarks,PaymentStatus,ELDays,ELAmount,LunchAddition,LunchDeduction,ServiceDuration,RoutingNumber,BankAccType,Tk1000,Tk500,Tk100,Tk50,Tk20,Tk10,Tk5,Tk2,Tk1,Devider,Reminder,InWord,InWordBangla,WHDPL,HDPL,OverTimeYN,GrossSalary,BasicSalary,HouseRent,FoodAllowance,TransportAllowance,MedicalAllowance,ExchangeRate,GrossSalaryUsd,SalaryPerDay,Increment,IncrementStr,MonthDays,WeeklyHoliday) VALUES(@sn,@salStr,@fromDate,@toDate,@payDate,@employeeId,@departmentId,@departmentName,@sectionId,@sectionName,@floorCatItemId,@floor,@lineCatItemId,@line,@salarySectionId,@salarySection,@designationId,@designation,@gradeCatItemId,@grade,@employeeTypeCatItemId,@type,@paySource,@activeYN,@bankInfoId,@accNo,@holiday,@workingDay,@weeklyHolidayMax,@holidayMax,@present,@absent,@absentStr,@absentNewJoin,@absentNewJoinStr,@absentRelease,@absentReleaseStr,@absentTotal,@absentTotalStr,@late,@lateHour,@lateStr,@totalPresent,@cL,@sL,@eL,@mL,@leaveWithoutPay,@oL,@totalLeave,@leaveStr,@grandTotalPresent,@payDays,@paySalary,@overTime,@overTimeAmount,@extraOT,@extraOTAmount,@extraOTStr,@additionalOverTime,@additionalOTStr,@deductOT,@deductOTStr,@totalOT,@oTRate,@oTAmount,@oTStr,@totalNight,@nightRate,@nightAllowance,@attendanceBonus,@productionBonus,@holidayAllowance,@holidayAllowanceStr,@mobileAllowance,@transAllowancePay,@transAllowancePayStr,@otherAllowance,@otherAllowanceStr,@arear,@arearStr,@maternityLeave,@maternityLeaveStr,@totalAmount,@payTotal,@absentDeduct,@absentDeductNewJoin,@absentDeductRelease,@absentDeductTotal,@lateDeduct,@lateDeductStr,@leaveDeduct,@leaveDeductStr,@transportDeduct,@transportDeductStr,@otherDeduct,@otherDeductStr,@tax,@taxStr,@providentFund,@providentFundStr,@lunch,@lunchStr,@advance,@advanceStr,@loan,@loanStr,@mobbileDeduct,@mobbileDeductStr,@securityDeduct,@securityDeductStr,@stamp,@totalDeduct,@netPay,@netPayStr,@cash,@bank,@paid,@due,@remarks,@paymentStatus,@eLDays,@eLAmount,@lunchAddition,@lunchDeduction,@serviceDuration,@routingNumber,@bankAccType,@tk1000,@tk500,@tk100,@tk50,@tk20,@tk10,@tk5,@tk2,@tk1,@devider,@reminder,@inWord,@inWordBangla,@wHDPL,@hDPL,@overTimeYN,@grossSalary,@basicSalary,@houseRent,@foodAllowance,@transportAllowance,@medicalAllowance,@exchangeRate,@grossSalaryUsd,@salaryPerDay,@increment,@incrementStr,@monthDays,@weeklyHoliday)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@salaryId", salaryView.SalaryId);
                Command.Parameters.AddWithValue("@sn", salaryView.Sn);
                Command.Parameters.AddWithValue("@salStr", salaryView.SalStr);
                Command.Parameters.AddWithValue("@fromDate", salaryView.FromDate);
                Command.Parameters.AddWithValue("@toDate", salaryView.ToDate);
                Command.Parameters.AddWithValue("@payDate", salaryView.PayDate);
                Command.Parameters.AddWithValue("@employeeId", salaryView.EmployeeId);
                Command.Parameters.AddWithValue("@departmentId", salaryView.DepartmentId);
                Command.Parameters.AddWithValue("@departmentName", salaryView.DepartmentName);
                Command.Parameters.AddWithValue("@sectionId", salaryView.SectionId);
                Command.Parameters.AddWithValue("@sectionName", salaryView.SectionName);
                Command.Parameters.AddWithValue("@floorCatItemId", salaryView.FloorCatItemId);
                Command.Parameters.AddWithValue("@floor", salaryView.Floor);
                Command.Parameters.AddWithValue("@lineCatItemId", salaryView.LineCatItemId);
                Command.Parameters.AddWithValue("@line", salaryView.Line);
                Command.Parameters.AddWithValue("@salarySectionId", salaryView.SalarySectionId);
                Command.Parameters.AddWithValue("@salarySection", salaryView.SalarySection);
                Command.Parameters.AddWithValue("@designationId", salaryView.DesignationId);
                Command.Parameters.AddWithValue("@designation", salaryView.Designation);
                Command.Parameters.AddWithValue("@gradeCatItemId", salaryView.GradeCatItemId);
                Command.Parameters.AddWithValue("@grade", salaryView.Grade);
                Command.Parameters.AddWithValue("@employeeTypeCatItemId", salaryView.EmployeeTypeCatItemId);
                Command.Parameters.AddWithValue("@type", salaryView.Type);
                Command.Parameters.AddWithValue("@paySource", salaryView.PaySource);
                Command.Parameters.AddWithValue("@activeYN", salaryView.ActiveYN);
                Command.Parameters.AddWithValue("@bankInfoId", salaryView.BankInfoId);
                Command.Parameters.AddWithValue("@accNo", salaryView.AccNo);
                Command.Parameters.AddWithValue("@holiday", salaryView.Holiday);
                Command.Parameters.AddWithValue("@workingDay", salaryView.WorkingDay);
                Command.Parameters.AddWithValue("@weeklyHolidayMax", salaryView.WeeklyHolidayMax);
                Command.Parameters.AddWithValue("@holidayMax", salaryView.HolidayMax);
                Command.Parameters.AddWithValue("@present", salaryView.Present);
                Command.Parameters.AddWithValue("@absent", salaryView.Absent);
                Command.Parameters.AddWithValue("@absentStr", salaryView.AbsentStr);
                Command.Parameters.AddWithValue("@absentNewJoin", salaryView.AbsentNewJoin);
                Command.Parameters.AddWithValue("@absentNewJoinStr", salaryView.AbsentNewJoinStr);
                Command.Parameters.AddWithValue("@absentRelease", salaryView.AbsentRelease);
                Command.Parameters.AddWithValue("@absentReleaseStr", salaryView.AbsentReleaseStr);
                Command.Parameters.AddWithValue("@absentTotal", salaryView.AbsentTotal);
                Command.Parameters.AddWithValue("@absentTotalStr", salaryView.AbsentTotalStr);
                Command.Parameters.AddWithValue("@late", salaryView.Late);
                Command.Parameters.AddWithValue("@lateHour", salaryView.LateHour);
                Command.Parameters.AddWithValue("@lateStr", salaryView.LateStr);
                Command.Parameters.AddWithValue("@totalPresent", salaryView.TotalPresent);
                Command.Parameters.AddWithValue("@cL", salaryView.CL);
                Command.Parameters.AddWithValue("@sL", salaryView.SL);
                Command.Parameters.AddWithValue("@eL", salaryView.EL);
                Command.Parameters.AddWithValue("@mL", salaryView.ML);
                Command.Parameters.AddWithValue("@leaveWithoutPay", salaryView.LeaveWithoutPay);
                Command.Parameters.AddWithValue("@oL", salaryView.OL);
                Command.Parameters.AddWithValue("@totalLeave", salaryView.TotalLeave);
                Command.Parameters.AddWithValue("@leaveStr", salaryView.LeaveStr);
                Command.Parameters.AddWithValue("@grandTotalPresent", salaryView.GrandTotalPresent);
                Command.Parameters.AddWithValue("@payDays", salaryView.PayDays);
                Command.Parameters.AddWithValue("@paySalary", salaryView.PaySalary);
                Command.Parameters.AddWithValue("@overTime", salaryView.OverTime);
                Command.Parameters.AddWithValue("@overTimeAmount", salaryView.OverTimeAmount);
                Command.Parameters.AddWithValue("@extraOT", salaryView.ExtraOT);
                Command.Parameters.AddWithValue("@extraOTAmount", salaryView.ExtraOTAmount);
                Command.Parameters.AddWithValue("@extraOTStr", salaryView.ExtraOTStr);
                Command.Parameters.AddWithValue("@additionalOverTime", salaryView.AdditionalOverTime);
                Command.Parameters.AddWithValue("@additionalOTStr", salaryView.AdditionalOTStr);
                Command.Parameters.AddWithValue("@deductOT", salaryView.DeductOT);
                Command.Parameters.AddWithValue("@deductOTStr", salaryView.DeductOTStr);
                Command.Parameters.AddWithValue("@totalOT", salaryView.TotalOT);
                Command.Parameters.AddWithValue("@oTRate", salaryView.OTRate);
                Command.Parameters.AddWithValue("@oTAmount", salaryView.OTAmount);
                Command.Parameters.AddWithValue("@oTStr", salaryView.OTStr);
                Command.Parameters.AddWithValue("@totalNight", salaryView.TotalNight);
                Command.Parameters.AddWithValue("@nightRate", salaryView.NightRate);
                Command.Parameters.AddWithValue("@nightAllowance", salaryView.NightAllowance);
                Command.Parameters.AddWithValue("@attendanceBonus", salaryView.AttendanceBonus);
                Command.Parameters.AddWithValue("@productionBonus", salaryView.ProductionBonus);
                Command.Parameters.AddWithValue("@holidayAllowance", salaryView.HolidayAllowance);
                Command.Parameters.AddWithValue("@holidayAllowanceStr", salaryView.HolidayAllowanceStr);
                Command.Parameters.AddWithValue("@mobileAllowance", salaryView.MobileAllowance);
                Command.Parameters.AddWithValue("@transAllowancePay", salaryView.TransAllowancePay);
                Command.Parameters.AddWithValue("@transAllowancePayStr", salaryView.TransAllowancePayStr);
                Command.Parameters.AddWithValue("@otherAllowance", salaryView.OtherAllowance);
                Command.Parameters.AddWithValue("@otherAllowanceStr", salaryView.OtherAllowanceStr);
                Command.Parameters.AddWithValue("@arear", salaryView.Arear);
                Command.Parameters.AddWithValue("@arearStr", salaryView.ArearStr);
                Command.Parameters.AddWithValue("@maternityLeave", salaryView.MaternityLeave);
                Command.Parameters.AddWithValue("@maternityLeaveStr", salaryView.MaternityLeaveStr);
                Command.Parameters.AddWithValue("@totalAmount", salaryView.TotalAmount);
                Command.Parameters.AddWithValue("@payTotal", salaryView.PayTotal);
                Command.Parameters.AddWithValue("@absentDeduct", salaryView.AbsentDeduct);
                Command.Parameters.AddWithValue("@absentDeductNewJoin", salaryView.AbsentDeductNewJoin);
                Command.Parameters.AddWithValue("@absentDeductRelease", salaryView.AbsentDeductRelease);
                Command.Parameters.AddWithValue("@absentDeductTotal", salaryView.AbsentDeductTotal);
                Command.Parameters.AddWithValue("@lateDeduct", salaryView.LateDeduct);
                Command.Parameters.AddWithValue("@lateDeductStr", salaryView.LateDeductStr);
                Command.Parameters.AddWithValue("@leaveDeduct", salaryView.LeaveDeduct);
                Command.Parameters.AddWithValue("@leaveDeductStr", salaryView.LeaveDeductStr);
                Command.Parameters.AddWithValue("@transportDeduct", salaryView.TransportDeduct);
                Command.Parameters.AddWithValue("@transportDeductStr", salaryView.TransportDeductStr);
                Command.Parameters.AddWithValue("@otherDeduct", salaryView.OtherDeduct);
                Command.Parameters.AddWithValue("@otherDeductStr", salaryView.OtherDeductStr);
                Command.Parameters.AddWithValue("@tax", salaryView.Tax);
                Command.Parameters.AddWithValue("@taxStr", salaryView.TaxStr);
                Command.Parameters.AddWithValue("@providentFund", salaryView.ProvidentFund);
                Command.Parameters.AddWithValue("@providentFundStr", salaryView.ProvidentFundStr);
                Command.Parameters.AddWithValue("@lunch", salaryView.Lunch);
                Command.Parameters.AddWithValue("@lunchStr", salaryView.LunchStr);
                Command.Parameters.AddWithValue("@advance", salaryView.Advance);
                Command.Parameters.AddWithValue("@advanceStr", salaryView.AdvanceStr);
                Command.Parameters.AddWithValue("@loan", salaryView.Loan);
                Command.Parameters.AddWithValue("@loanStr", salaryView.LoanStr);
                Command.Parameters.AddWithValue("@mobbileDeduct", salaryView.MobbileDeduct);
                Command.Parameters.AddWithValue("@mobbileDeductStr", salaryView.MobbileDeductStr);
                Command.Parameters.AddWithValue("@securityDeduct", salaryView.SecurityDeduct);
                Command.Parameters.AddWithValue("@securityDeductStr", salaryView.SecurityDeductStr);
                Command.Parameters.AddWithValue("@stamp", salaryView.Stamp);
                Command.Parameters.AddWithValue("@totalDeduct", salaryView.TotalDeduct);
                Command.Parameters.AddWithValue("@netPay", salaryView.NetPay);
                Command.Parameters.AddWithValue("@netPayStr", salaryView.NetPayStr);
                Command.Parameters.AddWithValue("@cash", salaryView.Cash);
                Command.Parameters.AddWithValue("@bank", salaryView.Bank);
                Command.Parameters.AddWithValue("@paid", salaryView.Paid);
                Command.Parameters.AddWithValue("@due", salaryView.Due);
                Command.Parameters.AddWithValue("@remarks", salaryView.Remarks);
                Command.Parameters.AddWithValue("@paymentStatus", salaryView.PaymentStatus);
                Command.Parameters.AddWithValue("@eLDays", salaryView.ELDays);
                Command.Parameters.AddWithValue("@eLAmount", salaryView.ELAmount);
                Command.Parameters.AddWithValue("@lunchAddition", salaryView.LunchAddition);
                Command.Parameters.AddWithValue("@lunchDeduction", salaryView.LunchDeduction);
                Command.Parameters.AddWithValue("@serviceDuration", salaryView.ServiceDuration);
                Command.Parameters.AddWithValue("@routingNumber", salaryView.RoutingNumber);
                Command.Parameters.AddWithValue("@bankAccType", salaryView.BankAccType);
                Command.Parameters.AddWithValue("@tk1000", salaryView.Tk1000);
                Command.Parameters.AddWithValue("@tk500", salaryView.Tk500);
                Command.Parameters.AddWithValue("@tk100", salaryView.Tk100);
                Command.Parameters.AddWithValue("@tk50", salaryView.Tk50);
                Command.Parameters.AddWithValue("@tk20", salaryView.Tk20);
                Command.Parameters.AddWithValue("@tk10", salaryView.Tk10);
                Command.Parameters.AddWithValue("@tk5", salaryView.Tk5);
                Command.Parameters.AddWithValue("@tk2", salaryView.Tk2);
                Command.Parameters.AddWithValue("@tk1", salaryView.Tk1);
                Command.Parameters.AddWithValue("@devider", salaryView.Devider);
                Command.Parameters.AddWithValue("@reminder", salaryView.Reminder);
                Command.Parameters.AddWithValue("@inWord", salaryView.InWord);
                Command.Parameters.AddWithValue("@inWordBangla", salaryView.InWordBangla);
                Command.Parameters.AddWithValue("@wHDPL", salaryView.WHDPL);
                Command.Parameters.AddWithValue("@hDPL", salaryView.HDPL);
                Command.Parameters.AddWithValue("@overTimeYN", salaryView.OverTimeYN);
                Command.Parameters.AddWithValue("@grossSalary", salaryView.GrossSalary);
                Command.Parameters.AddWithValue("@basicSalary", salaryView.BasicSalary);
                Command.Parameters.AddWithValue("@houseRent", salaryView.HouseRent);
                Command.Parameters.AddWithValue("@foodAllowance", salaryView.FoodAllowance);
                Command.Parameters.AddWithValue("@transportAllowance", salaryView.TransportAllowance);
                Command.Parameters.AddWithValue("@medicalAllowance", salaryView.MedicalAllowance);
                Command.Parameters.AddWithValue("@exchangeRate", salaryView.ExchangeRate);
                Command.Parameters.AddWithValue("@grossSalaryUsd", salaryView.GrossSalaryUsd);
                Command.Parameters.AddWithValue("@salaryPerDay", salaryView.SalaryPerDay);
                Command.Parameters.AddWithValue("@increment", salaryView.Increment);
                Command.Parameters.AddWithValue("@incrementStr", salaryView.IncrementStr);
                Command.Parameters.AddWithValue("@monthDays", salaryView.MonthDays);
                Command.Parameters.AddWithValue("@weeklyHoliday", salaryView.WeeklyHoliday);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Saved");
                }
                return new Alert("warning", "Not Saved");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Save\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Alert> Edit(SalaryView salaryView, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE SalaryView SET Sn=@sn,SalStr=@salStr,FromDate=@fromDate,ToDate=@toDate,PayDate=@payDate,EmployeeId=@employeeId,DepartmentId=@departmentId,DepartmentName=@departmentName,SectionId=@sectionId,SectionName=@sectionName,FloorCatItemId=@floorCatItemId,Floor=@floor,LineCatItemId=@lineCatItemId,Line=@line,SalarySectionId=@salarySectionId,SalarySection=@salarySection,DesignationId=@designationId,Designation=@designation,GradeCatItemId=@gradeCatItemId,Grade=@grade,EmployeeTypeCatItemId=@employeeTypeCatItemId,Type=@type,PaySource=@paySource,ActiveYN=@activeYN,BankInfoId=@bankInfoId,AccNo=@accNo,Holiday=@holiday,WorkingDay=@workingDay,WeeklyHolidayMax=@weeklyHolidayMax,HolidayMax=@holidayMax,Present=@present,Absent=@absent,AbsentStr=@absentStr,AbsentNewJoin=@absentNewJoin,AbsentNewJoinStr=@absentNewJoinStr,AbsentRelease=@absentRelease,AbsentReleaseStr=@absentReleaseStr,AbsentTotal=@absentTotal,AbsentTotalStr=@absentTotalStr,Late=@late,LateHour=@lateHour,LateStr=@lateStr,TotalPresent=@totalPresent,CL=@cL,SL=@sL,EL=@eL,ML=@mL,LeaveWithoutPay=@leaveWithoutPay,OL=@oL,TotalLeave=@totalLeave,LeaveStr=@leaveStr,GrandTotalPresent=@grandTotalPresent,PayDays=@payDays,PaySalary=@paySalary,OverTime=@overTime,OverTimeAmount=@overTimeAmount,ExtraOT=@extraOT,ExtraOTAmount=@extraOTAmount,ExtraOTStr=@extraOTStr,AdditionalOverTime=@additionalOverTime,AdditionalOTStr=@additionalOTStr,DeductOT=@deductOT,DeductOTStr=@deductOTStr,TotalOT=@totalOT,OTRate=@oTRate,OTAmount=@oTAmount,OTStr=@oTStr,TotalNight=@totalNight,NightRate=@nightRate,NightAllowance=@nightAllowance,AttendanceBonus=@attendanceBonus,ProductionBonus=@productionBonus,HolidayAllowance=@holidayAllowance,HolidayAllowanceStr=@holidayAllowanceStr,MobileAllowance=@mobileAllowance,TransAllowancePay=@transAllowancePay,TransAllowancePayStr=@transAllowancePayStr,OtherAllowance=@otherAllowance,OtherAllowanceStr=@otherAllowanceStr,Arear=@arear,ArearStr=@arearStr,MaternityLeave=@maternityLeave,MaternityLeaveStr=@maternityLeaveStr,TotalAmount=@totalAmount,PayTotal=@payTotal,AbsentDeduct=@absentDeduct,AbsentDeductNewJoin=@absentDeductNewJoin,AbsentDeductRelease=@absentDeductRelease,AbsentDeductTotal=@absentDeductTotal,LateDeduct=@lateDeduct,LateDeductStr=@lateDeductStr,LeaveDeduct=@leaveDeduct,LeaveDeductStr=@leaveDeductStr,TransportDeduct=@transportDeduct,TransportDeductStr=@transportDeductStr,OtherDeduct=@otherDeduct,OtherDeductStr=@otherDeductStr,Tax=@tax,TaxStr=@taxStr,ProvidentFund=@providentFund,ProvidentFundStr=@providentFundStr,Lunch=@lunch,LunchStr=@lunchStr,Advance=@advance,AdvanceStr=@advanceStr,Loan=@loan,LoanStr=@loanStr,MobbileDeduct=@mobbileDeduct,MobbileDeductStr=@mobbileDeductStr,SecurityDeduct=@securityDeduct,SecurityDeductStr=@securityDeductStr,Stamp=@stamp,TotalDeduct=@totalDeduct,NetPay=@netPay,NetPayStr=@netPayStr,Cash=@cash,Bank=@bank,Paid=@paid,Due=@due,Remarks=@remarks,PaymentStatus=@paymentStatus,ELDays=@eLDays,ELAmount=@eLAmount,LunchAddition=@lunchAddition,LunchDeduction=@lunchDeduction,ServiceDuration=@serviceDuration,RoutingNumber=@routingNumber,BankAccType=@bankAccType,Tk1000=@tk1000,Tk500=@tk500,Tk100=@tk100,Tk50=@tk50,Tk20=@tk20,Tk10=@tk10,Tk5=@tk5,Tk2=@tk2,Tk1=@tk1,Devider=@devider,Reminder=@reminder,InWord=@inWord,InWordBangla=@inWordBangla,WHDPL=@wHDPL,HDPL=@hDPL,OverTimeYN=@overTimeYN,GrossSalary=@grossSalary,BasicSalary=@basicSalary,HouseRent=@houseRent,FoodAllowance=@foodAllowance,TransportAllowance=@transportAllowance,MedicalAllowance=@medicalAllowance,ExchangeRate=@exchangeRate,GrossSalaryUsd=@grossSalaryUsd,SalaryPerDay=@salaryPerDay,Increment=@increment,IncrementStr=@incrementStr,MonthDays=@monthDays,WeeklyHoliday=@weeklyHoliday WHERE SalaryId = @salaryId";
                }
                else
                {
                    Query = "UPDATE SalaryView SET Sn=@sn,SalStr=@salStr,FromDate=@fromDate,ToDate=@toDate,PayDate=@payDate,EmployeeId=@employeeId,DepartmentId=@departmentId,DepartmentName=@departmentName,SectionId=@sectionId,SectionName=@sectionName,FloorCatItemId=@floorCatItemId,Floor=@floor,LineCatItemId=@lineCatItemId,Line=@line,SalarySectionId=@salarySectionId,SalarySection=@salarySection,DesignationId=@designationId,Designation=@designation,GradeCatItemId=@gradeCatItemId,Grade=@grade,EmployeeTypeCatItemId=@employeeTypeCatItemId,Type=@type,PaySource=@paySource,ActiveYN=@activeYN,BankInfoId=@bankInfoId,AccNo=@accNo,Holiday=@holiday,WorkingDay=@workingDay,WeeklyHolidayMax=@weeklyHolidayMax,HolidayMax=@holidayMax,Present=@present,Absent=@absent,AbsentStr=@absentStr,AbsentNewJoin=@absentNewJoin,AbsentNewJoinStr=@absentNewJoinStr,AbsentRelease=@absentRelease,AbsentReleaseStr=@absentReleaseStr,AbsentTotal=@absentTotal,AbsentTotalStr=@absentTotalStr,Late=@late,LateHour=@lateHour,LateStr=@lateStr,TotalPresent=@totalPresent,CL=@cL,SL=@sL,EL=@eL,ML=@mL,LeaveWithoutPay=@leaveWithoutPay,OL=@oL,TotalLeave=@totalLeave,LeaveStr=@leaveStr,GrandTotalPresent=@grandTotalPresent,PayDays=@payDays,PaySalary=@paySalary,OverTime=@overTime,OverTimeAmount=@overTimeAmount,ExtraOT=@extraOT,ExtraOTAmount=@extraOTAmount,ExtraOTStr=@extraOTStr,AdditionalOverTime=@additionalOverTime,AdditionalOTStr=@additionalOTStr,DeductOT=@deductOT,DeductOTStr=@deductOTStr,TotalOT=@totalOT,OTRate=@oTRate,OTAmount=@oTAmount,OTStr=@oTStr,TotalNight=@totalNight,NightRate=@nightRate,NightAllowance=@nightAllowance,AttendanceBonus=@attendanceBonus,ProductionBonus=@productionBonus,HolidayAllowance=@holidayAllowance,HolidayAllowanceStr=@holidayAllowanceStr,MobileAllowance=@mobileAllowance,TransAllowancePay=@transAllowancePay,TransAllowancePayStr=@transAllowancePayStr,OtherAllowance=@otherAllowance,OtherAllowanceStr=@otherAllowanceStr,Arear=@arear,ArearStr=@arearStr,MaternityLeave=@maternityLeave,MaternityLeaveStr=@maternityLeaveStr,TotalAmount=@totalAmount,PayTotal=@payTotal,AbsentDeduct=@absentDeduct,AbsentDeductNewJoin=@absentDeductNewJoin,AbsentDeductRelease=@absentDeductRelease,AbsentDeductTotal=@absentDeductTotal,LateDeduct=@lateDeduct,LateDeductStr=@lateDeductStr,LeaveDeduct=@leaveDeduct,LeaveDeductStr=@leaveDeductStr,TransportDeduct=@transportDeduct,TransportDeductStr=@transportDeductStr,OtherDeduct=@otherDeduct,OtherDeductStr=@otherDeductStr,Tax=@tax,TaxStr=@taxStr,ProvidentFund=@providentFund,ProvidentFundStr=@providentFundStr,Lunch=@lunch,LunchStr=@lunchStr,Advance=@advance,AdvanceStr=@advanceStr,Loan=@loan,LoanStr=@loanStr,MobbileDeduct=@mobbileDeduct,MobbileDeductStr=@mobbileDeductStr,SecurityDeduct=@securityDeduct,SecurityDeductStr=@securityDeductStr,Stamp=@stamp,TotalDeduct=@totalDeduct,NetPay=@netPay,NetPayStr=@netPayStr,Cash=@cash,Bank=@bank,Paid=@paid,Due=@due,Remarks=@remarks,PaymentStatus=@paymentStatus,ELDays=@eLDays,ELAmount=@eLAmount,LunchAddition=@lunchAddition,LunchDeduction=@lunchDeduction,ServiceDuration=@serviceDuration,RoutingNumber=@routingNumber,BankAccType=@bankAccType,Tk1000=@tk1000,Tk500=@tk500,Tk100=@tk100,Tk50=@tk50,Tk20=@tk20,Tk10=@tk10,Tk5=@tk5,Tk2=@tk2,Tk1=@tk1,Devider=@devider,Reminder=@reminder,InWord=@inWord,InWordBangla=@inWordBangla,WHDPL=@wHDPL,HDPL=@hDPL,OverTimeYN=@overTimeYN,GrossSalary=@grossSalary,BasicSalary=@basicSalary,HouseRent=@houseRent,FoodAllowance=@foodAllowance,TransportAllowance=@transportAllowance,MedicalAllowance=@medicalAllowance,ExchangeRate=@exchangeRate,GrossSalaryUsd=@grossSalaryUsd,SalaryPerDay=@salaryPerDay,Increment=@increment,IncrementStr=@incrementStr,MonthDays=@monthDays,WeeklyHoliday=@weeklyHoliday WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@salaryId", salaryView.SalaryId);
                Command.Parameters.AddWithValue("@sn", salaryView.Sn);
                Command.Parameters.AddWithValue("@salStr", salaryView.SalStr);
                Command.Parameters.AddWithValue("@fromDate", salaryView.FromDate);
                Command.Parameters.AddWithValue("@toDate", salaryView.ToDate);
                Command.Parameters.AddWithValue("@payDate", salaryView.PayDate);
                Command.Parameters.AddWithValue("@employeeId", salaryView.EmployeeId);
                Command.Parameters.AddWithValue("@departmentId", salaryView.DepartmentId);
                Command.Parameters.AddWithValue("@departmentName", salaryView.DepartmentName);
                Command.Parameters.AddWithValue("@sectionId", salaryView.SectionId);
                Command.Parameters.AddWithValue("@sectionName", salaryView.SectionName);
                Command.Parameters.AddWithValue("@floorCatItemId", salaryView.FloorCatItemId);
                Command.Parameters.AddWithValue("@floor", salaryView.Floor);
                Command.Parameters.AddWithValue("@lineCatItemId", salaryView.LineCatItemId);
                Command.Parameters.AddWithValue("@line", salaryView.Line);
                Command.Parameters.AddWithValue("@salarySectionId", salaryView.SalarySectionId);
                Command.Parameters.AddWithValue("@salarySection", salaryView.SalarySection);
                Command.Parameters.AddWithValue("@designationId", salaryView.DesignationId);
                Command.Parameters.AddWithValue("@designation", salaryView.Designation);
                Command.Parameters.AddWithValue("@gradeCatItemId", salaryView.GradeCatItemId);
                Command.Parameters.AddWithValue("@grade", salaryView.Grade);
                Command.Parameters.AddWithValue("@employeeTypeCatItemId", salaryView.EmployeeTypeCatItemId);
                Command.Parameters.AddWithValue("@type", salaryView.Type);
                Command.Parameters.AddWithValue("@paySource", salaryView.PaySource);
                Command.Parameters.AddWithValue("@activeYN", salaryView.ActiveYN);
                Command.Parameters.AddWithValue("@bankInfoId", salaryView.BankInfoId);
                Command.Parameters.AddWithValue("@accNo", salaryView.AccNo);
                Command.Parameters.AddWithValue("@holiday", salaryView.Holiday);
                Command.Parameters.AddWithValue("@workingDay", salaryView.WorkingDay);
                Command.Parameters.AddWithValue("@weeklyHolidayMax", salaryView.WeeklyHolidayMax);
                Command.Parameters.AddWithValue("@holidayMax", salaryView.HolidayMax);
                Command.Parameters.AddWithValue("@present", salaryView.Present);
                Command.Parameters.AddWithValue("@absent", salaryView.Absent);
                Command.Parameters.AddWithValue("@absentStr", salaryView.AbsentStr);
                Command.Parameters.AddWithValue("@absentNewJoin", salaryView.AbsentNewJoin);
                Command.Parameters.AddWithValue("@absentNewJoinStr", salaryView.AbsentNewJoinStr);
                Command.Parameters.AddWithValue("@absentRelease", salaryView.AbsentRelease);
                Command.Parameters.AddWithValue("@absentReleaseStr", salaryView.AbsentReleaseStr);
                Command.Parameters.AddWithValue("@absentTotal", salaryView.AbsentTotal);
                Command.Parameters.AddWithValue("@absentTotalStr", salaryView.AbsentTotalStr);
                Command.Parameters.AddWithValue("@late", salaryView.Late);
                Command.Parameters.AddWithValue("@lateHour", salaryView.LateHour);
                Command.Parameters.AddWithValue("@lateStr", salaryView.LateStr);
                Command.Parameters.AddWithValue("@totalPresent", salaryView.TotalPresent);
                Command.Parameters.AddWithValue("@cL", salaryView.CL);
                Command.Parameters.AddWithValue("@sL", salaryView.SL);
                Command.Parameters.AddWithValue("@eL", salaryView.EL);
                Command.Parameters.AddWithValue("@mL", salaryView.ML);
                Command.Parameters.AddWithValue("@leaveWithoutPay", salaryView.LeaveWithoutPay);
                Command.Parameters.AddWithValue("@oL", salaryView.OL);
                Command.Parameters.AddWithValue("@totalLeave", salaryView.TotalLeave);
                Command.Parameters.AddWithValue("@leaveStr", salaryView.LeaveStr);
                Command.Parameters.AddWithValue("@grandTotalPresent", salaryView.GrandTotalPresent);
                Command.Parameters.AddWithValue("@payDays", salaryView.PayDays);
                Command.Parameters.AddWithValue("@paySalary", salaryView.PaySalary);
                Command.Parameters.AddWithValue("@overTime", salaryView.OverTime);
                Command.Parameters.AddWithValue("@overTimeAmount", salaryView.OverTimeAmount);
                Command.Parameters.AddWithValue("@extraOT", salaryView.ExtraOT);
                Command.Parameters.AddWithValue("@extraOTAmount", salaryView.ExtraOTAmount);
                Command.Parameters.AddWithValue("@extraOTStr", salaryView.ExtraOTStr);
                Command.Parameters.AddWithValue("@additionalOverTime", salaryView.AdditionalOverTime);
                Command.Parameters.AddWithValue("@additionalOTStr", salaryView.AdditionalOTStr);
                Command.Parameters.AddWithValue("@deductOT", salaryView.DeductOT);
                Command.Parameters.AddWithValue("@deductOTStr", salaryView.DeductOTStr);
                Command.Parameters.AddWithValue("@totalOT", salaryView.TotalOT);
                Command.Parameters.AddWithValue("@oTRate", salaryView.OTRate);
                Command.Parameters.AddWithValue("@oTAmount", salaryView.OTAmount);
                Command.Parameters.AddWithValue("@oTStr", salaryView.OTStr);
                Command.Parameters.AddWithValue("@totalNight", salaryView.TotalNight);
                Command.Parameters.AddWithValue("@nightRate", salaryView.NightRate);
                Command.Parameters.AddWithValue("@nightAllowance", salaryView.NightAllowance);
                Command.Parameters.AddWithValue("@attendanceBonus", salaryView.AttendanceBonus);
                Command.Parameters.AddWithValue("@productionBonus", salaryView.ProductionBonus);
                Command.Parameters.AddWithValue("@holidayAllowance", salaryView.HolidayAllowance);
                Command.Parameters.AddWithValue("@holidayAllowanceStr", salaryView.HolidayAllowanceStr);
                Command.Parameters.AddWithValue("@mobileAllowance", salaryView.MobileAllowance);
                Command.Parameters.AddWithValue("@transAllowancePay", salaryView.TransAllowancePay);
                Command.Parameters.AddWithValue("@transAllowancePayStr", salaryView.TransAllowancePayStr);
                Command.Parameters.AddWithValue("@otherAllowance", salaryView.OtherAllowance);
                Command.Parameters.AddWithValue("@otherAllowanceStr", salaryView.OtherAllowanceStr);
                Command.Parameters.AddWithValue("@arear", salaryView.Arear);
                Command.Parameters.AddWithValue("@arearStr", salaryView.ArearStr);
                Command.Parameters.AddWithValue("@maternityLeave", salaryView.MaternityLeave);
                Command.Parameters.AddWithValue("@maternityLeaveStr", salaryView.MaternityLeaveStr);
                Command.Parameters.AddWithValue("@totalAmount", salaryView.TotalAmount);
                Command.Parameters.AddWithValue("@payTotal", salaryView.PayTotal);
                Command.Parameters.AddWithValue("@absentDeduct", salaryView.AbsentDeduct);
                Command.Parameters.AddWithValue("@absentDeductNewJoin", salaryView.AbsentDeductNewJoin);
                Command.Parameters.AddWithValue("@absentDeductRelease", salaryView.AbsentDeductRelease);
                Command.Parameters.AddWithValue("@absentDeductTotal", salaryView.AbsentDeductTotal);
                Command.Parameters.AddWithValue("@lateDeduct", salaryView.LateDeduct);
                Command.Parameters.AddWithValue("@lateDeductStr", salaryView.LateDeductStr);
                Command.Parameters.AddWithValue("@leaveDeduct", salaryView.LeaveDeduct);
                Command.Parameters.AddWithValue("@leaveDeductStr", salaryView.LeaveDeductStr);
                Command.Parameters.AddWithValue("@transportDeduct", salaryView.TransportDeduct);
                Command.Parameters.AddWithValue("@transportDeductStr", salaryView.TransportDeductStr);
                Command.Parameters.AddWithValue("@otherDeduct", salaryView.OtherDeduct);
                Command.Parameters.AddWithValue("@otherDeductStr", salaryView.OtherDeductStr);
                Command.Parameters.AddWithValue("@tax", salaryView.Tax);
                Command.Parameters.AddWithValue("@taxStr", salaryView.TaxStr);
                Command.Parameters.AddWithValue("@providentFund", salaryView.ProvidentFund);
                Command.Parameters.AddWithValue("@providentFundStr", salaryView.ProvidentFundStr);
                Command.Parameters.AddWithValue("@lunch", salaryView.Lunch);
                Command.Parameters.AddWithValue("@lunchStr", salaryView.LunchStr);
                Command.Parameters.AddWithValue("@advance", salaryView.Advance);
                Command.Parameters.AddWithValue("@advanceStr", salaryView.AdvanceStr);
                Command.Parameters.AddWithValue("@loan", salaryView.Loan);
                Command.Parameters.AddWithValue("@loanStr", salaryView.LoanStr);
                Command.Parameters.AddWithValue("@mobbileDeduct", salaryView.MobbileDeduct);
                Command.Parameters.AddWithValue("@mobbileDeductStr", salaryView.MobbileDeductStr);
                Command.Parameters.AddWithValue("@securityDeduct", salaryView.SecurityDeduct);
                Command.Parameters.AddWithValue("@securityDeductStr", salaryView.SecurityDeductStr);
                Command.Parameters.AddWithValue("@stamp", salaryView.Stamp);
                Command.Parameters.AddWithValue("@totalDeduct", salaryView.TotalDeduct);
                Command.Parameters.AddWithValue("@netPay", salaryView.NetPay);
                Command.Parameters.AddWithValue("@netPayStr", salaryView.NetPayStr);
                Command.Parameters.AddWithValue("@cash", salaryView.Cash);
                Command.Parameters.AddWithValue("@bank", salaryView.Bank);
                Command.Parameters.AddWithValue("@paid", salaryView.Paid);
                Command.Parameters.AddWithValue("@due", salaryView.Due);
                Command.Parameters.AddWithValue("@remarks", salaryView.Remarks);
                Command.Parameters.AddWithValue("@paymentStatus", salaryView.PaymentStatus);
                Command.Parameters.AddWithValue("@eLDays", salaryView.ELDays);
                Command.Parameters.AddWithValue("@eLAmount", salaryView.ELAmount);
                Command.Parameters.AddWithValue("@lunchAddition", salaryView.LunchAddition);
                Command.Parameters.AddWithValue("@lunchDeduction", salaryView.LunchDeduction);
                Command.Parameters.AddWithValue("@serviceDuration", salaryView.ServiceDuration);
                Command.Parameters.AddWithValue("@routingNumber", salaryView.RoutingNumber);
                Command.Parameters.AddWithValue("@bankAccType", salaryView.BankAccType);
                Command.Parameters.AddWithValue("@tk1000", salaryView.Tk1000);
                Command.Parameters.AddWithValue("@tk500", salaryView.Tk500);
                Command.Parameters.AddWithValue("@tk100", salaryView.Tk100);
                Command.Parameters.AddWithValue("@tk50", salaryView.Tk50);
                Command.Parameters.AddWithValue("@tk20", salaryView.Tk20);
                Command.Parameters.AddWithValue("@tk10", salaryView.Tk10);
                Command.Parameters.AddWithValue("@tk5", salaryView.Tk5);
                Command.Parameters.AddWithValue("@tk2", salaryView.Tk2);
                Command.Parameters.AddWithValue("@tk1", salaryView.Tk1);
                Command.Parameters.AddWithValue("@devider", salaryView.Devider);
                Command.Parameters.AddWithValue("@reminder", salaryView.Reminder);
                Command.Parameters.AddWithValue("@inWord", salaryView.InWord);
                Command.Parameters.AddWithValue("@inWordBangla", salaryView.InWordBangla);
                Command.Parameters.AddWithValue("@wHDPL", salaryView.WHDPL);
                Command.Parameters.AddWithValue("@hDPL", salaryView.HDPL);
                Command.Parameters.AddWithValue("@overTimeYN", salaryView.OverTimeYN);
                Command.Parameters.AddWithValue("@grossSalary", salaryView.GrossSalary);
                Command.Parameters.AddWithValue("@basicSalary", salaryView.BasicSalary);
                Command.Parameters.AddWithValue("@houseRent", salaryView.HouseRent);
                Command.Parameters.AddWithValue("@foodAllowance", salaryView.FoodAllowance);
                Command.Parameters.AddWithValue("@transportAllowance", salaryView.TransportAllowance);
                Command.Parameters.AddWithValue("@medicalAllowance", salaryView.MedicalAllowance);
                Command.Parameters.AddWithValue("@exchangeRate", salaryView.ExchangeRate);
                Command.Parameters.AddWithValue("@grossSalaryUsd", salaryView.GrossSalaryUsd);
                Command.Parameters.AddWithValue("@salaryPerDay", salaryView.SalaryPerDay);
                Command.Parameters.AddWithValue("@increment", salaryView.Increment);
                Command.Parameters.AddWithValue("@incrementStr", salaryView.IncrementStr);
                Command.Parameters.AddWithValue("@monthDays", salaryView.MonthDays);
                Command.Parameters.AddWithValue("@weeklyHoliday", salaryView.WeeklyHoliday);

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

        public async Task<Alert> Delete(int salaryId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE SalaryView WHERE SalaryId = @salaryId";
                }
                else
                {
                    Query = "DELETE SalaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@salaryId", salaryId);

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

        public async Task<bool> IsExist(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT 1 FROM SalaryView";
                }
                else
                {
                    Query = "SELECT 1 FROM SalaryView WHERE " + condition;
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

        public async Task<SalaryView> GetSalaryView(int salaryId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM SalaryView WHERE SalaryId = @salaryId";
                }
                else
                {
                    Query = "SELECT * FROM SalaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@salaryId", salaryId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                SalaryView salaryView = new SalaryView();
                while (Reader.Read())
                {
                    salaryView.SalaryId = (int)Reader["SalaryId"];
                    salaryView.Sn = (decimal)Reader["Sn"];
                    salaryView.SalStr = Reader["SalStr"].ToString();
                    salaryView.FromDate = (DateTime)Reader["FromDate"];
                    salaryView.ToDate = (DateTime)Reader["ToDate"];
                    salaryView.PayDate = (DateTime)Reader["PayDate"];
                    salaryView.EmployeeId = Reader["EmployeeId"].ToString();
                    salaryView.DepartmentId = (int)Reader["DepartmentId"];
                    salaryView.DepartmentName = Reader["DepartmentName"].ToString();
                    salaryView.SectionId = (int)Reader["SectionId"];
                    salaryView.SectionName = Reader["SectionName"].ToString();
                    salaryView.FloorCatItemId = (int)Reader["FloorCatItemId"];
                    salaryView.Floor = Reader["Floor"].ToString();
                    salaryView.LineCatItemId = (int)Reader["LineCatItemId"];
                    salaryView.Line = Reader["Line"].ToString();
                    salaryView.SalarySectionId = (int)Reader["SalarySectionId"];
                    salaryView.SalarySection = Reader["SalarySection"].ToString();
                    salaryView.DesignationId = (int)Reader["DesignationId"];
                    salaryView.Designation = Reader["Designation"].ToString();
                    salaryView.GradeCatItemId = (int)Reader["GradeCatItemId"];
                    salaryView.Grade = Reader["Grade"].ToString();
                    salaryView.EmployeeTypeCatItemId = (int)Reader["EmployeeTypeCatItemId"];
                    salaryView.Type = Reader["Type"].ToString();
                    salaryView.PaySource = Reader["PaySource"].ToString();
                    salaryView.ActiveYN = Reader["ActiveYN"].ToString();
                    salaryView.BankInfoId = (int)Reader["BankInfoId"];
                    salaryView.AccNo = Reader["AccNo"].ToString();
                    salaryView.Holiday = (decimal)Reader["Holiday"];
                    salaryView.WorkingDay = (decimal)Reader["WorkingDay"];
                    salaryView.WeeklyHolidayMax = (decimal)Reader["WeeklyHolidayMax"];
                    salaryView.HolidayMax = (decimal)Reader["HolidayMax"];
                    salaryView.Present = (decimal)Reader["Present"];
                    salaryView.Absent = (decimal)Reader["Absent"];
                    salaryView.AbsentStr = Reader["AbsentStr"].ToString();
                    salaryView.AbsentNewJoin = (decimal)Reader["AbsentNewJoin"];
                    salaryView.AbsentNewJoinStr = Reader["AbsentNewJoinStr"].ToString();
                    salaryView.AbsentRelease = (decimal)Reader["AbsentRelease"];
                    salaryView.AbsentReleaseStr = Reader["AbsentReleaseStr"].ToString();
                    salaryView.AbsentTotal = (decimal)Reader["AbsentTotal"];
                    salaryView.AbsentTotalStr = Reader["AbsentTotalStr"].ToString();
                    salaryView.Late = (decimal)Reader["Late"];
                    salaryView.LateHour = (decimal)Reader["LateHour"];
                    salaryView.LateStr = Reader["LateStr"].ToString();
                    salaryView.TotalPresent = (decimal)Reader["TotalPresent"];
                    salaryView.CL = (decimal)Reader["CL"];
                    salaryView.SL = (decimal)Reader["SL"];
                    salaryView.EL = (decimal)Reader["EL"];
                    salaryView.ML = (decimal)Reader["ML"];
                    salaryView.LeaveWithoutPay = (decimal)Reader["LeaveWithoutPay"];
                    salaryView.OL = (decimal)Reader["OL"];
                    salaryView.TotalLeave = (decimal)Reader["TotalLeave"];
                    salaryView.LeaveStr = Reader["LeaveStr"].ToString();
                    salaryView.GrandTotalPresent = (decimal)Reader["GrandTotalPresent"];
                    salaryView.PayDays = (decimal)Reader["PayDays"];
                    salaryView.PaySalary = (decimal)Reader["PaySalary"];
                    salaryView.OverTime = (decimal)Reader["OverTime"];
                    salaryView.OverTimeAmount = (decimal)Reader["OverTimeAmount"];
                    salaryView.ExtraOT = (decimal)Reader["ExtraOT"];
                    salaryView.ExtraOTAmount = (decimal)Reader["ExtraOTAmount"];
                    salaryView.ExtraOTStr = Reader["ExtraOTStr"].ToString();
                    salaryView.AdditionalOverTime = (decimal)Reader["AdditionalOverTime"];
                    salaryView.AdditionalOTStr = Reader["AdditionalOTStr"].ToString();
                    salaryView.DeductOT = (decimal)Reader["DeductOT"];
                    salaryView.DeductOTStr = Reader["DeductOTStr"].ToString();
                    salaryView.TotalOT = (decimal)Reader["TotalOT"];
                    salaryView.OTRate = (decimal)Reader["OTRate"];
                    salaryView.OTAmount = (decimal)Reader["OTAmount"];
                    salaryView.OTStr = Reader["OTStr"].ToString();
                    salaryView.TotalNight = (decimal)Reader["TotalNight"];
                    salaryView.NightRate = (decimal)Reader["NightRate"];
                    salaryView.NightAllowance = (decimal)Reader["NightAllowance"];
                    salaryView.AttendanceBonus = (decimal)Reader["AttendanceBonus"];
                    salaryView.ProductionBonus = (decimal)Reader["ProductionBonus"];
                    salaryView.HolidayAllowance = (decimal)Reader["HolidayAllowance"];
                    salaryView.HolidayAllowanceStr = Reader["HolidayAllowanceStr"].ToString();
                    salaryView.MobileAllowance = (decimal)Reader["MobileAllowance"];
                    salaryView.TransAllowancePay = (decimal)Reader["TransAllowancePay"];
                    salaryView.TransAllowancePayStr = Reader["TransAllowancePayStr"].ToString();
                    salaryView.OtherAllowance = (decimal)Reader["OtherAllowance"];
                    salaryView.OtherAllowanceStr = Reader["OtherAllowanceStr"].ToString();
                    salaryView.Arear = (decimal)Reader["Arear"];
                    salaryView.ArearStr = Reader["ArearStr"].ToString();
                    salaryView.MaternityLeave = (decimal)Reader["MaternityLeave"];
                    salaryView.MaternityLeaveStr = Reader["MaternityLeaveStr"].ToString();
                    salaryView.TotalAmount = (decimal)Reader["TotalAmount"];
                    salaryView.PayTotal = (decimal)Reader["PayTotal"];
                    salaryView.AbsentDeduct = (decimal)Reader["AbsentDeduct"];
                    salaryView.AbsentDeductNewJoin = (decimal)Reader["AbsentDeductNewJoin"];
                    salaryView.AbsentDeductRelease = (decimal)Reader["AbsentDeductRelease"];
                    salaryView.AbsentDeductTotal = (decimal)Reader["AbsentDeductTotal"];
                    salaryView.LateDeduct = (decimal)Reader["LateDeduct"];
                    salaryView.LateDeductStr = Reader["LateDeductStr"].ToString();
                    salaryView.LeaveDeduct = (decimal)Reader["LeaveDeduct"];
                    salaryView.LeaveDeductStr = Reader["LeaveDeductStr"].ToString();
                    salaryView.TransportDeduct = (decimal)Reader["TransportDeduct"];
                    salaryView.TransportDeductStr = Reader["TransportDeductStr"].ToString();
                    salaryView.OtherDeduct = (decimal)Reader["OtherDeduct"];
                    salaryView.OtherDeductStr = Reader["OtherDeductStr"].ToString();
                    salaryView.Tax = (decimal)Reader["Tax"];
                    salaryView.TaxStr = Reader["TaxStr"].ToString();
                    salaryView.ProvidentFund = (decimal)Reader["ProvidentFund"];
                    salaryView.ProvidentFundStr = Reader["ProvidentFundStr"].ToString();
                    salaryView.Lunch = (decimal)Reader["Lunch"];
                    salaryView.LunchStr = Reader["LunchStr"].ToString();
                    salaryView.Advance = (decimal)Reader["Advance"];
                    salaryView.AdvanceStr = Reader["AdvanceStr"].ToString();
                    salaryView.Loan = (decimal)Reader["Loan"];
                    salaryView.LoanStr = Reader["LoanStr"].ToString();
                    salaryView.MobbileDeduct = (decimal)Reader["MobbileDeduct"];
                    salaryView.MobbileDeductStr = Reader["MobbileDeductStr"].ToString();
                    salaryView.SecurityDeduct = (decimal)Reader["SecurityDeduct"];
                    salaryView.SecurityDeductStr = Reader["SecurityDeductStr"].ToString();
                    salaryView.Stamp = (decimal)Reader["Stamp"];
                    salaryView.TotalDeduct = (decimal)Reader["TotalDeduct"];
                    salaryView.NetPay = (decimal)Reader["NetPay"];
                    salaryView.NetPayStr = Reader["NetPayStr"].ToString();
                    salaryView.Cash = (decimal)Reader["Cash"];
                    salaryView.Bank = (decimal)Reader["Bank"];
                    salaryView.Paid = (decimal)Reader["Paid"];
                    salaryView.Due = (decimal)Reader["Due"];
                    salaryView.Remarks = Reader["Remarks"].ToString();
                    salaryView.PaymentStatus = Reader["PaymentStatus"].ToString();
                    salaryView.ELDays = (decimal)Reader["ELDays"];
                    salaryView.ELAmount = (decimal)Reader["ELAmount"];
                    salaryView.LunchAddition = (decimal)Reader["LunchAddition"];
                    salaryView.LunchDeduction = (decimal)Reader["LunchDeduction"];
                    salaryView.ServiceDuration = (decimal)Reader["ServiceDuration"];
                    salaryView.RoutingNumber = (decimal)Reader["RoutingNumber"];
                    salaryView.BankAccType = Reader["BankAccType"].ToString();
                    salaryView.Tk1000 = (decimal)Reader["Tk1000"];
                    salaryView.Tk500 = (decimal)Reader["Tk500"];
                    salaryView.Tk100 = (decimal)Reader["Tk100"];
                    salaryView.Tk50 = (decimal)Reader["Tk50"];
                    salaryView.Tk20 = (decimal)Reader["Tk20"];
                    salaryView.Tk10 = (decimal)Reader["Tk10"];
                    salaryView.Tk5 = (decimal)Reader["Tk5"];
                    salaryView.Tk2 = (decimal)Reader["Tk2"];
                    salaryView.Tk1 = (decimal)Reader["Tk1"];
                    salaryView.Devider = (decimal)Reader["Devider"];
                    salaryView.Reminder = (decimal)Reader["Reminder"];
                    salaryView.InWord = Reader["InWord"].ToString();
                    salaryView.InWordBangla = Reader["InWordBangla"].ToString();
                    salaryView.WHDPL = (decimal)Reader["WHDPL"];
                    salaryView.HDPL = (decimal)Reader["HDPL"];
                    salaryView.OverTimeYN = Reader["OverTimeYN"].ToString();
                    salaryView.GrossSalary = (decimal)Reader["GrossSalary"];
                    salaryView.BasicSalary = (decimal)Reader["BasicSalary"];
                    salaryView.HouseRent = (decimal)Reader["HouseRent"];
                    salaryView.FoodAllowance = (decimal)Reader["FoodAllowance"];
                    salaryView.TransportAllowance = (decimal)Reader["TransportAllowance"];
                    salaryView.MedicalAllowance = (decimal)Reader["MedicalAllowance"];
                    salaryView.ExchangeRate = (decimal)Reader["ExchangeRate"];
                    salaryView.GrossSalaryUsd = (decimal)Reader["GrossSalaryUsd"];
                    salaryView.SalaryPerDay = (decimal)Reader["SalaryPerDay"];
                    salaryView.Increment = (decimal)Reader["Increment"];
                    salaryView.IncrementStr = Reader["IncrementStr"].ToString();
                    salaryView.MonthDays = (decimal)Reader["MonthDays"];
                    salaryView.WeeklyHoliday = (decimal)Reader["WeeklyHoliday"];
                }
                Reader.Close();
                ConnectionClose();
                return salaryView;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryView\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<bool> IsExist(string categoryName = "", int categoryId = 0)
        {
            try
            {
                if (categoryName == "")
                {
                    Query = "SELECT 1 FROM Category";
                }

                if (categoryName != "" && categoryId == 0)
                {
                    Query = $"SELECT 1 FROM Category WHERE CategoryName = '{categoryName}' ";
                }

                if (categoryName != "" && categoryId != 0)
                {
                    Query = $"SELECT 1 FROM Category WHERE CategoryName = '{categoryName}' and CategoryId <> '{categoryId}'";
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




        public async Task<List<SalaryView>> GetSalaryViewList(string  salStr = "")
        {
            try
            {
                if (salStr == "")
                {
                    Query = "SELECT * FROM SalaryView";
                }
                else
                {
                    Query = $"SELECT * FROM SalaryView WHERE  SalStr = '{salStr}'";
                 
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalaryView> salaryViewList = new List<SalaryView>();
                while (Reader.Read())
                {
                    SalaryView salaryView = new SalaryView();

                    salaryView.SalaryId = (int)Reader["SalaryId"];
                    salaryView.Sn = (decimal)Reader["Sn"];
                    salaryView.SalStr = Reader["SalStr"].ToString();
                    salaryView.FromDate = (DateTime)Reader["FromDate"];
                    salaryView.ToDate = (DateTime)Reader["ToDate"];
                    salaryView.PayDate = (DateTime)Reader["PayDate"];
                    salaryView.EmployeeId = Reader["EmployeeId"].ToString();
                    salaryView.DepartmentId = (int)Reader["DepartmentId"];
                    salaryView.DepartmentName = Reader["DepartmentName"].ToString();
                    salaryView.SectionId = (int)Reader["SectionId"];
                    salaryView.SectionName = Reader["SectionName"].ToString();
                    salaryView.FloorCatItemId = (int)Reader["FloorCatItemId"];
                    salaryView.Floor = Reader["Floor"].ToString();
                    salaryView.LineCatItemId = (int)Reader["LineCatItemId"];
                    salaryView.Line = Reader["Line"].ToString();
                    salaryView.EmployeeName = Reader["EmployeeName"].ToString();
                    salaryView.SalarySectionId = (int)Reader["SalarySectionId"];
                    salaryView.SalarySection = Reader["SalarySection"].ToString();
                    salaryView.DesignationId = (int)Reader["DesignationId"];
                    salaryView.Designation = Reader["Designation"].ToString();
                    salaryView.GradeCatItemId = (int)Reader["GradeCatItemId"];
                    salaryView.Grade = Reader["Grade"].ToString();
                    salaryView.EmployeeTypeCatItemId = (int)Reader["EmployeeTypeCatItemId"];
                    salaryView.Type = Reader["Type"].ToString();
                    salaryView.PaySource = Reader["PaySource"].ToString();
                    salaryView.ActiveYN = Reader["ActiveYN"].ToString();
                    salaryView.BankInfoId = (int)Reader["BankInfoId"];
                    salaryView.AccNo = Reader["AccNo"].ToString();
                    salaryView.Holiday = (decimal)Reader["Holiday"];
                    salaryView.WorkingDay = (decimal)Reader["WorkingDay"];
                    salaryView.WeeklyHolidayMax = (decimal)Reader["WeeklyHolidayMax"];
                    salaryView.HolidayMax = (decimal)Reader["HolidayMax"];
                    salaryView.Present = (decimal)Reader["Present"];
                    salaryView.Absent = (decimal)Reader["Absent"];
                    salaryView.AbsentStr = Reader["AbsentStr"].ToString();
                    salaryView.AbsentNewJoin = (decimal)Reader["AbsentNewJoin"];
                    salaryView.AbsentNewJoinStr = Reader["AbsentNewJoinStr"].ToString();
                    salaryView.AbsentRelease = (decimal)Reader["AbsentRelease"];
                    salaryView.AbsentReleaseStr = Reader["AbsentReleaseStr"].ToString();
                    salaryView.AbsentTotal = (decimal)Reader["AbsentTotal"];
                    salaryView.AbsentTotalStr = Reader["AbsentTotalStr"].ToString();
                    salaryView.Late = (decimal)Reader["Late"];
                    salaryView.LateHour = (decimal)Reader["LateHour"];
                    salaryView.LateStr = Reader["LateStr"].ToString();
                    salaryView.TotalPresent = (decimal)Reader["TotalPresent"];
                    salaryView.CL = (decimal)Reader["CL"];
                    salaryView.SL = (decimal)Reader["SL"];
                    salaryView.EL = (decimal)Reader["EL"];
                    salaryView.ML = (decimal)Reader["ML"];
                    salaryView.LeaveWithoutPay = (decimal)Reader["LeaveWithoutPay"];
                    salaryView.OL = (decimal)Reader["OL"];
                    salaryView.TotalLeave = (decimal)Reader["TotalLeave"];
                    salaryView.LeaveStr = Reader["LeaveStr"].ToString();
                    salaryView.GrandTotalPresent = (decimal)Reader["GrandTotalPresent"];
                    salaryView.PayDays = (decimal)Reader["PayDays"];
                    salaryView.PaySalary = (decimal)Reader["PaySalary"];
                    salaryView.OverTime = (decimal)Reader["OverTime"];
                    salaryView.OverTimeAmount = (decimal)Reader["OverTimeAmount"];
                    salaryView.ExtraOT = (decimal)Reader["ExtraOT"];
                    salaryView.ExtraOTAmount = (decimal)Reader["ExtraOTAmount"];
                    salaryView.ExtraOTStr = Reader["ExtraOTStr"].ToString();
                    salaryView.AdditionalOverTime = (decimal)Reader["AdditionalOverTime"];
                    salaryView.AdditionalOTStr = Reader["AdditionalOTStr"].ToString();
                    salaryView.DeductOT = (decimal)Reader["DeductOT"];
                    salaryView.DeductOTStr = Reader["DeductOTStr"].ToString();
                    salaryView.TotalOT = (decimal)Reader["TotalOT"];
                    salaryView.OTRate = (decimal)Reader["OTRate"];
                    salaryView.OTAmount = (decimal)Reader["OTAmount"];
                    salaryView.OTStr = Reader["OTStr"].ToString();
                    salaryView.TotalNight = (decimal)Reader["TotalNight"];
                    salaryView.NightRate = (decimal)Reader["NightRate"];
                    salaryView.NightAllowance = (decimal)Reader["NightAllowance"];
                    salaryView.AttendanceBonus = (decimal)Reader["AttendanceBonus"];
                    salaryView.ProductionBonus = (decimal)Reader["ProductionBonus"];
                    salaryView.HolidayAllowance = (decimal)Reader["HolidayAllowance"];
                    salaryView.HolidayAllowanceStr = Reader["HolidayAllowanceStr"].ToString();
                    salaryView.MobileAllowance = (decimal)Reader["MobileAllowance"];
                    salaryView.TransAllowancePay = (decimal)Reader["TransAllowancePay"];
                    salaryView.TransAllowancePayStr = Reader["TransAllowancePayStr"].ToString();
                    salaryView.OtherAllowance = (decimal)Reader["OtherAllowance"];
                    salaryView.OtherAllowanceStr = Reader["OtherAllowanceStr"].ToString();
                    salaryView.Arear = (decimal)Reader["Arear"];
                    salaryView.ArearStr = Reader["ArearStr"].ToString();
                    salaryView.MaternityLeave = (decimal)Reader["MaternityLeave"];
                    salaryView.MaternityLeaveStr = Reader["MaternityLeaveStr"].ToString();
                    salaryView.TotalAmount = (decimal)Reader["TotalAmount"];
                    salaryView.PayTotal = (decimal)Reader["PayTotal"];
                    salaryView.AbsentDeduct = (decimal)Reader["AbsentDeduct"];
                    salaryView.AbsentDeductNewJoin = (decimal)Reader["AbsentDeductNewJoin"];
                    salaryView.AbsentDeductRelease = (decimal)Reader["AbsentDeductRelease"];
                    salaryView.AbsentDeductTotal = (decimal)Reader["AbsentDeductTotal"];
                    salaryView.LateDeduct = (decimal)Reader["LateDeduct"];
                    salaryView.LateDeductStr = Reader["LateDeductStr"].ToString();
                    salaryView.LeaveDeduct = (decimal)Reader["LeaveDeduct"];
                    salaryView.LeaveDeductStr = Reader["LeaveDeductStr"].ToString();
                    salaryView.TransportDeduct = (decimal)Reader["TransportDeduct"];
                    salaryView.TransportDeductStr = Reader["TransportDeductStr"].ToString();
                    salaryView.OtherDeduct = (decimal)Reader["OtherDeduct"];
                    salaryView.OtherDeductStr = Reader["OtherDeductStr"].ToString();
                    salaryView.Tax = (decimal)Reader["Tax"];
                    salaryView.TaxStr = Reader["TaxStr"].ToString();
                    salaryView.ProvidentFund = (decimal)Reader["ProvidentFund"];
                    salaryView.ProvidentFundStr = Reader["ProvidentFundStr"].ToString();
                    salaryView.Lunch = (decimal)Reader["Lunch"];
                    salaryView.LunchStr = Reader["LunchStr"].ToString();
                    salaryView.Advance = (decimal)Reader["Advance"];
                    salaryView.AdvanceStr = Reader["AdvanceStr"].ToString();
                    salaryView.Loan = (decimal)Reader["Loan"];
                    salaryView.LoanStr = Reader["LoanStr"].ToString();
                    salaryView.MobbileDeduct = (decimal)Reader["MobbileDeduct"];
                    salaryView.MobbileDeductStr = Reader["MobbileDeductStr"].ToString();
                    salaryView.SecurityDeduct = (decimal)Reader["SecurityDeduct"];
                    salaryView.SecurityDeductStr = Reader["SecurityDeductStr"].ToString();
                    salaryView.Stamp = (decimal)Reader["Stamp"];
                    salaryView.TotalDeduct = (decimal)Reader["TotalDeduct"];
                    salaryView.NetPay = (decimal)Reader["NetPay"];
                    salaryView.NetPayStr = Reader["NetPayStr"].ToString();
                    salaryView.Cash = (decimal)Reader["Cash"];
                    salaryView.Bank = (decimal)Reader["Bank"];
                    salaryView.Paid = (decimal)Reader["Paid"];
                    salaryView.Due = (decimal)Reader["Due"];
                    salaryView.Remarks = Reader["Remarks"].ToString();
                    salaryView.PaymentStatus = Reader["PaymentStatus"].ToString();
                    salaryView.ELDays = (decimal)Reader["ELDays"];
                    salaryView.ELAmount = (decimal)Reader["ELAmount"];
                    salaryView.LunchAddition = (decimal)Reader["LunchAddition"];
                    salaryView.LunchDeduction = (decimal)Reader["LunchDeduction"];
                    salaryView.ServiceDuration = (decimal)Reader["ServiceDuration"];
                    salaryView.RoutingNumber = (decimal)Reader["RoutingNumber"];
                    salaryView.BankAccType = Reader["BankAccType"].ToString();
                    salaryView.Tk1000 = (decimal)Reader["Tk1000"];
                    salaryView.Tk500 = (decimal)Reader["Tk500"];
                    salaryView.Tk100 = (decimal)Reader["Tk100"];
                    salaryView.Tk50 = (decimal)Reader["Tk50"];
                    salaryView.Tk20 = (decimal)Reader["Tk20"];
                    salaryView.Tk10 = (decimal)Reader["Tk10"];
                    salaryView.Tk5 = (decimal)Reader["Tk5"];
                    salaryView.Tk2 = (decimal)Reader["Tk2"];
                    salaryView.Tk1 = (decimal)Reader["Tk1"];
                    salaryView.Devider = (decimal)Reader["Devider"];
                    salaryView.Reminder = (decimal)Reader["Reminder"];
                    salaryView.InWord = Reader["InWord"].ToString();
                    salaryView.InWordBangla = Reader["InWordBangla"].ToString();
                    salaryView.WHDPL = (decimal)Reader["WHDPL"];
                    salaryView.HDPL = (decimal)Reader["HDPL"];
                    salaryView.OverTimeYN = Reader["OverTimeYN"].ToString();
                    salaryView.GrossSalary = (decimal)Reader["GrossSalary"];
                    salaryView.BasicSalary = (decimal)Reader["BasicSalary"];
                    salaryView.HouseRent = (decimal)Reader["HouseRent"];
                    salaryView.FoodAllowance = (decimal)Reader["FoodAllowance"];
                    salaryView.TransportAllowance = (decimal)Reader["TransportAllowance"];
                    salaryView.MedicalAllowance = (decimal)Reader["MedicalAllowance"];
                    salaryView.ExchangeRate = (decimal)Reader["ExchangeRate"];
                    salaryView.GrossSalaryUsd = (decimal)Reader["GrossSalaryUsd"];
                    salaryView.SalaryPerDay = (decimal)Reader["SalaryPerDay"];
                    salaryView.Increment = (decimal)Reader["Increment"];
                    salaryView.IncrementStr = Reader["IncrementStr"].ToString();
                    salaryView.MonthDays = (decimal)Reader["MonthDays"];
                    salaryView.WeeklyHoliday = (decimal)Reader["WeeklyHoliday"];

                    salaryViewList.Add(salaryView);
                }
                Reader.Close();
                ConnectionClose();
                return salaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        //*********************
        //*********************

        public async Task<List<SalaryView>> GetDistinctSalStrList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT Distinct SalStr FROM SalaryView";
                }
                else
                {
                    Query = "SELECT Distinct SalStr FROM SalaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalaryView> salaryViewList = new List<SalaryView>();
                while (Reader.Read())
                {
                    SalaryView salaryView = new SalaryView();

                    
                    salaryView.SalStr = Reader["SalStr"].ToString();
                    salaryViewList.Add(salaryView);
                }
                Reader.Close();
                ConnectionClose();
                return salaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        //***************************************************












        public async Task<List<SalaryView>> GetSalaryViewListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM SalaryView";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM SalaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalaryView> salaryViewList = new List<SalaryView>();
                while (Reader.Read())
                {
                    SalaryView salaryView = new SalaryView();

                    SkipOnError(() => salaryView.SalaryId = (int)Reader["SalaryId"]);
                    SkipOnError(() => salaryView.Sn = (decimal)Reader["Sn"]);
                    SkipOnError(() => salaryView.SalStr = Reader["SalStr"].ToString());
                    SkipOnError(() => salaryView.FromDate = (DateTime)Reader["FromDate"]);
                    SkipOnError(() => salaryView.ToDate = (DateTime)Reader["ToDate"]);
                    SkipOnError(() => salaryView.PayDate = (DateTime)Reader["PayDate"]);
                    SkipOnError(() => salaryView.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => salaryView.DepartmentId = (int)Reader["DepartmentId"]);
                    SkipOnError(() => salaryView.DepartmentName = Reader["DepartmentName"].ToString());
                    SkipOnError(() => salaryView.SectionId = (int)Reader["SectionId"]);
                    SkipOnError(() => salaryView.SectionName = Reader["SectionName"].ToString());
                    SkipOnError(() => salaryView.FloorCatItemId = (int)Reader["FloorCatItemId"]);
                    SkipOnError(() => salaryView.Floor = Reader["Floor"].ToString());
                    SkipOnError(() => salaryView.LineCatItemId = (int)Reader["LineCatItemId"]);
                    SkipOnError(() => salaryView.Line = Reader["Line"].ToString());
                    SkipOnError(() => salaryView.SalarySectionId = (int)Reader["SalarySectionId"]);
                    SkipOnError(() => salaryView.SalarySection = Reader["SalarySection"].ToString());
                    SkipOnError(() => salaryView.DesignationId = (int)Reader["DesignationId"]);
                    SkipOnError(() => salaryView.Designation = Reader["Designation"].ToString());
                    SkipOnError(() => salaryView.GradeCatItemId = (int)Reader["GradeCatItemId"]);
                    SkipOnError(() => salaryView.Grade = Reader["Grade"].ToString());
                    SkipOnError(() => salaryView.EmployeeTypeCatItemId = (int)Reader["EmployeeTypeCatItemId"]);
                    SkipOnError(() => salaryView.Type = Reader["Type"].ToString());
                    SkipOnError(() => salaryView.PaySource = Reader["PaySource"].ToString());
                    SkipOnError(() => salaryView.ActiveYN = Reader["ActiveYN"].ToString());
                    SkipOnError(() => salaryView.BankInfoId = (int)Reader["BankInfoId"]);
                    SkipOnError(() => salaryView.AccNo = Reader["AccNo"].ToString());
                    SkipOnError(() => salaryView.Holiday = (decimal)Reader["Holiday"]);
                    SkipOnError(() => salaryView.WorkingDay = (decimal)Reader["WorkingDay"]);
                    SkipOnError(() => salaryView.WeeklyHolidayMax = (decimal)Reader["WeeklyHolidayMax"]);
                    SkipOnError(() => salaryView.HolidayMax = (decimal)Reader["HolidayMax"]);
                    SkipOnError(() => salaryView.Present = (decimal)Reader["Present"]);
                    SkipOnError(() => salaryView.Absent = (decimal)Reader["Absent"]);
                    SkipOnError(() => salaryView.AbsentStr = Reader["AbsentStr"].ToString());
                    SkipOnError(() => salaryView.AbsentNewJoin = (decimal)Reader["AbsentNewJoin"]);
                    SkipOnError(() => salaryView.AbsentNewJoinStr = Reader["AbsentNewJoinStr"].ToString());
                    SkipOnError(() => salaryView.AbsentRelease = (decimal)Reader["AbsentRelease"]);
                    SkipOnError(() => salaryView.AbsentReleaseStr = Reader["AbsentReleaseStr"].ToString());
                    SkipOnError(() => salaryView.AbsentTotal = (decimal)Reader["AbsentTotal"]);
                    SkipOnError(() => salaryView.AbsentTotalStr = Reader["AbsentTotalStr"].ToString());
                    SkipOnError(() => salaryView.Late = (decimal)Reader["Late"]);
                    SkipOnError(() => salaryView.LateHour = (decimal)Reader["LateHour"]);
                    SkipOnError(() => salaryView.LateStr = Reader["LateStr"].ToString());
                    SkipOnError(() => salaryView.TotalPresent = (decimal)Reader["TotalPresent"]);
                    SkipOnError(() => salaryView.CL = (decimal)Reader["CL"]);
                    SkipOnError(() => salaryView.SL = (decimal)Reader["SL"]);
                    SkipOnError(() => salaryView.EL = (decimal)Reader["EL"]);
                    SkipOnError(() => salaryView.ML = (decimal)Reader["ML"]);
                    SkipOnError(() => salaryView.LeaveWithoutPay = (decimal)Reader["LeaveWithoutPay"]);
                    SkipOnError(() => salaryView.OL = (decimal)Reader["OL"]);
                    SkipOnError(() => salaryView.TotalLeave = (decimal)Reader["TotalLeave"]);
                    SkipOnError(() => salaryView.LeaveStr = Reader["LeaveStr"].ToString());
                    SkipOnError(() => salaryView.GrandTotalPresent = (decimal)Reader["GrandTotalPresent"]);
                    SkipOnError(() => salaryView.PayDays = (decimal)Reader["PayDays"]);
                    SkipOnError(() => salaryView.PaySalary = (decimal)Reader["PaySalary"]);
                    SkipOnError(() => salaryView.OverTime = (decimal)Reader["OverTime"]);
                    SkipOnError(() => salaryView.OverTimeAmount = (decimal)Reader["OverTimeAmount"]);
                    SkipOnError(() => salaryView.ExtraOT = (decimal)Reader["ExtraOT"]);
                    SkipOnError(() => salaryView.ExtraOTAmount = (decimal)Reader["ExtraOTAmount"]);
                    SkipOnError(() => salaryView.ExtraOTStr = Reader["ExtraOTStr"].ToString());
                    SkipOnError(() => salaryView.AdditionalOverTime = (decimal)Reader["AdditionalOverTime"]);
                    SkipOnError(() => salaryView.AdditionalOTStr = Reader["AdditionalOTStr"].ToString());
                    SkipOnError(() => salaryView.DeductOT = (decimal)Reader["DeductOT"]);
                    SkipOnError(() => salaryView.DeductOTStr = Reader["DeductOTStr"].ToString());
                    SkipOnError(() => salaryView.TotalOT = (decimal)Reader["TotalOT"]);
                    SkipOnError(() => salaryView.OTRate = (decimal)Reader["OTRate"]);
                    SkipOnError(() => salaryView.OTAmount = (decimal)Reader["OTAmount"]);
                    SkipOnError(() => salaryView.OTStr = Reader["OTStr"].ToString());
                    SkipOnError(() => salaryView.TotalNight = (decimal)Reader["TotalNight"]);
                    SkipOnError(() => salaryView.NightRate = (decimal)Reader["NightRate"]);
                    SkipOnError(() => salaryView.NightAllowance = (decimal)Reader["NightAllowance"]);
                    SkipOnError(() => salaryView.AttendanceBonus = (decimal)Reader["AttendanceBonus"]);
                    SkipOnError(() => salaryView.ProductionBonus = (decimal)Reader["ProductionBonus"]);
                    SkipOnError(() => salaryView.HolidayAllowance = (decimal)Reader["HolidayAllowance"]);
                    SkipOnError(() => salaryView.HolidayAllowanceStr = Reader["HolidayAllowanceStr"].ToString());
                    SkipOnError(() => salaryView.MobileAllowance = (decimal)Reader["MobileAllowance"]);
                    SkipOnError(() => salaryView.TransAllowancePay = (decimal)Reader["TransAllowancePay"]);
                    SkipOnError(() => salaryView.TransAllowancePayStr = Reader["TransAllowancePayStr"].ToString());
                    SkipOnError(() => salaryView.OtherAllowance = (decimal)Reader["OtherAllowance"]);
                    SkipOnError(() => salaryView.OtherAllowanceStr = Reader["OtherAllowanceStr"].ToString());
                    SkipOnError(() => salaryView.Arear = (decimal)Reader["Arear"]);
                    SkipOnError(() => salaryView.ArearStr = Reader["ArearStr"].ToString());
                    SkipOnError(() => salaryView.MaternityLeave = (decimal)Reader["MaternityLeave"]);
                    SkipOnError(() => salaryView.MaternityLeaveStr = Reader["MaternityLeaveStr"].ToString());
                    SkipOnError(() => salaryView.TotalAmount = (decimal)Reader["TotalAmount"]);
                    SkipOnError(() => salaryView.PayTotal = (decimal)Reader["PayTotal"]);
                    SkipOnError(() => salaryView.AbsentDeduct = (decimal)Reader["AbsentDeduct"]);
                    SkipOnError(() => salaryView.AbsentDeductNewJoin = (decimal)Reader["AbsentDeductNewJoin"]);
                    SkipOnError(() => salaryView.AbsentDeductRelease = (decimal)Reader["AbsentDeductRelease"]);
                    SkipOnError(() => salaryView.AbsentDeductTotal = (decimal)Reader["AbsentDeductTotal"]);
                    SkipOnError(() => salaryView.LateDeduct = (decimal)Reader["LateDeduct"]);
                    SkipOnError(() => salaryView.LateDeductStr = Reader["LateDeductStr"].ToString());
                    SkipOnError(() => salaryView.LeaveDeduct = (decimal)Reader["LeaveDeduct"]);
                    SkipOnError(() => salaryView.LeaveDeductStr = Reader["LeaveDeductStr"].ToString());
                    SkipOnError(() => salaryView.TransportDeduct = (decimal)Reader["TransportDeduct"]);
                    SkipOnError(() => salaryView.TransportDeductStr = Reader["TransportDeductStr"].ToString());
                    SkipOnError(() => salaryView.OtherDeduct = (decimal)Reader["OtherDeduct"]);
                    SkipOnError(() => salaryView.OtherDeductStr = Reader["OtherDeductStr"].ToString());
                    SkipOnError(() => salaryView.Tax = (decimal)Reader["Tax"]);
                    SkipOnError(() => salaryView.TaxStr = Reader["TaxStr"].ToString());
                    SkipOnError(() => salaryView.ProvidentFund = (decimal)Reader["ProvidentFund"]);
                    SkipOnError(() => salaryView.ProvidentFundStr = Reader["ProvidentFundStr"].ToString());
                    SkipOnError(() => salaryView.Lunch = (decimal)Reader["Lunch"]);
                    SkipOnError(() => salaryView.LunchStr = Reader["LunchStr"].ToString());
                    SkipOnError(() => salaryView.Advance = (decimal)Reader["Advance"]);
                    SkipOnError(() => salaryView.AdvanceStr = Reader["AdvanceStr"].ToString());
                    SkipOnError(() => salaryView.Loan = (decimal)Reader["Loan"]);
                    SkipOnError(() => salaryView.LoanStr = Reader["LoanStr"].ToString());
                    SkipOnError(() => salaryView.MobbileDeduct = (decimal)Reader["MobbileDeduct"]);
                    SkipOnError(() => salaryView.MobbileDeductStr = Reader["MobbileDeductStr"].ToString());
                    SkipOnError(() => salaryView.SecurityDeduct = (decimal)Reader["SecurityDeduct"]);
                    SkipOnError(() => salaryView.SecurityDeductStr = Reader["SecurityDeductStr"].ToString());
                    SkipOnError(() => salaryView.Stamp = (decimal)Reader["Stamp"]);
                    SkipOnError(() => salaryView.TotalDeduct = (decimal)Reader["TotalDeduct"]);
                    SkipOnError(() => salaryView.NetPay = (decimal)Reader["NetPay"]);
                    SkipOnError(() => salaryView.NetPayStr = Reader["NetPayStr"].ToString());
                    SkipOnError(() => salaryView.Cash = (decimal)Reader["Cash"]);
                    SkipOnError(() => salaryView.Bank = (decimal)Reader["Bank"]);
                    SkipOnError(() => salaryView.Paid = (decimal)Reader["Paid"]);
                    SkipOnError(() => salaryView.Due = (decimal)Reader["Due"]);
                    SkipOnError(() => salaryView.Remarks = Reader["Remarks"].ToString());
                    SkipOnError(() => salaryView.PaymentStatus = Reader["PaymentStatus"].ToString());
                    SkipOnError(() => salaryView.ELDays = (decimal)Reader["ELDays"]);
                    SkipOnError(() => salaryView.ELAmount = (decimal)Reader["ELAmount"]);
                    SkipOnError(() => salaryView.LunchAddition = (decimal)Reader["LunchAddition"]);
                    SkipOnError(() => salaryView.LunchDeduction = (decimal)Reader["LunchDeduction"]);
                    SkipOnError(() => salaryView.ServiceDuration = (decimal)Reader["ServiceDuration"]);
                    SkipOnError(() => salaryView.RoutingNumber = (decimal)Reader["RoutingNumber"]);
                    SkipOnError(() => salaryView.BankAccType = Reader["BankAccType"].ToString());
                    SkipOnError(() => salaryView.Tk1000 = (decimal)Reader["Tk1000"]);
                    SkipOnError(() => salaryView.Tk500 = (decimal)Reader["Tk500"]);
                    SkipOnError(() => salaryView.Tk100 = (decimal)Reader["Tk100"]);
                    SkipOnError(() => salaryView.Tk50 = (decimal)Reader["Tk50"]);
                    SkipOnError(() => salaryView.Tk20 = (decimal)Reader["Tk20"]);
                    SkipOnError(() => salaryView.Tk10 = (decimal)Reader["Tk10"]);
                    SkipOnError(() => salaryView.Tk5 = (decimal)Reader["Tk5"]);
                    SkipOnError(() => salaryView.Tk2 = (decimal)Reader["Tk2"]);
                    SkipOnError(() => salaryView.Tk1 = (decimal)Reader["Tk1"]);
                    SkipOnError(() => salaryView.Devider = (decimal)Reader["Devider"]);
                    SkipOnError(() => salaryView.Reminder = (decimal)Reader["Reminder"]);
                    SkipOnError(() => salaryView.InWord = Reader["InWord"].ToString());
                    SkipOnError(() => salaryView.InWordBangla = Reader["InWordBangla"].ToString());
                    SkipOnError(() => salaryView.WHDPL = (decimal)Reader["WHDPL"]);
                    SkipOnError(() => salaryView.HDPL = (decimal)Reader["HDPL"]);
                    SkipOnError(() => salaryView.OverTimeYN = Reader["OverTimeYN"].ToString());
                    SkipOnError(() => salaryView.GrossSalary = (decimal)Reader["GrossSalary"]);
                    SkipOnError(() => salaryView.BasicSalary = (decimal)Reader["BasicSalary"]);
                    SkipOnError(() => salaryView.HouseRent = (decimal)Reader["HouseRent"]);
                    SkipOnError(() => salaryView.FoodAllowance = (decimal)Reader["FoodAllowance"]);
                    SkipOnError(() => salaryView.TransportAllowance = (decimal)Reader["TransportAllowance"]);
                    SkipOnError(() => salaryView.MedicalAllowance = (decimal)Reader["MedicalAllowance"]);
                    SkipOnError(() => salaryView.ExchangeRate = (decimal)Reader["ExchangeRate"]);
                    SkipOnError(() => salaryView.GrossSalaryUsd = (decimal)Reader["GrossSalaryUsd"]);
                    SkipOnError(() => salaryView.SalaryPerDay = (decimal)Reader["SalaryPerDay"]);
                    SkipOnError(() => salaryView.Increment = (decimal)Reader["Increment"]);
                    SkipOnError(() => salaryView.IncrementStr = Reader["IncrementStr"].ToString());
                    SkipOnError(() => salaryView.MonthDays = (decimal)Reader["MonthDays"]);
                    SkipOnError(() => salaryView.WeeklyHoliday = (decimal)Reader["WeeklyHoliday"]);

                    salaryViewList.Add(salaryView);
                }
                Reader.Close();
                ConnectionClose();
                return salaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryView List \n" + exception.Message);
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



    }
}

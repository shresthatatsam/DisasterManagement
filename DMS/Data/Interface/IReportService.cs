namespace DMS.Data.Interface
{
    public interface IReportService
    {
        IEnumerable<DisasterReport> GetDisasterReports(string disasterType, DateTime? startDate, DateTime? endDate);
        IEnumerable<VictimReport> GetVictimReports(string location, string conditionStatus);
        IEnumerable<ResourceReport> GetResourceReports(string resourceType);
        IEnumerable<UserReport> GetUserReports(string userRole);
        IEnumerable<CustomReport> GetCustomReports(string customFilter);
    }
}

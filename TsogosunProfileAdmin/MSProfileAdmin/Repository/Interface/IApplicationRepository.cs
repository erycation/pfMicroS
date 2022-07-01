
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IApplicationRepository
    {
        Application GetApplicationByName(string applicationName);
        Application GetApplicationById(int appicationId);
        List<Application> GetApplications();
        List<Application> GetActiveApplications();
        void UpdateApplication(Application application);
        void AddApplication(Application application);
        void Save();
    }
}

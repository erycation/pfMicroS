
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Shared;

namespace tsogosun.com.MSProfileAdmin.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {

        private readonly ProfileAdminDBContext _dbContext;

        public ApplicationRepository(ProfileAdminDBContext context)
        {
            _dbContext = context;
        }

        public List<Application> GetActiveApplications()
        {
            return _dbContext.Applications.Where(a => a.isActive == true).ToList();
        }

        public Application GetApplicationById(int appicationId)
        {
            return _dbContext.Applications.SingleOrDefault(a => a.ApplicationID == appicationId);
        }

        public Application GetApplicationByName(string applicationName)
        {
            return _dbContext.Applications.SingleOrDefault(a => a.ApplicationName == applicationName);
        }

        public List<Application> GetApplications()
        {
            return _dbContext.Applications.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void AddApplication(Application application)
        {
            _dbContext.Applications.Add(application);
        }

        public void UpdateApplication(Application application)
        {
            _dbContext.Entry(application).State = EntityState.Modified;
        }
    }
}

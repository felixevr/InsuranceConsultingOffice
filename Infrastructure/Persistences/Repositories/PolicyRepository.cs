using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;

namespace InsuranceConsultingOffice.Infrastructure.Persistences.Repositories
{
    public class PolicyRepository
    {
        public List<Policy> GetPoliciesByCode(InsuranceDbContext context, string code)
        {
            var response = context.Policies.Where(x => x.Code.Contains(code)).ToList();

            return response;
        }
    }
}
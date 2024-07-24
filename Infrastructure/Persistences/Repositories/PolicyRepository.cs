using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceConsultingOffice.Infrastructure.Persistences.Repositories
{
    public class PolicyRepository
    {
        public List<Policy> GetPoliciesByCode(InsuranceDbContext context, string code)
        {
            var response = context.Policies.Where(x => x.Code.Equals(code))
                .Include(x => x.Assignments)
                .ThenInclude(x => x.Insured)
                .ToList();

            return response;
        }

        public Policy GetPolicyById(InsuranceDbContext context, int id)
        {
            var getByid = context.Policies.AsNoTracking().FirstOrDefault(x => x.PolicyId.Equals(id));

            return getByid!;
        }

        // ====================================================================================

        // GRAN LECCIÓN APRENDIDA AQUÍ CON ESTA MALA CONSULTA:
        // Devolver un IQuerable no sirve

        //public IQueryable<Policy> GetPolicyById(InsuranceDbContext context, int id)
        //{
        //    var getByid = context.Policies.Where(x => x.PolicyId.Equals(id)).AsNoTracking();

        //    return getByid;
        //}
    }
}
using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceConsultingOffice.Infrastructure.Persistences.Repositories
{
    public class PolicyRepository
    {
        private readonly InsuranceDbContext _context;

        public PolicyRepository(InsuranceDbContext context)
        {
            _context = context;
        }



        public List<int> GetAllPoliciesIds()
        {
            List<int> policyIds = _context.Policies.AsNoTracking().Select(p => p.PolicyId).ToList();
        
            return policyIds;
        }



        public Policy GetPolicyById(int id)
        {
            var getByid = _context.Policies.AsNoTracking().FirstOrDefault(x => x.PolicyId.Equals(id));

            return getByid!;
        }



        public List<Policy> GetPoliciesByCodeNoTrace(string code)
        {
            var response = _context.Policies.AsNoTracking().Where(x => x.Code.Equals(code))
                .Include(x => x.Assignaments)
                .ThenInclude(x => x.Insured)
                .ToList();

            return response;
        }
    }
}



        // ====================================================================================

        // GRAN LECCIÓN APRENDIDA AQUÍ CON ESTA MALA CONSULTA:
        // Devolver un IQuerable no sirve

        //public IQueryable<Policy> GetPolicyById(InsuranceDbContext context, int id)
        //{
        //    var getByid = context.Policies.Where(x => x.PolicyId.Equals(id)).AsNoTracking();

        //    return getByid;
        //}

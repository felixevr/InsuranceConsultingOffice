using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceConsultingOffice.Infrastructure.Persistences.Repositories
{
    public class InsuredRepository
    {
        
        public List<Insured> GetInsuredsByCardId(InsuranceDbContext context, string cardId)
        {
            var response = context.Insureds.Where(x => x.IdCard.Equals(cardId))
                .Include(x => x.Assignaments)
                .ThenInclude(x => x.Policy)
                .ToList();

            return response;
        }

        public Insured GetInsuredById(InsuranceDbContext context, int id)
        {
            var getById = context.Insureds.AsNoTracking().FirstOrDefault();

            return getById!;
        }
    }
}
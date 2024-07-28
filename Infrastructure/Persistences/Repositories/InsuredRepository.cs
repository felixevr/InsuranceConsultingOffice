using InsuranceConsultingOffice.Domain.Entities;
using InsuranceConsultingOffice.Infrastructure.Repository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceConsultingOffice.Infrastructure.Persistences.Repositories
{
    public class InsuredRepository
    {
        private readonly InsuranceDbContext _context;
        public InsuredRepository(InsuranceDbContext context)
        {
            _context = context;
        }

        //public List<Insured> GetInsuredsByCardId(string cardId)
        //{
        //    var response = _context.Insureds.Where(x => x.IdCard.Equals(cardId))
        //        .Include(x => x.Assignaments)
        //        .ThenInclude(x => x.Policy)
        //        .ToList();

        //    return response;
        //}



        public Insured GetInsuredById(int id)
        {
            var getById = _context.Insureds.AsNoTracking().FirstOrDefault(x => x.InsuredId.Equals(id));

            return getById!;
        }



        public List<Insured> GetInsuredsByCardIdNoTrace(string cardId)
        {
            var response = _context.Insureds.AsNoTracking().Where(x => x.IdCard.Equals(cardId))
                .Include(x => x.Assignaments)
                .ThenInclude(x => x.Policy)
                .ToList();

            return response;
        }
    }
}
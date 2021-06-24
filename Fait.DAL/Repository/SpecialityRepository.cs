using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository
{
    public class SpecialityRepository : Repository<Speciality>, ISpecialityRepository
    {
        public SpecialityRepository(FAITContext context)
        : base(context)
        {
        }

        public ICollection<Speciality> GetSpecialities(bool isOnlyForMasterDegree = false)
        {
            if (isOnlyForMasterDegree)
            {
                return Find(x => x.IsOnlyForMasterDegree == isOnlyForMasterDegree);
            }

            return Find();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface ISpecialityRepository
    {
        ICollection<Speciality> GetSpecialities(bool isOnlyForMasterDegree = false);
    }
}

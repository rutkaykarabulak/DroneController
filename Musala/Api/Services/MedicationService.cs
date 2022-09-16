using Musala.DbModels;
using Musala.EFModels;

namespace Musala.Api.Services
{
    public class MedicationService: IMedicationService
    {
        #region Properties
        private PostgreSQLDbContext _postgreDbContext;
        #endregion
        public IEnumerable<MedicationEntity> GetAllMedications()
        {
            List<MedicationEntity> result = new();

            List<Medication> dataList = _postgreDbContext.Medications.ToList();

            dataList.ForEach(m => result.Add(new MedicationEntity()
            {
                Id = m.Id,
                Name = m.Name,
                Code = m.Code,
                Weight = m.Weight,
                Image = m.Image,
            }));

            return result;
        }
        public async Task<MedicationEntity?> GetMedication(int id)
        {
            Medication? medication = await _postgreDbContext.Medications.FindAsync(id);

            if (medication == null)
            {
                return null;
            }

            return new MedicationEntity()
            {
                Id = medication.Id,
                Weight = medication.Weight,
                Code = medication.Code,
                Name = medication.Name,
                Image = medication.Image,
            };
        }
        public MedicationService(PostgreSQLDbContext dbContext)
        {
            _postgreDbContext = dbContext;
        }
    }
}

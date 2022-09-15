using Musala.DbModels;

namespace Musala.Api.Services
{
    public interface IMedicationService
    {
        /// <summary>
        /// Gets the medication with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Medication object if it exists in database, null otherwise.</returns>
        public abstract Task<MedicationEntity?> GetMedication(int id);

        /// <summary>
        /// Gets all medications exist in database.
        /// </summary>
        /// <returns>List of medication items.</returns>
        public abstract IEnumerable<MedicationEntity> GetAllMedications();
    }
}

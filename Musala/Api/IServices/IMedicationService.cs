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
        public abstract Task<MedicationEntity> Get(int id);

        /// <summary>
        /// Gets all medications exist in database.
        /// </summary>
        /// <returns>List of medication items.</returns>
        public abstract Task<IEnumerable<MedicationEntity>> GetAll();

        /// <summary>
        /// Inserts the given medication to the database.
        /// </summary>
        /// <param name="medication"></param>
        public abstract Task Create(MedicationEntity medication);

        /// <summary>
        /// Removes the medication with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if removal is successfull, false otherwise.</returns>
        public abstract Task<bool> Delete(int id);

        /// <summary>
        /// Updates the given medication object.
        /// </summary>
        /// <param name="medication"></param>
        /// <returns>Updated drone model</returns>
        public abstract Task<MedicationEntity> Update(); // Medication Put TODO
    }
}

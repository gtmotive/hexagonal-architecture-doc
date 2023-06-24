namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds
{
    /// <summary>
    /// Containts the signature for transaction operations.
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Commit transaction.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Rollback transaction.
        /// </summary>
        void CancelChanges();
    }
}

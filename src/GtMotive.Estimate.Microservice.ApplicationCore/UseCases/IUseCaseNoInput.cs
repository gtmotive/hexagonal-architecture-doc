using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for the handler of an use case with no input.
    /// </summary>
    public interface IUseCaseNoInput
    {
        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <returns>Task.</returns>
        Task Execute();
    }
}

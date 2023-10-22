using System.Threading.Tasks;

namespace OrderManager.BuildingBlocks.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
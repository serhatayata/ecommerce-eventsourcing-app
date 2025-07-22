using Common.Domain.EventStores.Repositories;
using Inventory.Domain.Models.Equipments;

namespace Inventory.Domain.Contracts;

public interface IEquipmentRepository : IRepository<Equipment, Guid>
{
    
}
using Common.Domain.EventStores.Repositories;
using Common.Domain.Repositories;
using Inventory.Domain.Models.Equipments;

namespace Inventory.Domain.Contracts;

public interface IEquipmentRepository : IEfRepository<Equipment, Guid>
{
    
}
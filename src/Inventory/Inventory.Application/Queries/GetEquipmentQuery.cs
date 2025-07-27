using Common.Application.Queries;
using Inventory.Domain.Contracts;

namespace Inventory.Application.Queries;

public class GetEquipmentQuery : IQuery<EquipmentResponse>
{
    public Guid Id { get; set; }

    public class GetEquipmentQueryHandler : IQueryHandler<GetEquipmentQuery, EquipmentResponse>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetEquipmentQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<EquipmentResponse> Handle(
        GetEquipmentQuery request,
        CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.Find(request.Id);
    
            if (equipment == null)
                return null;
    
            var response = new EquipmentResponse
            {
                OwnerUserId = equipment.OwnerUserId,
                Name = equipment.Details.Name,
                Description = equipment.Details.Description,
                PricePerDay = equipment.PricePerDay.Amount,
                Currency = equipment.PricePerDay.Currency,
                IsAvailable = equipment.IsAvailable,
                Images = equipment.Images.Select(img => img.Url).ToList()
            };

            return response;
        }
    }
}
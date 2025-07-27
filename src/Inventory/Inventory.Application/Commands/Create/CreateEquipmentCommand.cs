using Common.Application.Commands;
using Inventory.Domain.Contracts;
using Inventory.Domain.Models.Equipments;

namespace Inventory.Application.Commands.Create;

public class CreateEquipmentCommand : ICommand<CreateEquipmentResponse>
{
    public Guid OwnerUserId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal PricePerDay { get; init; }
    public string Currency { get; init; }
    public bool IsAvailable { get; init; }
    public IReadOnlyCollection<string> Images { get; init; }

    public class CreateEquipmentCommandHandler : ICommandHandler<CreateEquipmentCommand, CreateEquipmentResponse>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<CreateEquipmentResponse> Handle(CreateEquipmentCommand command, CancellationToken cancellationToken)
        {
            var equipment = Equipment.Create(
                command.OwnerUserId,
                command.Name,
                command.Description,
                command.PricePerDay,
                command.Currency
            );

            foreach (var image in command.Images)
                equipment.AddImage(image);

            await _equipmentRepository.SaveAsync(equipment);
            return new CreateEquipmentResponse()
            {
                OwnerUserId = command.OwnerUserId,
                Name = command.Name,
                Description = command.Description,
                PricePerDay = command.PricePerDay,
                Currency = command.Currency,
                IsAvailable = command.IsAvailable,
                Images = command.Images
            };
        }
    }
}
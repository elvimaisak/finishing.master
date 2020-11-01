using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;
using Flo.FinishingMaster.Infrastructure.Services;

namespace Flo.FinishingMaster.Data.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;
        private readonly IRoomService roomService;

        public ApartmentService(IApartmentRepository apartmentRepository, IRoomService roomService)
        {
            this.apartmentRepository = apartmentRepository;
            this.roomService = roomService;
        }

        public void Delete(IEnumerable<Guid> ids)
        {
            apartmentRepository.Delete(ids);
        }

        public async Task<Apartment> FindByIdAsync(Guid id)
        {
            return await apartmentRepository.GetByIdAsync(id);
        }

        public async Task<Apartment> UpdateAsync(Apartment entity)
        {
            var apartment = await apartmentRepository.AddOrUpdateAsync(entity);
            await UpdateRooms(entity, apartment);
            return entity;
        }

        private async Task UpdateRooms(Apartment editedApartment, Apartment existingApartment)
        {
            var roomIdsToRemove = existingApartment.Rooms.Select(c => c.Id).Except(editedApartment.Rooms.Select(c => c.Id));

            roomService.Delete(roomIdsToRemove.ToList());

            foreach (var room in editedApartment.Rooms)
            {
                room.ApartmentId = editedApartment.Id;
                await roomService.UpdateAsync(room);
            }
        }
    }
}

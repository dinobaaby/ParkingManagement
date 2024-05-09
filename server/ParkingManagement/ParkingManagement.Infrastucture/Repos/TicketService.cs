﻿

using AutoMapper;
using Microsoft.AspNetCore.Http;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class TicketService : ITicketService
    {
        private readonly IServiceRepo<Ticket, int> _repo;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;


        public TicketService(IServiceRepo<Ticket, int> repo, IMapper mapper, IUploadFileService uploadFileService)
        {
            _repo = repo;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        public async Task<TicketDto> CheckInAsync(int ticketId, string plateNumber, IFormFile file)
        {
            var ticket = await _repo.GetByIdAsync(ticketId);
            ticket.IssueDate = DateTime.Now;
            ticket.TicketStatus = 2;
            ticket.PlateNumber = plateNumber;
            if (file != null)
            {
                ticket.VehicleImage = (await _uploadFileService.UploadFileAsync(file, "Tickets")) ?? "";
            }
            var updatedTicket = await _repo.UpdateAsync(ticket);
            if (updatedTicket != null)
            {
                return _mapper.Map<TicketDto>(updatedTicket);
            }
            return null!;

        }

        public async Task<TicketDto> CheckOutAsync(int ticketId, string plateNumber, string imageUrl)
        {
            var foundTicket = await _repo.GetByIdAsync(ticketId);
            if(foundTicket.PlateNumber == plateNumber)
            {

                foundTicket.TicketStatus = 1;
                foundTicket.PlateNumber = "0";
                
            }

            return _mapper.Map<TicketDto>(foundTicket);
        }

        public async Task<TicketDto> CreateTicketAsync(TicketDto ticketDto, IFormFile file)
        {
            if (file != null)
            {
                ticketDto.VehicleImage = (await _uploadFileService.UploadFileAsync(file, "Tickets")) ?? "";
            }
            ticketDto.IssueDate = DateTime.Now;
            ticketDto.PlateNumber = "";
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var createdTicket = await _repo.CreateAsync(ticket);
            return _mapper.Map<TicketDto>(createdTicket);
        }

        public async Task<TicketDto> DeleteTicketAsync(int ticketId)
        {
            var ticket = await _repo.GetByIdAsync(ticketId);
            if(ticket != null)
            {
                await _repo.DeleteAsync(ticket);
                return _mapper.Map<TicketDto>(ticket);
            }
            return null!;
        }

        public async Task<TicketDto> GetTicketByIdAsync(int ticketId)
        {
            var ticket =await _repo.GetByIdAsync(ticketId);
            if (ticket != null)
            {
                return _mapper.Map<TicketDto>(ticket);
            }
            return null!;
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            var tickets = await _repo.GetAllAsync();
            var result =  tickets.OrderBy(t => t.TicketStatus);
            return _mapper.Map<IEnumerable<TicketDto>>(result);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByPlateNumberAsync(string plateNumber)
        {
            var tickets = await _repo.GetByNameAsync(t => t.PlateNumber.ToLower().Contains(plateNumber.ToLower()));
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsBySlotIdAsync(int slotId)
        {
            var ticket = await _repo.GetByNameAsync(t => t.SlotId == slotId);
            return _mapper.Map<IEnumerable<TicketDto>>(ticket);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByStatusAsync(int ticketStatus)
        {
            var tickets = await _repo.GetByNameAsync(t => t.TicketStatus == ticketStatus);
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByTypeAsync(int ticketType)
        {
            var tickets = await _repo.GetByNameAsync(t => t.TicketTypeId == ticketType);
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<TicketDto> UpdateTicketAsync(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var updatedTicket = await _repo.UpdateAsync(ticket);
            return _mapper.Map<TicketDto>(updatedTicket);

        }
    }
}
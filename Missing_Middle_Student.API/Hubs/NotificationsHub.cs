using Microsoft.AspNetCore.SignalR;
using Missing_Middle_Student.Model;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Model.Models.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Missing_Middle_Student.API.Hubs
{
    public class NotificationsHub : Hub
    {
        private readonly AppDBContext _context;

        public NotificationsHub(AppDBContext appDB)
        {
            _context = appDB;
        }
        public async Task getNotifications()
        {
            var allNotifications = _context.Notifications.ToList();
            await Clients.All.SendAsync("newNotification", allNotifications);
        }

        public async Task NewDeviceAdded(DeviceDTO dev)
        {
            Console.WriteLine("Notification Hub called.");

            // Basic validation
            if (dev == null)
            {
                Console.WriteLine("DeviceDTO is null. Aborting.");
                return;
            }

            if (string.IsNullOrWhiteSpace(dev.Brand) ||
                string.IsNullOrWhiteSpace(dev.Model) ||
                string.IsNullOrWhiteSpace(dev.SerialNumber) ||
                string.IsNullOrWhiteSpace(dev.Condition) ||
                dev.TechnicianId <= 0)
            {
                Console.WriteLine("Invalid DeviceDTO data received:");
                Console.WriteLine($"Brand: {dev.Brand}, Model: {dev.Model}, SerialNumber: {dev.SerialNumber}, Condition: {dev.Condition}, TechnicianId: {dev.TechnicianId}");
                return;
            }

            try
            {
                // Map DTO to Device entity
                var device = new Device
                {
                    Brand = dev.Brand,
                    Model = dev.Model,
                    SerialNumber = dev.SerialNumber,
                    Condition = dev.Condition,
                    Status = "Unallocated",
                    StaffId = dev.TechnicianId
                };

                Console.WriteLine("Adding device to context...");
                await _context.Devices.AddAsync(device);

                // Check if technician exists
                var technician = await _context.Staffs.FindAsync(dev.TechnicianId);
                if (technician != null)
                {
                    var notification = new Notification
                    {
                        CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                        Message = $"Device {device.Brand} : {device.Model} ({device.SerialNumber}) was added by {technician.Initails} {technician.Surname} on {DateOnly.FromDateTime(DateTime.Now)}. Condition of device is {device.Condition}.",
                        Seen = false
                    };

                    Console.WriteLine("Adding notification to context...");
                    await _context.Notifications.AddAsync(notification);
                }
                else
                {
                    Console.WriteLine($"Technician with ID {dev.TechnicianId} not found.");
                }

                Console.WriteLine("Saving changes to database...");
                var savedCount = await _context.SaveChangesAsync();

                Console.WriteLine($"SaveChangesAsync returned: {savedCount}");

                // Confirm device entity state
                var deviceEntryState = _context.Entry(device).State;
                Console.WriteLine($"Device entity state after save: {deviceEntryState}");

                // Send updated notifications to all clients
                var allNotifications = _context.Notifications.ToList();
                await Clients.All.SendAsync("newNotification", allNotifications);

                Console.WriteLine("Notification sent to all clients.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in NewDeviceAdded:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    Console.WriteLine($"Inner StackTrace: {ex.InnerException.StackTrace}");
                }

                // Propagate the error back to the client
                throw;
            }
        }
    }
}

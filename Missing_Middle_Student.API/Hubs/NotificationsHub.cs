
using Microsoft.AspNetCore.SignalR;
using Missing_Middle_Student.Model;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Model.Models.DTOs;

namespace Missing_Middle_Student.API.Hubs
{
    public class NotificationsHub:Hub
    {
        AppDBContext _context;
        public NotificationsHub(AppDBContext appDB )
        {
            _context = appDB;
        }
        public async Task NewDeviceAdded(DeviceDTO dev)
        {
            try
            {
                var device = new Device()
                {
                    Condition = dev.Condition,
                    Brand = dev.Brand,
                    Model = dev.Model,
                    Status = "Unallocated",
                    StaffId = dev.TechnicianId


                };
                var technician = _context.Staffs.Find(dev.TechnicianId);
                if (technician != null)
                {
                    var notification = new Notification()
                    {

                        CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                        Message = $"Device {device.Brand} : {device.Model}({device.SerialNumber}) was  added by {technician.Initails} {technician.Surname}  on {DateOnly.FromDateTime(DateTime.Now)} condition of device is  {device.Condition}",
                        Seen = false

                    };
                    var result = _context.Add<Notification>(notification);
                    _context.SaveChanges();
                }

                var res = _context.Add<Device>(device);
                _context.SaveChanges();

                var devices = _context.Notifications.ToList();
                await Clients.All.SendAsync("newNotificaion", devices);


            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

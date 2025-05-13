using Missing_Middle_Student.Model;
using Missing_Middle_Student.Model.Models;
using Missing_Middle_Student.Model.Models.DTOs;
using Missing_Middle_Student.Model.Models.StaffModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Middle_Student.Services.StaffService
{
    public class StaffService : IStaffService
    {
        readonly AppDBContext _context;
        public StaffService(AppDBContext context)
        {
            _context = context;
        }
        public bool CreateAdmin(StaffDTO staff)
        {
          var found_admin = _context.Staffs.FirstOrDefault(a=>a.Email == staff.Email);
            if(found_admin != null)
            {
                return false;
            }
            else
            {
                try
                {
                    var admin = new Staff()
                    {
                      
                        Email = staff.Email,
                        Contact = staff.Contact,
                        Initails = staff.Initails,
                        Password = staff.Password,
                        Surname = staff.Surname,
                        Role = "Admin"

                    };
                  
                    _context.Add<Staff>(admin);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex) {
                    return false;
                }
              
            }
        }

        public bool CreateTechnician(StaffDTO tech)
        {
            var found_admin = _context.Staffs.FirstOrDefault(a => a.Email == tech.Email);
            if (found_admin != null)
            {
                return false;
            }
            else
            {
                try
                {
                    var technician = new Staff()
                    {
                        
                        Email = tech.Email,
                        Contact = tech.Contact,
                        Initails = tech.Initails,
                        Password = tech.Password,
                        Surname = tech.Surname,
                        Role = "Technician"


                    };
                    _context.Add<Staff>(technician);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        Dictionary<string,int> GetDevicesInfo()
        {
            var devices = _context.Devices.ToList();
            var info = new Dictionary<string, int>();
            if(devices != null)
            {
                info.Add("Total_devices", devices.Count);
                var Unallocated_devices = devices.FindAll(a => a.Status == "Unallocated");
                if(Unallocated_devices != null)
                {
                    info.Add("Unallocated_devices", Unallocated_devices.Count);
                }
                else
                {
                    info.Add("Unallocated_devices", 0);
                }
                var Allocated_devices = devices.FindAll(a => a.Status == "Allocated");
                if (Allocated_devices != null)
                {
                    info.Add("Allocated_devices", Allocated_devices.Count);
                }
                else
                {
                    info.Add("Allocated_devices", 0);
                }
                return info;
            }
            else
            {
                info.Add("Total_devices",0);
                info.Add("Unallocated_devices", 0);
                info.Add("Allocated_devices",0);
                return info;
            }

          
        }

        public AdminResponse? LoginAdmin(LoginDTO staff)
        {
            var found_admin = _context.Staffs.FirstOrDefault(a => a.Password == staff.Password && a.Email == staff.Email);
            if (found_admin != null)
            {
                AdminResponse res = new AdminResponse()
                {
                    Device_Info = this.GetDevicesInfo(),
                    Applicants_Data = ApplicantInfo(),
                    Applicants_Montly_Data = Get_Month_Data()
                };

                return res;
            }
            else
            {
                return null;
            }
        }

        public bool LoginTechnician(LoginDTO staff)
        {
            var found_admin = _context.Staffs.FirstOrDefault(a => a.Password == staff.Password && a.Email == staff.Email);
            if (found_admin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegisterDevice(DeviceDTO dev)
        {
            try
            {
                var device = new Device()
                {
                    Condition = dev.Condition,
                    Brand = dev.Brand,
                    Model = dev.Model,  
                    Status ="Unallocated",
                    StaffId = dev.TechnicianId
                    
                
                };
                var res = _context.Add<Device>(device);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        Dictionary<string, int> Get_Month_Data()
        {
            var montly_applicants = new Dictionary<string, int>();
            var applicants = _context.Applicants.ToList();
            Console.WriteLine($"applicants : {applicants.Count}");
            var months = Months();
            var months_keys = months.Keys.ToList();
            Console.WriteLine(months_keys.Count);
            if (applicants.Count == 0)
            {
                foreach (string month in months_keys)
                {
                    montly_applicants.Add(month, 0);
                }
                Console.WriteLine(montly_applicants);
            }
            if (months_keys != null && applicants.Count > 1)
            {
                foreach (string month in months_keys)
                {
                    Console.WriteLine($"{month}");
                    foreach (Applicant applicant in applicants)
                    {

                        Console.WriteLine(months.TryGetValue(month, out int value));

                        if (applicant.ApplicationDate.Month == value)
                        {
                            if (months.TryGetValue(month, out int num))
                            {
                                var prev_value = num;
                                prev_value++;
                                montly_applicants[month] = prev_value;
                            }
                            else
                            {
                                montly_applicants.Add(month, 1);
                            }


                        }
                        else
                        {
                            montly_applicants.Add(month, 0);
                        }
                    }
                }
            }
          
            return montly_applicants;
        }
        public Dictionary<string, int> ApplicantInfo()
        {
            var applicants = _context.Applicants.ToList();
            var info = new Dictionary<string, int>();
            var montly_applicants = new Dictionary<string, int>();
            if (applicants != null)
            {
                info.Add("Total_Applicants", applicants.Count);
                var Unallocated_devices = applicants.FindAll(a => a.ApplicationStatus == true);
                if (Unallocated_devices != null)
                {
                    info.Add("Approved_Applicants", Unallocated_devices.Count);
                    info.Add("Unapproved_Applicants", (Unallocated_devices.Count - applicants.Count));
                }
                else
                {
                    info.Add("Approved_Applicants", 0);
                    info.Add("Unapproved_Applicants", 0);
                }
                var months = Months();
                var months_keys = months.Keys.ToList();
                if (months_keys != null)
                {
                    foreach (string month in months_keys)
                    {
                        foreach (Applicant applicant in applicants)
                        {
                            months.TryGetValue(month, out int value);
                            if (applicant.ApplicationDate.Month == value)
                            {
                                if (months.TryGetValue(month, out int num))
                                {
                                    var prev_value = num;
                                    prev_value++;
                                    montly_applicants[month] = prev_value;
                                }
                                else
                                {
                                    montly_applicants.Add(month, 1);
                                }


                            }
                            else
                            {
                                montly_applicants.Add(month, 0);
                            }
                        }
                    }
                }
              

                return info;
            }
            else
            {
                info.Add("Total_Applicants", 0);
                info.Add("Approved_Applicants", 0);
                info.Add("Unapproved_Applicants", 0);
             
                return info;
            }
        }
        Dictionary<string, int> Months()
        {
            var months = new Dictionary<string, int>();
            months.Add("Jan", 1);
            months.Add("Feb", 2);
            months.Add("Mar", 3);
            months.Add("Apr", 4);
            months.Add("May", 5);
            months.Add("Jun", 6);
            months.Add("Jul", 7);
            months.Add("Aug", 8);
            months.Add("Sep", 9);
            months.Add("Oct", 10);
            months.Add("Nov", 11);
            months.Add("Dec", 12);
            return months;
        }
    }

}

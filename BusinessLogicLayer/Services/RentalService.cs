using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RentalService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Rental, RentalDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<RentalDTO> Get() 
        {
            var data = DataAccessFactory.RentalData().Get();
            return GetMapper().Map<List<RentalDTO>>(data);
        }
        public static RentalDTO Get(int id) 
        {
            var data = DataAccessFactory.RentalData().Get(id);
            return GetMapper().Map<RentalDTO>(data);
        }

        //public static bool Create(RentalDTO rental) 
        //{
        //    var data = GetMapper().Map<Rental>(rental);
        //    return DataAccessFactory.RentalData().Create(data);
        //}

        public static bool Update(RentalDTO rental) 
        {
            var data = GetMapper().Map<Rental>(rental);
            return DataAccessFactory.RentalData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RentalData().Delete(id);
        }

        public static double EstimateRentalCost(int VehicleId, DateTime Start, DateTime End)
        {
            var vehicle = DataAccessFactory.VehicleData().Get(VehicleId);

            if (vehicle == null) 
                return -1;
            
            int rentalDays = (End - Start).Days + 1;

            if (rentalDays <= 0)
                return -1;

            double estimatedCost = rentalDays * vehicle.DailyRate;

            if (rentalDays > 7)
            {
                estimatedCost *= 0.9;
            }
            return estimatedCost;
        }

        public static double EstimateLateFee(int RentalId, DateTime ActualReturnDate)
        {
            var rental = DataAccessFactory.RentalData().Get(RentalId);

            if (rental == null)
                return -1;

            if (ActualReturnDate <= rental.EndDate)
                return 0;

            int lateDays = (ActualReturnDate - rental.EndDate).Days;

            var vehicle = DataAccessFactory.VehicleData().Get(rental.VehicleId);

            if (vehicle == null)
                return -1;

            double lateFee = lateDays * vehicle.DailyRate * 1.5; 

            return lateFee;
        }

        public static bool Create(RentalDTO rental)
        {
            var data = GetMapper().Map<Rental>(rental);

            var result = DataAccessFactory.RentalData().Create(data);

            if (result)
            {
                try
                {
                    var customer = DataAccessFactory.CustomerData().Get(data.CustomerId);
                    var vehicle = DataAccessFactory.VehicleData().Get(data.VehicleId);

                    var emailService = new EmailService();

                    string subject = $"Rental Confirmation #{data.Id}";
                    string body = $@"
                        <h2>Thank you for renting with us, {customer.Name} Sir!</h2>
                        <p><strong>Vehicle:</strong> {vehicle.Brand} {vehicle.Model} ({vehicle.Year})</p>
                        <p><strong>Start Date:</strong> {data.StartDate:yyyy-MM-dd}</p>
                        <p><strong>End Date:</strong> {data.EndDate:yyyy-MM-dd}</p>
                        <p><strong>Original Cost:</strong> {data.OriginalCost} BDT</p>
                        <p><strong>Discount:</strong> {data.DiscountAmount} BDT</p>
                        <p><strong>Final Cost:</strong> {data.FinalCost} BDT</p>
                        <br>
                        <p>We hope you enjoy your ride!</p>
                    ";

                    bool sent = emailService.SendEmail(customer.Email, subject, body);

                    data.EmailSent = sent;
                    DataAccessFactory.RentalData().Update(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while sending rental summary email: " + ex.Message);
                }
            }

            return result;
        }
    }
}

using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationLayer.Controllers
{
    [RoutePrefix("api/rental")]
    public class RentalController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RentalService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = RentalService.Get(id);
                if (data == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Rental entry not found");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(RentalDTO rental)
        {
            try
            {
                var data = RentalService.Create(rental);
                if (data)
                    return Request.CreateResponse(HttpStatusCode.OK, "Rental entry created successfully");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create rental entry");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = RentalService.Delete(id);
                if (data)
                    return Request.CreateResponse(HttpStatusCode.OK, "Rental entry deleted successfully");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to delete rental entry");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(RentalDTO rental)
        {
            try
            {
                var data = RentalService.Update(rental);
                if (data)
                    return Request.CreateResponse(HttpStatusCode.OK, "Rental entry updated successfully");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update rental entry");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("estimate/cost/{vehicleId}/{start}/{end}")]
        public HttpResponseMessage EstimateRentalCost(int vehicleId, DateTime start, DateTime end)
        {
            try
            {
                var data = RentalService.EstimateRentalCost(vehicleId, start, end);
                if (data == -1)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle not found");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("estimate/costvoucher/{vehicleId}/{start}/{end}/{voucherCode}")]
        public HttpResponseMessage EstimateRentalCostVoucher(int vehicleId, DateTime start, DateTime end, string voucherCode)
        {
            try
            {
                var data = VoucherService.EstimateRentalCostVoucher(vehicleId, start, end, voucherCode);
                if (data == -1)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle not found");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("estimate/latefee/{rentalId}/{actualReturnDate}")]
        public HttpResponseMessage EstimateLateFee(int rentalId, DateTime actualReturnDate)
        {
            try
            {
                var data = RentalService.EstimateLateFee(rentalId, actualReturnDate);
                if (data == -1)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Rental or Vehicle not found");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

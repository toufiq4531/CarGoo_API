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
    [RoutePrefix("api/vehicle")]
    public class VehicleController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = VehicleService.Get();
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
                var data = VehicleService.Get(id);
                if (data == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle not found");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(VehicleDTO vehicle)
        {
            try
            {
                var data = VehicleService.Create(vehicle);
                if (data)
                    return Request.CreateResponse(HttpStatusCode.OK, "Vehicle created successfully");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create vehicle");
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
                var data = VehicleService.Delete(id);
                if (data)
                    return Request.CreateResponse(HttpStatusCode.OK, "Vehicle deleted successfully");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to delete vehicle");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(VehicleDTO vehicle)
        {
            try
            {
                var data = VehicleService.Update(vehicle);
                if (data)
                    return Request.CreateResponse(HttpStatusCode.OK, "Vehicle updated successfully");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update vehicle");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("available/{start}/{end}")]
        public HttpResponseMessage GetAvailableVehicles(DateTime start, DateTime end)
        {
            try
            {
                var data = VehicleService.GetAvailableVehicles(start, end);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("popular")]
        public HttpResponseMessage GetMostPopularVehicles()
        {
            try
            {
                var data = PopularVehicleService.GetMostPopularVehicles();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

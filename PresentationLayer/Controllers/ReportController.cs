using System;
using BusinessLogicLayer.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer.DTOs;

namespace PresentationLayer.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("monthly/{month}")]
        public HttpResponseMessage GetMonthlyRevenue(int month)
        {
            try
            {
                var data = RevenueReportService.GetMonthlyRevenue(month);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("yearly/{year}")]
        public HttpResponseMessage GetYearlyRevenue(int year)
        {
            try
            {
                var data = RevenueReportService.GetYearlyRevenue(year);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

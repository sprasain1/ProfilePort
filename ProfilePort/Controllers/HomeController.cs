﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProfilePort.Data;
using ProfilePort.DataModel;
using ProfilePort.Adapters.Interfaces;
using ProfilePort.Adapters.DataAdapters;
using DashboardPort.Adapters.Interfaces;
using ProfilePort.ViewModels;

namespace DashboardPort.Controllers
{

  
    public class HomeController : ApiController
    {
        IDashboard newDashboard;
        ApplicationDbContext db = new ApplicationDbContext();

        public HomeController()
        {
            newDashboard = new ProfilePort.Adapters.DataAdapters.Dashboards();

        }
          // GET: api/ContactInfos
        public IQueryable<Dashboard> Get()
        {
            return db.Dashboards;
        }

        // GET: api/Dashboard/5
        [ResponseType(typeof(ProfilePort.DataModel.Dashboard))]
        public IHttpActionResult Get(string UserId)
        {
            DashboardVM _myDashboardVM = new DashboardVM();
            _myDashboardVM = newDashboard.GetDashboard(UserId);
         
            if (_myDashboardVM == null)
            {
                return NotFound();
            }

            return Ok(_myDashboardVM);
        }


        // DELETE: api/Dashboard/5
        [ResponseType(typeof(ProfilePort.DataModel.Dashboard))]
        public IHttpActionResult Delete(string id)
        {

            try
            {
                newDashboard.DeleteDashboard(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DashboardExists(string id)
        {
            return db.Dashboards.Count(e => e.Id == id) > 0;
        }
    }
}
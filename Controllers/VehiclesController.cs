using System;
using Microsoft.AspNetCore.Mvc;
using starwars_browser_server.Models;
using Microsoft.EntityFrameworkCore;

namespace starwars_browser_server.Controllers
{
    public class VehiclesController : GenericController
    {
        private readonly DbSet<VehicleItem> _repository;

        public VehiclesController(VehicleContext context) : base(count: 39)
        {
            _repository = context.Vehicles;
        }

        [HttpGet]
        public ActionResult<NameAndId[]> GetVehicles()
        {
            return GetNamesAndIds<VehicleItem>(_repository);
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleItem> GetVehicleById(int id)
        {
            return GetItemById<VehicleItem>(id: id, repository: _repository);
        }
    }
}
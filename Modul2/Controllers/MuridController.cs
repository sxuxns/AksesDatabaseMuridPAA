using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modul2.Models;
using System;

namespace Modul2.Controllers
{
    public class MuridController : Controller
    {
        private string __constr;
        public MuridController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/murid")]
        public ActionResult<Murid> ListMurid()
        {
            MuridContext context = new MuridContext(this.__constr);
            List<Murid> ListMurid = context.ListMurid();
            return Ok(ListMurid);
        }

        [HttpPost("api/murid_auth"), Authorize]
        public ActionResult<Murid> ListMuridWithAuth()
        {
            MuridContext context = new MuridContext(this.__constr);
            List<Murid> ListMurid = context.ListMurid();
            return Ok(ListMurid);
        }

        [HttpPost("api/murid/create")]
        public IActionResult CreateMurid([FromBody] Murid murid)
        {
            MuridContext context = new MuridContext(this.__constr);
            context.AddMurid(murid);
            return Ok("Data murid berhasil ditambahkan");
        }

        [HttpPut("api/murid/update/{id}")]
        public IActionResult UpdateMurid(int id, [FromBody] Murid murid)
        {
            murid.id_murid = id;
            MuridContext context = new MuridContext(this.__constr);
            context.UpdateMurid(murid);
            return Ok("Data murid berhasil diperbarui");
        }

        [HttpDelete("api/murid/delete/{id}")]
        public IActionResult DeleteMurid(int id)
        {
            MuridContext context = new MuridContext(this.__constr);
            context.DeleteMurid(id);
            return Ok("Data murid berhasil dihapus");
        }
    }
}

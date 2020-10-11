using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_VENTAS.Models;
using WS_VENTAS.Models.Response;
using WS_VENTAS.Models.Request;

namespace WS_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            Respuesta Resp = new Respuesta();
            Resp.Exito = 0;

            try
            {
                using (MVC_SEGURIDADContext db = new MVC_SEGURIDADContext())
                {
                    var lst = db.Cliente.OrderByDescending(d=>d.IdCliente).ToList();
                    Resp.Exito = 1;
                    Resp.Data = lst;

                }
            }
            catch (Exception ex) {
                Resp.Mensaje = ex.Message;

            }
            return Ok(Resp);

        }

        /// <summary>
        /// Agrega un cliente
        /// </summary>
        /// <param name="oModeloCliente">Objeto Cliente</param>
        /// <returns></returns>
        [HttpPost]        
        public IActionResult Add(ClienteRequest oModeloCliente) {
            Respuesta oResp = new Respuesta();

            try
            {
                using (MVC_SEGURIDADContext db = new MVC_SEGURIDADContext()) {

                    Cliente oCliente = new Cliente();
                    oCliente.NombreCliente = oModeloCliente.nombreCliente;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();

                    oResp.Exito = 1;
                }
                    
            }
            catch (Exception e) {
                oResp.Mensaje = e.Message;
            }
            return Ok(oResp);

        }

        /// <summary>
        /// Edita un cliente
        /// </summary>
        /// <param name="oModeloCliente"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit(ClienteRequest oModeloCliente)
        {
            Respuesta oResp = new Respuesta();

            try
            {
                using (MVC_SEGURIDADContext db = new MVC_SEGURIDADContext())
                {
                    // SE BUSCA EL ID DEL CLIENTE
                    Cliente oCliente = db.Cliente.Find(oModeloCliente.idCliente);
                    oCliente.NombreCliente = oModeloCliente.nombreCliente;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResp.Exito = 1;
                }

            }
            catch (Exception e)
            {
                oResp.Mensaje = e.Message;
            }
            return Ok(oResp);

        }

        /// <summary>
        /// Elimina un Cliente
        /// </summary>
        /// <param name="ID">Id del cliente a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public IActionResult Edit(int ID)
        {
            Respuesta oResp = new Respuesta();

            try
            {
                using (MVC_SEGURIDADContext db = new MVC_SEGURIDADContext())
                {
                    // SE BUSCA EL ID DEL CLIENTE
                    Cliente oCliente = db.Cliente.Find(ID);
                    db.Remove(oCliente);
                    db.SaveChanges();

                    oResp.Exito = 1;
                }

            }
            catch (Exception e)
            {
                oResp.Mensaje = e.Message;
            }
            return Ok(oResp);

        }


    }
}

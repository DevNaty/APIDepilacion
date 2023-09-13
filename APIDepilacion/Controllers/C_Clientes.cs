using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using APIDepilacion.Models;

namespace APIDepilacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_Clientes : ControllerBase
    {
        public readonly BdDepilacionContext _bdDepilacionContext;
        public C_Clientes(BdDepilacionContext _context)
        {
            _bdDepilacionContext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Clientes> lista = new List<Clientes>();
            try
            {
                lista = _bdDepilacionContext.Clientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }
        [HttpGet]
        [Route("Obtener/{ID_Cliente}")]

        public IActionResult Obtener(int ID_Cliente)
        {
            Clientes oCliente = _bdDepilacionContext.Clientes.Find(ID_Cliente);
            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }
            try
            {
                oCliente = _bdDepilacionContext.Clientes.Find(ID_Cliente);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCliente });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCliente });

            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Clientes objeto)
        {
            try
            {
                _bdDepilacionContext.Clientes.Add(objeto);
                _bdDepilacionContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Clientes objeto)
        {
            Clientes oCliente = _bdDepilacionContext.Clientes.Find(objeto.IdCliente);
            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }
            try
            {

                oCliente.Nombre = objeto.Nombre is null ? oCliente.Nombre : objeto.Nombre.ToString();
                oCliente.Apellido = objeto.Apellido is null ? oCliente.Apellido : objeto.Apellido.ToString();
                oCliente.Telefono = objeto.Telefono is null ? oCliente.Telefono : objeto.Telefono.ToString();



                _bdDepilacionContext.Clientes.Update(oCliente);
                _bdDepilacionContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RR_SYSTEM.Models;

namespace RR_SYSTEM.Controllers
{
    public class EmpleadoesController : Controller
    {
        private readonly RrpayrollDbaContext _context;

        public EmpleadoesController(RrpayrollDbaContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var rrpayrollDbaContext = _context.Empleados.Include(e => e.CreadoPorNavigation).Include(e => e.IdContratoFkNavigation).Include(e => e.IdEstadoFkNavigation).Include(e => e.IdMunicipioFkNavigation).Include(e => e.IdNacionalidadFkNavigation).Include(e => e.IdPuestoFkNavigation).Include(e => e.ModifcadoPorNavigation);
            return View(await rrpayrollDbaContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.CreadoPorNavigation)
                .Include(e => e.IdContratoFkNavigation)
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdMunicipioFkNavigation)
                .Include(e => e.IdNacionalidadFkNavigation)
                .Include(e => e.IdPuestoFkNavigation)
                .Include(e => e.ModifcadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdContratoFk"] = new SelectList(_context.Contratos, "IdContrato", "IdContrato");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "IdEstado");
            ViewData["IdMunicipioFk"] = new SelectList(_context.Municipios, "IdMunicipio", "Nombre");
            ViewData["IdProvinciaFk"] = new SelectList(_context.Provincias, "IdProvincia", "Nombre");
            ViewData["IdNacionalidadFk"] = new SelectList(_context.Nacionalidades, "IdNacionalidad", "Nombre");
            ViewData["IdPuestoFk"] = new SelectList(_context.Puestos, "IdPuesto", "Nombre");
            ViewData["ModifcadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,Nombre,Apellido,FechaNacimiento,Cedula,Direccion,Celular,Telefono,Email,Sexo,Codigo,NumDeCuenta,FechaCreacion,IdNacionalidadFk,IdMunicipioFk,IdPuestoFk,IdContratoFk,IdEstadoFk,CreadoPor,ModifcadoPor")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.FechaCreacion = DateTime.Now;

                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", empleado.CreadoPor);
            ViewData["IdContratoFk"] = new SelectList(_context.Contratos, "IdContrato", "IdContrato", empleado.IdContratoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", empleado.IdEstadoFk);
            ViewData["IdMunicipioFk"] = new SelectList(_context.Municipios, "IdMunicipio", "Nombre", empleado.IdMunicipioFk);
            ViewData["IdNacionalidadFk"] = new SelectList(_context.Nacionalidades, "IdNacionalidad", "Nombre", empleado.IdNacionalidadFk);
            ViewData["IdPuestoFk"] = new SelectList(_context.Puestos, "IdPuesto", "Nombre", empleado.IdPuestoFk);
            ViewData["ModifcadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", empleado.ModifcadoPor);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", empleado.CreadoPor);
            ViewData["IdContratoFk"] = new SelectList(_context.Contratos, "IdContrato", "IdContrato", empleado.IdContratoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", empleado.IdEstadoFk);
            ViewData["IdMunicipioFk"] = new SelectList(_context.Municipios, "IdMunicipio", "IdMunicipio", empleado.IdMunicipioFk);
            ViewData["IdNacionalidadFk"] = new SelectList(_context.Nacionalidades, "IdNacionalidad", "IdNacionalidad", empleado.IdNacionalidadFk);
            ViewData["IdPuestoFk"] = new SelectList(_context.Puestos, "IdPuesto", "IdPuesto", empleado.IdPuestoFk);
            ViewData["ModifcadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", empleado.ModifcadoPor);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Apellido,FechaNacimiento,Cedula,Direccion,Celular,Telefono,Email,Sexo,Codigo,NumDeCuenta,FechaCreacion,IdNacionalidadFk,IdMunicipioFk,IdPuestoFk,IdContratoFk,IdEstadoFk,CreadoPor,ModifcadoPor")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", empleado.CreadoPor);
            ViewData["IdContratoFk"] = new SelectList(_context.Contratos, "IdContrato", "IdContrato", empleado.IdContratoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", empleado.IdEstadoFk);
            ViewData["IdMunicipioFk"] = new SelectList(_context.Municipios, "IdMunicipio", "IdMunicipio", empleado.IdMunicipioFk);
            ViewData["IdNacionalidadFk"] = new SelectList(_context.Nacionalidades, "IdNacionalidad", "IdNacionalidad", empleado.IdNacionalidadFk);
            ViewData["IdPuestoFk"] = new SelectList(_context.Puestos, "IdPuesto", "IdPuesto", empleado.IdPuestoFk);
            ViewData["ModifcadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", empleado.ModifcadoPor);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.CreadoPorNavigation)
                .Include(e => e.IdContratoFkNavigation)
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdMunicipioFkNavigation)
                .Include(e => e.IdNacionalidadFkNavigation)
                .Include(e => e.IdPuestoFkNavigation)
                .Include(e => e.ModifcadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'RrpayrollDbaContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }
    }
}

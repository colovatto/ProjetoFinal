using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal;

namespace ProjetoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ServiceDeskContext _context;

        public UsuariosController(ServiceDeskContext context)
        {
            _context = context; //declara a variavel do db
        }

        //Search Method
        public async Task<IActionResult> Index(string search, int? Id)
        {
            if (_context.Usuarios == null)
            {
                Problem("Entity set 'ServiceDeskContext.Usuarios'  is null.");
            }

            var usuarios = from u in _context.Usuarios select u; //selecionar usuários

            if (Id.HasValue)
            {
                var ticketsId = Id.Value;
                usuarios = usuarios.Where(s => s.UserId == ticketsId);
            }

            if (!String.IsNullOrEmpty(search))
            {
                usuarios = usuarios.Where(s => s.UserNome!.Contains(search) || s.UserLogin!.Contains(search)); //consulta por categoria
            }

            return View(await usuarios.ToListAsync());


        }

        [HttpPost]
        public string Index(string search, bool notUsed)
        {
            return "From[HttpPost]Index: filter on " + search;
        }

        


        // Exibir Get
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // Criar Get
        public IActionResult Create()
        {
            return View();
        }

        // Criar Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserNome,UserLogin,UserSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // Editar Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Editar Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserNome,UserLogin,UserSenha")] Usuario usuario)
        {
            if (id != usuario.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UserId))
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
            return View(usuario);
        }

        // Deletar Get
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // Deletar Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ServiceDeskContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}

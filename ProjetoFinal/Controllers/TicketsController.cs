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
    public class TicketsController : Controller
    {
        private readonly ServiceDeskContext _context;

        public TicketsController(ServiceDeskContext context)
        {
            _context = context;
        }

        //Search Method
       
        public async Task<IActionResult> Index(string search, int? Id)
        {
              if(_context.Tickets == null)
              {
                 Problem("Entity set 'ServiceDeskContext.Tickets'  is null.");
              }

            var tickets = from t in _context.Tickets select t; //selecionar tickets

            if(Id.HasValue)
            {
                var ticketsId = Id.Value;
                tickets = tickets.Where(s => s.TicketId == ticketsId); //procura por Id
            }

            if (!String.IsNullOrEmpty(search))
            {
                tickets = tickets.Where(s => s.TicketCategoria!.Contains(search) || s.TicketNome!.Contains(search)); //consulta pelos parametros estabelecidos
            }
            
            return View(await tickets.ToListAsync()); //apresenta o tickt

        }

        [HttpPost]
        public string Index(string search, bool notUsed)
        {
            return "From[HttpPost]Index: filter on " + search;
        }

        // Exibir Get
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tickets == null) //compara se não apresenta Id
            {
                return NotFound(); //apresenta nenhuma opção
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketId == id); //mostra o primeiro ticket com o Id selecionado
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // Criar Get
        public IActionResult Create()
        {
            return View();
        }

        // Criar Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,TicketNome,TicketEmail,TicketTel,TicketHora,TicketEvidencia,TicketCategoria,TicketDescricao")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {             
                _context.Add(ticket); //adiciona os dados a table ticket
                await _context.SaveChangesAsync(); //salva dados
                return RedirectToAction(nameof(Index)); //retorna a Index da controller
            }
            return View(ticket);
        }

        // Editar Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);  //busca pelo Id selecionado
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }


        // Editar Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,TicketNome,TicketEmail,TicketTel,TicketHora,TicketEvidencia,TicketCategoria,TicketDescricao")] Ticket ticket)
        {
            if (id != ticket.TicketId) //se id for diferente do Ticket selecionado
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            return View(ticket);
        }

        // Deletar Get
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // Deletar Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tickets == null) //Se ticket não existir
            {
                return Problem("Entity set 'ServiceDeskContext.Tickets'  is null.");
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null) //caso diferente de nulo
            {
                _context.Tickets.Remove(ticket); //remove do banco
            }
            
            await _context.SaveChangesAsync(); //salva as opções
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
          return (_context.Tickets?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }
    }
}

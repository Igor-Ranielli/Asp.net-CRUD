using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PIM_VIII_CRUD.Data;
using PIM_VIII_CRUD.Models;

namespace PIM_VIII_CRUD.Controllers
{
    public class PessoasController : Controller
    {

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            PessoaDAO dbContext = new PessoaDAO();

            return View(await dbContext.Pessoa.Find(u => true).ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PessoaDAO dbContext = new PessoaDAO();
            var pessoa = await dbContext.Pessoa.Find(u => u.Id == id).FirstOrDefaultAsync();

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Logradouro,Numero,Cep,Bairro,Cidade,Estado,Telefone,Ddd,TipoTelefone")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                PessoaDAO dbContext = new PessoaDAO();
                pessoa.Id = Guid.NewGuid();
                await dbContext.Pessoa.InsertOneAsync(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PessoaDAO dbContext = new PessoaDAO();
            var pessoa = await dbContext.Pessoa.Find(u => u.Id == id).FirstOrDefaultAsync();

            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Cpf,Logradouro,Numero,Cep,Bairro,Cidade,Estado,Telefone,Ddd,TipoTelefone, telefone")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PessoaDAO dbContext = new PessoaDAO();

                    await dbContext.Pessoa.ReplaceOneAsync(m => m.Id == pessoa.Id, pessoa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PessoaDAO dbContext = new PessoaDAO();
            var pessoa = await dbContext.Pessoa.Find(u => u.Id == id).FirstOrDefaultAsync();

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            PessoaDAO dbContext = new PessoaDAO();

            await dbContext.Pessoa.DeleteOneAsync(u => u.Id == id);

            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(Guid id)
        {
            PessoaDAO dbContext = new PessoaDAO();
            var pessoa = dbContext.Pessoa.Find(u => u.Id == id).Any();

            return pessoa;
        }
    }
}
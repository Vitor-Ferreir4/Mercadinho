using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Varejo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Varejo.Pages.Produtos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produto Produto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Produto = await _context.Produtos.FindAsync(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var produtoFromDb = await _context.Produtos.FindAsync(Produto.IdProduto);

            if (produtoFromDb == null)
            {
                return NotFound();
            }

            produtoFromDb.NomeProduto = Produto.NomeProduto;
            produtoFromDb.Preco = Produto.Preco;
            produtoFromDb.QuantidadeEstoque = Produto.QuantidadeEstoque;
            produtoFromDb.NomeCategoria = Produto.NomeCategoria;
            produtoFromDb.Fornecedor = Produto.Fornecedor;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(Produto.IdProduto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProduto == id);
        }
    }
}

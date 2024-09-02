using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Varejo.Models;
using System.Threading.Tasks;

namespace Varejo.Pages.Produtos
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            if (Produto == null)
            {
                return NotFound();
            }

            var produtoToDelete = await _context.Produtos.FindAsync(Produto.IdProduto);

            if (produtoToDelete == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtoToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}

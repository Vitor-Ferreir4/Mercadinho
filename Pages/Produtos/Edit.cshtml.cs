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

        // Método GET para exibir o formulário de edição
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Produto = await _context.Produtos.FindAsync(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Método POST para salvar as alterações
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar o produto existente
            var produtoFromDb = await _context.Produtos.FindAsync(Produto.IdProduto);

            if (produtoFromDb == null)
            {
                return NotFound();
            }

            // Atualizar as propriedades
            produtoFromDb.NomeProduto = Produto.NomeProduto;
            produtoFromDb.Preco = Produto.Preco;
            produtoFromDb.QuantidadeEstoque = Produto.QuantidadeEstoque;
            produtoFromDb.NomeCategoria = Produto.NomeCategoria;
            produtoFromDb.Fornecedor = Produto.Fornecedor;

            try
            {
                // Salvar alterações no banco de dados
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

            // Redirecionar para a página de índice (ou qualquer outra página que desejar)
            return RedirectToPage("../Index");
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.IdProduto == id);
        }
    }
}

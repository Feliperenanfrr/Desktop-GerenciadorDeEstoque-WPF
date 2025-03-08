using Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces;
using Desktop_GerenciadorDeEstoque_WPF.Data;
using Desktop_GerenciadorDeEstoque_WPF.Core.Model;  

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext _context;

        // Construtor que recebe DbContext via injeção de dependência
        public MaterialService(AppDbContext context)
        {
            _context = context;
        }

        public List<Material> ListarMateriais()
        {
            return _context.Materiais.ToList();
        }

        public void CriarMaterial(Material material)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material));

            _context.Materiais.Add(material);
            _context.SaveChanges();
        }

        public void AtualizarMaterial(Material material)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material));

            var materialExistente = _context.Materiais.Find(material.Id);
            if (materialExistente == null)
                throw new InvalidOperationException($"Material {material.Id} não existente");

            materialExistente.Nome = material.Nome;
            materialExistente.Preco = material.Preco;
            materialExistente.Quantidade = material.Quantidade;
            materialExistente.DataDeCompra = material.DataDeCompra;

            _context.SaveChanges();
        }

        public void ExcluirMaterial(int id)
        {
            var materialExistente = _context.Materiais.Find(id);
            if (materialExistente == null)
                throw new InvalidOperationException($"Material {id} não existente");

            _context.Materiais.Remove(materialExistente);
            _context.SaveChanges();
        }

        public Material BuscarMaterialPorId(int id)
        {
            var materialExistente = _context.Materiais.Find(id);
            if (materialExistente == null)
                throw new InvalidOperationException($"Material {id} não existente");

            return materialExistente;
        }
    }
}

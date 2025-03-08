using Desktop_GerenciadorDeEstoque_WPF.Core.Model;

namespace Desktop_GerenciadorDeEstoque_WPF.Core.Services.Interfaces
{
    public interface IMaterialService
    {
        List<Material> ListarMateriais();
        void CriarMaterial(Material material);
        void AtualizarMaterial(Material material);
        void ExcluirMaterial(int id);
        Material BuscarMaterialPorId(int id);
    }
}
using AprendizadoVerticalSlice.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterCategoriaPorId;

public class ObterCategoriaPorIdHandler
{
    private readonly BancoDeDados _banco;

    public ObterCategoriaPorIdHandler(BancoDeDados banco)
    {
        _banco = banco;
    }

    public async Task<CategoriaResposta?> Executar(int id)
    {
        var categoria = await _banco.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoria is null)
            return null;

        return new CategoriaResposta(categoria.Id, categoria.Nome, categoria.Descricao);
    }
}

public record CategoriaResposta(int Id, string Nome, string? Descricao);

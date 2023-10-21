using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repositories;

public interface IOrganizadorRepository
{
    public List<Tarefa> ObterTodasAsTarefas();
    public Tarefa ObterTarefaPorId(int id);
    public List<Tarefa> ObterTarefaPorStatus(EnumStatusTarefa status);
    public List<Tarefa> ObterTarefaPorTitulo(string titulo);
    public List<Tarefa> ObterTarefaPorData(DateTime data);
    public bool VerificarTarefaId(int id);
    public Tarefa CriarTarefa(Tarefa tarefa);
    public Tarefa AtualizarTarefaPorId(int id, Tarefa tarefa);
    public Tarefa DeletarTarefaPorId(int id);
}
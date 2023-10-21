using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repositories;

public class OrganizadorRepository : IOrganizadorRepository
{
    private readonly OrganizadorContext _context;
    public OrganizadorRepository(OrganizadorContext context)
    {
        _context = context;
    }
    public Tarefa AtualizarTarefaPorId(int id, Tarefa tarefa)
    {
        var tarefaParaAtualizar = ObterTarefaPorId(id);
        if (tarefaParaAtualizar is null) return null;
        if (id != tarefa.Id) return null;

        tarefaParaAtualizar.Titulo = tarefa.Titulo;
        tarefaParaAtualizar.Descricao = tarefa.Descricao;
        tarefaParaAtualizar.Status = tarefa.Status;
        tarefaParaAtualizar.Data = tarefa.Data;

        _context.Tarefas.Update(tarefaParaAtualizar);
        _context.SaveChanges();

        return tarefa;
    }

    public Tarefa CriarTarefa(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();

        return tarefa;
    }

    public Tarefa DeletarTarefaPorId(int id)
    {
        var tarefa = ObterTarefaPorId(id);

        if (tarefa == null) return null;

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();

        return tarefa;
    }

    public List<Tarefa> ObterTarefaPorData(DateTime data)
    {
        return _context.Tarefas.Where(t => t.Data.Date == data.Date).ToList();
    }

    public Tarefa ObterTarefaPorId(int id)
    {
        if (!VerificarTarefaId(id)) return null;

        return _context.Tarefas.Find(id);
    }

    public List<Tarefa> ObterTarefaPorStatus(EnumStatusTarefa status)
    {
        return _context.Tarefas.Where(t => t.Status == status).ToList();
    }

    public List<Tarefa> ObterTarefaPorTitulo(string titulo)
    {
        return _context.Tarefas.Where(t => t.Titulo == titulo).ToList();
    }

    public List<Tarefa> ObterTodasAsTarefas()
    {
        return _context.Tarefas.ToList();
    }

    public bool VerificarTarefaId(int id)
    {
        return _context.Tarefas.FirstOrDefault(t => t.Id == id) != null;
    }
}
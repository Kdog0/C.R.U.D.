using prova.models;

namespace prova.Repositorio.Interface
{
    public interface IAluno
    {
        Task<Aluno> Adcionar(Aluno aluno);
        Task<List<Aluno>> AlunosTodos();
        Task<Aluno> AlunoId(int id);
        Task<Aluno> AlunoUpdate(Aluno aluno, int id);
        Task<bool> AlunoDelete(int id);
    }
}

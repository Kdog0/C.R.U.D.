using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prova.Data;
using prova.models;
using prova.Repositorio.Interface;

namespace prova.Repositorio
{
    public class RepositorioAluno : IAluno
    {
        protected readonly Context _context;

        public RepositorioAluno(Context context)
        {
            _context = context;
        }


        public async Task<Aluno> Adcionar([FromBody] Aluno aluno)
        { 
            if (aluno == null) { throw new ArgumentNullException("Nao existe Corpo de Requisao"); }
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<bool> AlunoDelete(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);  
            if (aluno == null) { throw new ArgumentNullException("Usuariao nao encontrado"); }
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;

        }

        public Task<Aluno> AlunoId(int id)
        {
            return _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Aluno>> AlunosTodos()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> AlunoUpdate(Aluno aluno, int id)
        {
            Aluno _aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if (_aluno == null) throw new ArgumentNullException("Usuariao nao encontrado");
            if (aluno.Name == null)
            {
                _aluno.Name = _aluno.Name;
            }
            else
            {
                _aluno.Name = aluno.Name;
            }
            _aluno.Nota = aluno.Nota;
            _context.Alunos.Update(_aluno);
            await _context.SaveChangesAsync();
            return _aluno;


        }
    }
}

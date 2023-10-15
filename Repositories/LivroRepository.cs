using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter_API.Contexts;
using Chapter_API.Models;


namespace Chapter_API.Repositories
{
    public class LivroRepository
    {
        private readonly ChapterContext _context;

        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livroBuscado = _context.Livros.Find(id);
            
            if(livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }
            _context.Livros.Update(livroBuscado);
            _context.SaveChanges();
        }

        public void Cadastrar(Livro livro)
        {
            //Adciona o novo livro
            _context.Livros.Add(livro);

            //salva
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            //busca
            Livro livroBuscado = _context.Livros.Find(id);
            //remover id
            _context.Livros.Remove(livroBuscado);
            _context.SaveChanges();
        }
    }
}
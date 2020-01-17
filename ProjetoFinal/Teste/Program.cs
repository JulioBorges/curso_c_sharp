using ProjetoFinal.Dominio;
using ProjetoFinal.Dominio.Enums;
using ProjetoFinal.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Teste
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var contexto = new ProjetoFinalContexto())
            {
                // var query = contexto.Usuarios;

                //CrudBasico(contexto, query);

                //var usuarios = GerarUsuariosAleatorios();

                //InserirListaUsuarios(usuarios, contexto);

                PesquisaEspecificaWhere(contexto);

                Console.Read();
            }
        }

        private static void PesquisaEspecificaWhere(ProjetoFinalContexto contexto)
        {
            Stopwatch cronometro = Stopwatch.StartNew();

            var query = contexto.Usuarios.AsNoTracking();
            
            var dados = query
                .Where(filtro => filtro.Conectado == false &&
                                 filtro.Nome.EndsWith("3"));

            var primeiro = dados.First();
            Console.WriteLine(primeiro.Nome);

            var nomes = dados.Select(slt => slt.Nome);

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var nomesEStatus = dados.Select(slt => new
            {
                slt.Nome,
                slt.Conectado
            });

            foreach (var obj in nomesEStatus)
            {
                Console.WriteLine($"{obj.Nome} - {obj.Conectado}");
            }

            Console.WriteLine(dados.Count());
            cronometro.Stop();
            Console.WriteLine($"Executou em: {cronometro.Elapsed}");
        }

        private static void InserirListaUsuarios(IEnumerable<Usuario> usuarios,
            ProjetoFinalContexto contexto)
        {
            contexto.Usuarios.AddRange(usuarios);
            contexto.SaveChanges();
        }

        private static IEnumerable<Usuario> GerarUsuariosAleatorios()
        {
            for (int i = 1; i <= 100; i++)
            {
                yield return new Usuario
                {
                    Nome = $"Teste{i}",
                    Senha = $"{i}",
                    Conectado = false
                };
            }
        }

        private static void CrudBasico(ProjetoFinalContexto contexto, DbSet<Usuario> query)
        {
            var usuarioNovo = InserirUsuario(contexto, query);

            ListarUsuarios(query);
            Update(contexto, usuarioNovo);
            RemoverUsuario(contexto, usuarioNovo);
        }

        private static void Update(ProjetoFinalContexto contexto, Usuario usuarioNovo)
        {
            usuarioNovo.Nome = "Julio123";
            usuarioNovo.Conectado = true;

            contexto.Entry(usuarioNovo).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        private static void RemoverUsuario(ProjetoFinalContexto contexto, Usuario usuarioNovo)
        {
            contexto.Usuarios.Remove(usuarioNovo);
            contexto.SaveChanges();
        }

        private static Usuario InserirUsuario(ProjetoFinalContexto contexto, DbSet<Usuario> query)
        {
            var usuarioNovo = new Usuario
            {
                Nome = "Julio",
                Senha = "123456",
                Conectado = false
            };

            query.Add(usuarioNovo);
            contexto.SaveChanges();
            
            return usuarioNovo;
        }

        private static void ListarUsuarios(DbSet<Usuario> query)
        {
            var usuarios = query.ToList();

            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.Nome);
            }
        }
    }
}
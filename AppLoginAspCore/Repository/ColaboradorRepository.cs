using AppLoginAspCore.Models;
using AppLoginAspCore.Repositories.Contracts;

namespace AppLoginAspCore.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        // Propriedade Privada para injetar a conexão com o banco de dados ;
        private readonly string _conexaoMySQL;

        //Metodo construtor da classe ColaboradorRepository    
        public ColaboradorRepository(IConfiguration conf)
        {
            // Injeção de dependencia do banco de dados
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public Colaborador Login(string Email, string Senha)
        {
            throw new NotImplementedException();
        }
        public void Atualizar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

       

        public Colaborador ObterColaborador(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ObterColaboradorPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            throw new NotImplementedException();
        }
    }
}

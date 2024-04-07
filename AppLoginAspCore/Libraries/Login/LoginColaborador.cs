namespace AppLoginAspCore.Libraries.Login
{
    public class LoginColaborador
    {
        // Criar uma chave para a sessão
        private string Key = "Login.Colaborador";
        private Sessao.Sessao _sessao;
        //Injetar sessão na classe LoginColaborador
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }
    }
}

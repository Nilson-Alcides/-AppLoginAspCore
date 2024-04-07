namespace AppLoginAspCore.Libraries.Sessao
{
    public class Sessao
    {
        //Interface com um biblioteca para manipular a sessão
        IHttpContextAccessor _context;
        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

    }
}

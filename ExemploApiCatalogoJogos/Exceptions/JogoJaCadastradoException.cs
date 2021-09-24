using System;

namespace ExemploApiCatalogoJogos.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
#pragma warning disable CS0108 // "JogoJaCadastradoException.Message" oculta o membro herdado "Exception.Message". Use a nova palavra-chave se foi pretendido ocultar.
        private const string Message = "Este já jogo está cadastrado";
#pragma warning restore CS0108 // "JogoJaCadastradoException.Message" oculta o membro herdado "Exception.Message". Use a nova palavra-chave se foi pretendido ocultar.

        public JogoJaCadastradoException()
            : base(Message)
        { }
    }
}

using System;

namespace ExpressoesLambdaDelegates
{
    public class Processamento
    {
        private Action<string> _exibeMensagem;

        public Processamento(Action<string> exibeMensagem)
        {
            _exibeMensagem = exibeMensagem;
        }

        public void Processar(int qtdInteracoes)
        {
            _exibeMensagem("Estou processando os seus dados");

            int count = qtdInteracoes;
            while (count >= 0)
            {
                _exibeMensagem($"Processei a {count} vez");
                count--;
            }

            _exibeMensagem("Processei tudo");
        }
    }
}
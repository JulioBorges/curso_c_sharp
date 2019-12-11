namespace Heranca
{
    public class Encapsulamento
    {
        private int privado;
        internal int Interno;
        
        public int Publico;

        public int PropriedadePublica { get; private set; }

        protected string protegido;

        public Encapsulamento(int propPub)
        {
            this.PropriedadePublica = propPub;
        }
    }
}

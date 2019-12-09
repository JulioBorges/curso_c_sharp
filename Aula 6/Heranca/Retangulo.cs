namespace Heranca
{
    internal class Retangulo
    {
        protected int m_largura;
        protected int m_altura;

        public virtual void setLargura(int largura)
        { m_largura = largura; }

        public virtual void setAltura(int altura)
        { m_altura = altura; }

        public int getLargura()
        { return m_largura; }

        public int getAltura()
        { return m_altura; }

        public int getArea()
        { return m_largura * m_altura; }
    }

    internal class Quadrado : Retangulo
    {
        public override void setLargura(int largura)
        {
            m_largura = largura;
            m_altura = largura;
        }

        public override void setAltura(int altura)
        {
            m_largura = altura;
            m_altura = altura;
        }
    }
}
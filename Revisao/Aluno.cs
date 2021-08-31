namespace Revisao
{
    public struct Aluno //ele poderia ser uma class mas por se tratar de algo muito simples (nao estar atrelado ao banco...) está usando struct
    {
        public string Nome { get; set;}
        public decimal Nota { get; set;}
    }
}
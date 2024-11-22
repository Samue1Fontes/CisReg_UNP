namespace CisReg_Website.Models
{
    public class UnpSupModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? NumeroFuncionario { get; set; }
        //public List<Atendimento> HistoricoAtendimentos { get; set; }
        public string? NivelAcesso { get; set; }
    }
}

namespace Localiza.Dominio.Entidades
{
    public class Veiculo : Entidade
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string CodChassi { get; set; }
        public string CodRenavan { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string NomeArquivo { get; set; }

        public Veiculo()
        {
        }

        public Veiculo(string placa, string codChassi, string codRenavan, string marca, string modelo)
        {
            Placa = placa;
            CodChassi = codChassi;
            CodRenavan = codRenavan;
            Marca = marca;
            Modelo = modelo;
        }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Placa))
                AdicionarCritica("A PLACA do veículo não pode ficar vazio");
            if (string.IsNullOrEmpty(CodChassi))
                AdicionarCritica("O CHASSI do veículo não pode ficar vazio");
            if (string.IsNullOrEmpty(CodRenavan))
                AdicionarCritica("O RENAVAN do veículo não pode ficar vazio");
            if (string.IsNullOrEmpty(Marca))
                AdicionarCritica("A MARCA do veículo não pode ficar vazio");
            if (string.IsNullOrEmpty(Modelo))
                AdicionarCritica("O MODELO do veículo não pode ficar vazio");
            if(Ano == 0)
                AdicionarCritica("O ANO do veículo não pode ficar vazio");


        }
    }
}

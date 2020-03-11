using ListagemFornecedores.Infra;

namespace ListagemFornecedores.Enums
{
    public class UFEnum : BaseEnum<UFEnum, string>
    {

        public string Nome { get; private set;}
        public static readonly UFEnum AC = new UFEnum(1, "AC", "Acre");
        public static readonly UFEnum AL = new UFEnum(2, "AL", "Alagoas");
        public static readonly UFEnum AP = new UFEnum(3, "AP", "Amapá");
        public static readonly UFEnum AM = new UFEnum(4, "AM", "Amazonas");
        public static readonly UFEnum BA = new UFEnum(5, "BA", "Bahia");
        public static readonly UFEnum CE = new UFEnum(6, "CE", "Ceará");
        public static readonly UFEnum DF = new UFEnum(7, "DF", "Distrito Federal");
        public static readonly UFEnum GO = new UFEnum(8, "GO", "Goías");
        public static readonly UFEnum MA = new UFEnum(9, "MA", "Maranhão");
        public static readonly UFEnum MT = new UFEnum(10, "MT", "Mato Grosso");
        public static readonly UFEnum MS = new UFEnum(11, "MS", "Mato Grosso do Sul");
        public static readonly UFEnum MG = new UFEnum(12, "MG", "Minas Gerais");
        public static readonly UFEnum PA = new UFEnum(13, "PA", "Pará");
        public static readonly UFEnum PB = new UFEnum(14, "PB", "Paraíba");
        public static readonly UFEnum PR = new UFEnum(15, "PR", "Paraná");
        public static readonly UFEnum PE = new UFEnum(16, "PE", "Pernambuco");
        public static readonly UFEnum PI = new UFEnum(17, "PI", "Piauí");
        public static readonly UFEnum RJ = new UFEnum(18, "RJ", "Rio de Janeiro");
        public static readonly UFEnum RN = new UFEnum(19, "RN", "Rio Grande do Norte");
        public static readonly UFEnum RS = new UFEnum(20, "RS", "Rio Grande do Sul");
        public static readonly UFEnum RO = new UFEnum(21, "RO", "Roraima");
        public static readonly UFEnum RR = new UFEnum(22, "RR", "Rondônia");
        public static readonly UFEnum SC = new UFEnum(23, "SC", "Santa Catarina");
        public static readonly UFEnum SP = new UFEnum(24, "SP", "São Paulo");
        public static readonly UFEnum SE = new UFEnum(25, "SE", "Sergipe");
        public static readonly UFEnum TO = new UFEnum(26, "TO", "Tocantins");
        public static readonly UFEnum ES = new UFEnum(27, "ES", "Espírito Santo");

        protected UFEnum(int codigo, string valor, string nome) : base(codigo, valor)
        {

            Nome = nome;
        }
    }
}
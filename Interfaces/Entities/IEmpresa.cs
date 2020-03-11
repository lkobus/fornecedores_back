namespace Interfaces.Entities
{
    public interface IEmpresa : IEntity
    {        
        int UF { get; }
        string NomeFantasia {get;}
        string CNPJ {get;}
        
    }
}
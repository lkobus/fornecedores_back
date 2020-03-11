using System;
using System.Runtime.Serialization;
using Interfaces.Entities;

namespace ListagemFornecedores.Builders
{
    public class BaseBuilder<T> 
            where T : IEntity         
    {
        public T Instance { get; protected set;}        

    }
}
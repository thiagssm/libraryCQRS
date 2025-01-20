using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public abstract class BaseModel
    {
        protected BaseModel() { }
        public int Id { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CreationDate { get; private set; }

        public void Desativar() { Ativo = false; }
    }
}

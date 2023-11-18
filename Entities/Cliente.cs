using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Entities
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Cliente()
        {
            
        }

        public override string ToString()
        {
            return $"ID:{Id} - {Nome}, {Email}, {Telefone}";
        }
    }
}

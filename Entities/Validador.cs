using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Entities
{
    internal class Validador
    {
        public static bool StringEhValida(string readline)
        {
            if (string.IsNullOrEmpty(readline))
            {
                return false;
            }

            //if (StringExiste(readline)) BUG para analisar
            //{
            //    return false;
            //}

            return true;
        }

        public static bool NomeEhValido(string nome)
        {
            if (!StringEhValida(nome))
            {
                return false;
            }

            if (TemNumeroOuSimbolosNoNome(nome))
            {
                return false;
            }

            return true;
        }

        public static bool TemNumeroOuSimbolosNoNome(string nome)
        {
            string[] dividirNome = nome.Split(' ');
            char[][] sobrenome = new char[dividirNome.Length][];

            for (int i = 0; i < dividirNome.Length; i++)
            {
                sobrenome[i] = dividirNome[i].ToCharArray();

                char[] simbolosProibidos = "!@#$%^&*()-_=+[{]}\"|;:',<.\\>/?`~1234567890".ToCharArray();

                foreach (char caractereNome in sobrenome[i])
                {
                    if (simbolosProibidos.Contains(caractereNome))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool EmailEhValido(string email)
        {
            if (!StringEhValida(email))
            {
                return false;
            }

            // if (Email.Contains(email)) BUG para analisar
            // {
            //     return false;
            // }

            if (!email.Contains('@'))
            {
                return false;
            }
            if (ContarDeArrobas(email) > 1)
            {
                return false;
            }
            if (!PartesDoEmailSaoValidas(email))
            {
                return false;
            }
            if (!ComponentesDoEmailSaoValidos(email))
            {
                return false;
            }

            return true;
        }

        static int ContarDeArrobas(string email)
        {
            int quantidadeDeArrobas = 0;

            foreach (char caractere in email)
            {
                if (caractere == '@')
                {
                    quantidadeDeArrobas++;
                }
            }

            return quantidadeDeArrobas;
        }

        public static bool ComponentesDoEmailSaoValidos(string email)
        {
            if (email.StartsWith(".") || email.StartsWith("-") || email.EndsWith(".") || email.EndsWith("-") ||
                email.StartsWith("_") || email.EndsWith("_") || email.Contains(".-") || email.Contains("-.") ||
                email.Contains("._") || email.Contains("_.") || email.Contains("_-") || email.Contains("__") ||
                email.Contains("..") || email.Contains("--"))
            {
                return false;
            }

            return true;
        }

        public static bool PartesDoEmailSaoValidas(string email)
        {
            string[] dividirEmail = email.Split("@");
            char[] usuarioEmail = dividirEmail[0].ToCharArray();
            char[] dominioEmail = dividirEmail[1].ToCharArray();
            char[] simbolosPermitidosUsuario = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz._-0123456789".ToCharArray();

            foreach (char caractereUsuario in usuarioEmail)
            {
                if (!simbolosPermitidosUsuario.Contains(caractereUsuario))
                {
                    return false;
                }
            }

            string[] dividirDominioEmail = new string(dominioEmail).Split('.');
            char[] nomeDominioEmail = dividirDominioEmail[0].ToCharArray();
            char[] finalDominioEmail = dividirDominioEmail[1].ToCharArray();
            char[] simbolosPermitidosFinal = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-".ToCharArray();
            char[] simbolosPermitidosNome = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-0123456789".ToCharArray();

            foreach (char simboloDominioFinal in finalDominioEmail)
            {
                if (!simbolosPermitidosFinal.Contains(simboloDominioFinal))
                {
                    return false;
                }
            }

            if (finalDominioEmail.Length < 2)
            {
                return false;
            }

            if (finalDominioEmail[0] == '.' || finalDominioEmail[0] == '-' || finalDominioEmail[^1] == '.' || finalDominioEmail[^1] == '.' ||
                finalDominioEmail[0] == '_' || finalDominioEmail[^1] == '_')
            {
                return false;
            }

            foreach (char simboloDominioNome in nomeDominioEmail)
            {
                if (!simbolosPermitidosNome.Contains(simboloDominioNome))
                {
                    return false;
                }
            }

            if (nomeDominioEmail[0] == '.' || nomeDominioEmail[0] == '-' || nomeDominioEmail[^1] == '.' || nomeDominioEmail[^1] == '-' ||
                nomeDominioEmail[0] == '-' || nomeDominioEmail[^1] == '_')
            {
                return false;
            }

            return true;
        }

        public static bool TelefoneEhValido(string telefone)
        {
            if (!StringEhValida(telefone))
            {
                return false;
            }
            if (!TelefoneContemApenasNumeros(telefone))
            {
                return false;
            }

            return true;
        }

        public static bool TelefoneContemApenasNumeros(string telefone)
        {
            telefone = telefone.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            char[] arrayNumerosTelefone = telefone.ToCharArray();
            char[] simbolosPermitidosTelefone = "0123456789-()".ToCharArray();

            foreach (char apenasNumeros in arrayNumerosTelefone)
            {
                if (!simbolosPermitidosTelefone.Contains(apenasNumeros))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Abstractions.Messages
{
    public static class Message
    {
        public const string _01_Vazio_ou_Nulo = "não deve ser vazio ou nulo";
        public const string _02_Menor_que_Zero = "não pode ser menor que zero";
        public const string _03_NAO_ENCONTRADO = "registro não encontrado";
        public const string _04_IDS_NAO_CONFEREM = "Ids não conferem";
        public const string _05_USUARIO_NAO_ENCONTRADO = "Usuário não encontrado";
        public const string _06_SEM_PERMISSAO = "Usuário sem permissão";
        public const string _07_CLIENTE_JA_EXISTE_CELULAR = "Já existe um cliente com esse número de celular";
        public const string _08_CLIENTE_JA_EXISTE_NUMERO_DOCUMENTO = "Já existe um cliente com esse CPF/CNPJ";
    }
}

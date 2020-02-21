using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {

        List<FuncionarioDomain> List();

        FuncionarioDomain SearchId(int id);

        void Insert(FuncionarioDomain funcionario);

        void UpdateIdUrl(int id, FuncionarioDomain funcionario);

        void Delete(int id);
    }
}

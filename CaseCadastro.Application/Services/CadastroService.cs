using CaseCadastro.Application.Interfaces;
using CaseCadastro.Domain.Interfaces;
using CaseCadastro.Domain.Models;

namespace CaseCadastro.Application.Services
{
    public class CadastroService : ICadastroService
    {
        public IUnityWork _unitywork;
        public CadastroService(IUnityWork unitywork) 
        {
            _unitywork = unitywork;
        }

        public async Task<IEnumerable<Cadastro>> GetAll()
        {
            var productDetailsList = await _unitywork.Cadastro.GetAllAsync();
            return productDetailsList;
        }

        public async Task<Cadastro> GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var cadastrodetalhe = await _unitywork.Cadastro.GetById(id);
                    if (cadastrodetalhe != null)
                    {
                        return cadastrodetalhe;
                    }
                }
                return null;
            } catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> InserirCadastro(Cadastro cliente)
        {
            if (cliente != null)
            {
                await _unitywork.Cadastro.Insert(cliente);

                var result = _unitywork.Salvar();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> UpdateCadastro(Cadastro cliente)
        {
            if (cliente != null)
            {
                var cliente_v2 = await _unitywork.Cadastro.GetById(cliente.Id);
                if (cliente_v2 != null)
                {
                    cliente_v2.Nome = cliente.Nome;
                    cliente_v2.Sobrenome = cliente.Sobrenome;
                    cliente_v2.Idade = cliente.Idade;
                    cliente_v2.Pais = cliente.Pais;

                    await _unitywork.Cadastro.Update(cliente_v2);

                    var result = _unitywork.Salvar();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteCadastro(int cadastroId)
        {
            if (cadastroId > 0)
            {
                await _unitywork.Cadastro.Delete(cadastroId);
                var result = _unitywork.Salvar();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}

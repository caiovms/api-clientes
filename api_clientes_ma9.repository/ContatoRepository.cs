﻿using api_clientes_ma9.data;
using api_clientes_ma9.Data_Acess.Abstracts.Repositories;
using api_clientes_ma9.Entities;
using System.Linq;

namespace api_clientes_ma9.repository
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        #region Construtor
        private readonly Ma9_ClientesContext _context;

        public ContatoRepository(Ma9_ClientesContext context) : base(context)
        {
            this._context = context;
        }
        #endregion

        #region Alterar
        public override void Alterar(Contato entidade)
        {
            this.DetachedLocal(c => c.Id == entidade.Id);

            base.Alterar(entidade);
        }
        #endregion

        #region ObterPorIdCliente
        public Contato ObterPorIdCliente(int? idCliente)
        {
            var consulta = from c in _context.Contatos
                           .Where(c => c.IdCliente == idCliente)
                           select c;

            return consulta.SingleOrDefault();
        } 
        #endregion
    }
}

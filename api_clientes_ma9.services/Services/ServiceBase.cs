﻿using api_clientes_ma9.Data_Acess.Abstracts.Repositories;
using api_clientes_ma9.domain.Abstracts.Services;
using System.Collections.Generic;

namespace api_clientes_ma9.domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        #region Construtor
        private readonly IRepositoryBase<TEntity> repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> Listar()
        {
            return repositoryBase.Listar();
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Obter(int? id)
        {
            return repositoryBase.Obter(id);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Inserir(TEntity entidade)
        {
            repositoryBase.Inserir(entidade);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Alterar(TEntity entidade)
        {
            repositoryBase.Alterar(entidade);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public virtual void Excluir(int? id)
        {
            repositoryBase.Excluir(id);
        }
        #endregion
    }
}
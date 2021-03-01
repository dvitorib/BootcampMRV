using DIO.Series.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Interfaces.Services
{
    public interface IServiceSerie : IServiceBase<Serie>
    {
        /// <summary>
        /// Méthod for Envio de e-mail
        /// </summary>
        /// <param name="SendingEmail"></param>
        /// <returns></returns>
        void SendingEmail()
        {
        }
    }
}
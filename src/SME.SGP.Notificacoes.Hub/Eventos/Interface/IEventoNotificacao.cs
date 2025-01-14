﻿using Microsoft.AspNetCore.SignalR;
using SME.SGP.Notificacoes.Hub.Interface;
using System.Threading.Tasks;

namespace SME.SGP.Notificacoes.Hub
{
    public interface IEventoNotificacao<TMensagem>
        where TMensagem : MensagemNotificacaoDto
    {
        Task Enviar(IHubCallerClients clients, TMensagem mensagem);
    }
}

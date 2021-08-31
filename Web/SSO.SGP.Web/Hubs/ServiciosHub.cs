using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio;

namespace SSO.SGP.Web
{
    public class ServiciosHub : Hub
    {
        private UsuariosRN oUsuarios = new UsuariosRN();

        public void NewContosoChatMessage(string name, string message)
        {
            Clients.All.addContosoChatMessageToPage(name, message);
        }

        public void EnviarMensaje(string message)
        {
            Clients.All.recibirMensaje(message);
        }

        public void EnviarNotificacion(string x, int oficina)
        {
            Clients.All.mostrarNotificacion(x, oficina);
        }

        public void EnviarNotificacionPorOrganismo(string title, string x, int oficina)
        {
            Clients.All.mostrarNotificacionPorOrganismo(title, x, oficina);
        }

        public void registerSign(string usuario, string sign)
        {
            Clients.All.recibirMensaje (sign);
        }

    }
}
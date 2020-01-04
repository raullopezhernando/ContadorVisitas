using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace ContadorVisitas.Hub
{
    public class ContadorHub : Microsoft.AspNet.SignalR.Hub
    {
        private static int _visitantes = 0;

        // LADO DEL SERVIDOR

        // Cuando se esta conectado al Servidor (OnConnected())
        public override async Task OnConnected() 
        {
            // Cada vez que un cliente se conecta se incrementa en una unidad nuestra variable
            Interlocked.Increment(ref _visitantes);
            await Clients.Others.Message("Nueva Conexion" + Context.ConnectionId + "Total Visitantes" + _visitantes);
            await Clients.Caller.Message("Hola, Bienvenido....!!!");
        }

        public override Task OnDisconnected(bool stopCalled) 
        {
            // Cada vez que un cliente se desconecta se resta en una unidad nuestra variable
            Interlocked.Decrement(ref _visitantes);
            return Clients.All.Messages(Context.ConnectionId + "cerro la conexion" + "Total Visitantes" + _visitantes);
        }

        public Task Broadcast(string message) 
        {

            return Clients.All.Message(Context.ConnectionId + "-----" + message);
        
        }
    }
}
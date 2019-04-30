using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UI.Web.MVC.SignalR
{
    [Authorize]
    public class VentasHub:Hub
    {
        static List<int> Pedidos = new List<int>();

        public void MonitorearPedido(int idVenta)
        {
            Pedidos.Add(idVenta);

            Clients.All.revisarPedido(Pedidos);
        }
    }
}
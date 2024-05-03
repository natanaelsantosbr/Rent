using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Abstractions.Validations
{
    public abstract class Validable : IValidable
    {
        public bool Valid => !Alerts.Any();
        public bool Invalid => !Valid;

        public IEnumerable<string> Alerts { get; private set; }

        public Validable()
        {
            Alerts = new List<string>();
        }

        protected void Alert(Exception exception)
        {
            Alert($"{exception.Message} em {exception.StackTrace}");
        }

        protected void Alert(string critica)
        {
            if (String.IsNullOrEmpty(critica)) return;

            var novaLista = Alerts.ToList();
            novaLista.Add(critica);
            Alerts = novaLista;
        }

        protected void ImportAlerts(Notifiable notifiable)
        {
            if (notifiable == null || notifiable.Notifications == null) return;

            foreach (var notificacao in notifiable.Notifications)
                Alert(notificacao.Message);
        }

        protected void ImportAlerts(IValidable validavel)
        {
            if (validavel == null || validavel.Alerts == null) return;

            foreach (var critica in validavel.Alerts)
                Alert(critica);
        }

    }
}

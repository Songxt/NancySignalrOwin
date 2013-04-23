namespace SampleApp
{
    using System;
    using Microsoft.AspNet.SignalR;
    using Raven.Client;

    public class Chat : Hub
    {
        public void Send(string message)
        {
            var documentStore = GlobalHost.DependencyResolver.Resolve<IDocumentStore>();
            Clients.All.addMessage(message);
            using (IDocumentSession session = documentStore.OpenSession())
            {
                session.Store(new ChatLogDocument {Created = DateTime.UtcNow, Message = message});
                session.SaveChanges();
            }
        }
    }
}
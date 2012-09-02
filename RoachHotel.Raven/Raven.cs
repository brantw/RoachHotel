using System;
using System.Collections.Generic;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Linq;

namespace RoachHotel.Raven
{
    public class Raven
    {
        public static IDocumentStore EmbeddedDocStore = new EmbeddableDocumentStore { DataDirectory = "~/Data"};
        
        public Raven()
        {
            EmbeddedDocStore.Initialize();
        }

        public void StoreData()
        {
            using (var session = EmbeddedDocStore.OpenSession())
            {
                session.Store(new Task { Name = "Name 1", Start = new DateTime(2012, 7, 12), End = new DateTime(2012, 8,  9) });
                session.Store(new Task { Name = "Name 2", Start = new DateTime(2012, 4, 9), End = new DateTime(2012, 10, 9) });
                session.Store(new Task { Name = "Name 3", Start = new DateTime(2012, 4, 15), End = new DateTime(2012, 5, 18) });
                session.SaveChanges();
            }
        }

        public IEnumerable<Task> GetData()
        {
            using (var session = EmbeddedDocStore.OpenSession())
            {
                return from task in session.Query<Task>()
                            where task.End <  new DateTime(2012, 8, 31)
                            select task;
            }
        }
    }
}

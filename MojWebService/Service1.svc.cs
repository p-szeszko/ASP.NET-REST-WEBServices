using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MojWebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
   [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class Service1 : IRestService1
    {
        private static List<Book> lista;

        public Service1()
        {
            lista = new List<Book>() {new Book("1","Nocna straż"),new Book("2","Krucjata"), new Book("3","SAS Ostatni Bastion") };
        }

        
        public string add(Book newBook)
        {
            if (newBook == null)
                throw new WebFaultException<string>("400:: BadRequest", HttpStatusCode.BadRequest);
            int idx = lista.FindIndex(b => b.ID == newBook.ID);
            if(idx==-1)
            {
                lista.Add(newBook);
                return "Added item with ID: " + newBook.ID;
            }else
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);

        }

        public string addJson(Book newBook)
        {
            if (newBook == null)
                throw new WebFaultException<string>("400:: BadRequest", HttpStatusCode.BadRequest);
            int idx = lista.FindIndex(b => b.ID == newBook.ID);
            if (idx == -1)
            {
                lista.Add(newBook);
                return "Added item with ID: " + newBook.ID;
            }
            else
                throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);

        }

        public string delete(string id)
        {
            int idBook = lista.FindIndex(b => b.ID == id);
            if (idBook == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            lista.RemoveAt(idBook);
            return "Usunięto ksiazke o ID: "+id;
        }

        public string deleteJson(string ID)
        {
            int idBook = lista.FindIndex(b => b.ID == ID);
            if (idBook == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            lista.RemoveAt(idBook);
            return "Usunięto ksiazke o ID: " + ID;
        }

        public List<Book> getAll()
        {
            return lista;
        }
        public Book getById(string id)
        {
            int idBook = lista.FindIndex(b => b.ID==id);
            if (idBook == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            return lista.ElementAt(idBook);
        }

        public List<Book> getJsonAll()
        {
            return lista;
        }

        public Book getJsonById(string ID)
        {
            int idBook = lista.FindIndex(b => b.ID == ID);
            if (idBook == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            return lista.ElementAt(idBook);
        }
    }
}

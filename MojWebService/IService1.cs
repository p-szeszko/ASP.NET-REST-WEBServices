using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace MojWebService
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IWebSerwis
    {
        [OperationContract]
        int Silinia(int wartosc);
     
      

        // TODO: dodaj tutaj operacje usługi
    }

    [ServiceContract]
    public interface IRestService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/books")]
        List<Book> getAll();

        [OperationContract]
        [WebGet(UriTemplate = "/json/books")]
        List<Book> getJsonAll();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}",
        ResponseFormat = WebMessageFormat.Xml)]
        Book getById(string ID);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Book getJsonById(string ID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string add(Book newBook);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string addJson(Book newBook);

        [OperationContract]
        [WebInvoke(UriTemplate = "/book/{id}", Method = "DELETE")]
        string delete(string ID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/book/{id}", Method = "DELETE")]
        string deleteJson(string ID);
    }

    [DataContract]
    public class Book
    {
        [DataMember(Order = 0)]
        public string ID;
        [DataMember(Order = 0)]
        public string nazwa;
       
        public Book(string ID, string n)
        {
            this.ID = ID;
            this.nazwa = n;
        }
    }
 
   



    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

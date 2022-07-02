using RestSharp;
using ADO_Address_Book;
using System.Net;
using Newtonsoft.Json;


namespace AddressBook_RestSharp
{
    [TestClass]
    public class AddressBookRestSharp
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }
        [TestMethod]
        public void RetrieveALlData_ShouldReturnFriendsData()
        {
            RestRequest request = new RestRequest("/friend", Method.Get);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode,HttpStatusCode.OK);
            List<TestModel> list = JsonConvert.DeserializeObject<List<TestModel>>(response.Content);
            //Console.WriteLine(response.Content);
            Assert.AreEqual(3, list.Count);
        }
        [TestMethod]
        public void RetrieveALlData_ShouldReturnFamilyData()
        {
            RestRequest request = new RestRequest("/family", Method.Get);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<TestModel> list = JsonConvert.DeserializeObject<List<TestModel>>(response.Content);
            //Console.WriteLine(response.Content);
            Assert.AreEqual(3, list.Count);
        }
        
    }
}
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
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
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
        //Person Added in Friend AddressBook
        [TestMethod]
        public void GivenInputData_AddedToFriendGropu()
        {
            RestRequest request = new RestRequest("/friend", Method.Post);
            var personFriend = new TestModel { firstName = "Thamarai", lastName = "Ragav" };
            request.AddParameter("application/json", personFriend, ParameterType.RequestBody);
            RestResponse response = client.Post(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            TestModel list = JsonConvert.DeserializeObject<TestModel>(response.Content);
            Console.WriteLine(response.Content);
            Assert.AreEqual(personFriend.firstName, list.firstName);
        }
        //Person Added in Family AddressBook
        [TestMethod]
        public void GivenInputData_AddedToFamilyGropu()
        {
            RestRequest request = new RestRequest("/family", Method.Post);
            var personFriend = new TestModel { firstName = "Ragav", lastName = "Vijay" };
            request.AddParameter("application/json", personFriend, ParameterType.RequestBody);
            RestResponse response = client.Post(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            TestModel list = JsonConvert.DeserializeObject<TestModel>(response.Content);
            Console.WriteLine(response.Content);
            Assert.AreEqual(personFriend.firstName, list.firstName);
        }
        [TestMethod]
        public void GivenId_SholdDeleteContact()
        {
            RestRequest request = new RestRequest("/friend/4", Method.Delete);
            RestResponse response = client.Execute(request);
            //Assert.AreEqual(response.StatusCode,HttpStatusCode.ok)
            RestRequest getRequest = new RestRequest("/friend", Method.Get);
            RestResponse getresponse = client.Execute(getRequest);
            Console.WriteLine(getresponse.Content);
            List<TestModel> list = JsonConvert.DeserializeObject<List<TestModel>>(getresponse.Content);           
            Assert.AreEqual(3, list.Count);
        }
    }
}
using API.BadVersion.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace API.BadVersion
{
    public class Tests
    {
        RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://reqres.in/api");
        }

        [Test]
        public void GetUserById()
        {
            var request = new RestRequest("/users/2", Method.Get);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());

                var jsonResponse = JObject.Parse(response.Content);

                var userResponseRoot = JsonConvert.DeserializeObject<User>(jsonResponse.SelectToken("$.data").ToString());

                Console.WriteLine($"FirstName {userResponseRoot.FirstName}");

            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }

        }

        [Test]
        public void CreateUser_Hardcode()
        {
            var request = new RestRequest("/users", Method.Post);

            var body = new User
            {
                FirstName = " ",
                Email = " ",
            };

            request.AddBody(body);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }

        }

        [Test]
        public void CreateUser_Dictionary()
        {
            var request = new RestRequest("/users", Method.Post);

            var body = new Dictionary<string, object>()
            {
                { "Name", "Ivan"},
                { "Password", "QWERT12345" }
            };

            request.AddBody(body);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }

        }

        [Test]
        public void CreateUser_Model()
        {
            var request = new RestRequest("/users", Method.Post);

            var user = new User
            {
                FirstName = "Ivan",
                Email = "terydvbfgybnj",
                Id = 0
            };

            var body = JsonConvert.SerializeObject(user);


            request.AddBody(body);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }

            User userCreated = JsonConvert.DeserializeObject<User>(response.Content);


            Assert.That(user, Is.EqualTo(userCreated));

        }

        [Test]
        public void CreateUser_File()
        {
            var request = new RestRequest("/users", Method.Post);

            var body = File.ReadAllText("User.json");

            request.AddBody(body);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content.ToString());
            }
            else
            {
                Console.WriteLine("Failed: " + response.ErrorMessage);
            }

        }
    }
}
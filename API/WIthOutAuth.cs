using RestSharp;

namespace API
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
            }
            else
            {
                Console.WriteLine("Failed: " +  response.ErrorMessage);
            }

        }

        [Test]
        public void CreateUser_Hardcode()
        {
            var request = new RestRequest("/users", Method.Post);

            var body = new User
            {
                Name = " ",
                Password = " ",
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

            var body = new User
            {
                Name = "Ivan",
                Password = " ",
            };

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
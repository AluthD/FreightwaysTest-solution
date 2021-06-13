
using FreightwaysTest.Model;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace FreightwaysTest
{
    [TestFixture]
    public class UnitTest1
    {


        [Test]
        public void TestRead()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest("posts/1", Method.GET);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["title"];

            Assert.That(result, Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"), "User Id is not correct");
        }

        [Test]
        public void TestCreate()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest("posts", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Posts() { userId = "14", title = "Post title - Chinthaka", body = "Post body created" });

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["title"];

            Assert.That(result, Is.EqualTo("Post title - Chinthaka"), "Author is not correct");


        }

        [Test]
        public void TestUpdate()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest("posts/1", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Posts() { userId = "1", title = "Updated title - New", body = "This is updated body" });

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["title"];

            Assert.That(result, Is.EqualTo("Updated title - New"), "Author is not correct");

        }

        [Test]
        public void TestDelete()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest("posts/1", Method.DELETE);

            var response = client.Execute(request);
        }


    }
}

using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "http://127.0.0.1:8000/predict";

        var inputData = new
        {
            school = "GP",
            sex = "F",
            age = 18,
            address = "U",
            famsize = "GT3",
            Pstatus = "A",
            Medu = 4,
            Fedu = 4,
            Mjob = "at_home",
            Fjob = "teacher",
            reason = "course",
            guardian = "mother",
            traveltime = 2,
            studytime = 2,
            failures = 0,
            schoolsup = "yes",
            famsup = "no",
            paid = "no",
            activities = "no",
            nursery = "yes",
            internet = "no",
            romantic = "no",
            famrel = 4,
            freetime = 3,
            goout = 4,
            Dalc = 1,
            Walc = 1,
            health = 3,
            absences = 6
        };

        string json = JsonSerializer.Serialize(inputData);

        using (HttpClient client = new HttpClient())
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            string responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response from API:");
            Console.WriteLine(responseString);
        }
    }
}

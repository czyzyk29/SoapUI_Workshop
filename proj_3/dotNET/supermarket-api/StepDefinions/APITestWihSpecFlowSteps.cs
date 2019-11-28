using RestSharp;


public class APITestWithSpecFlowSteps
{
    [Given(@"I have my Endpoint")]
    public void GivenIhaveMyEndPoint()
    {
        RestClient restClient = new RestClient("https://localhost:5001");
    }
}
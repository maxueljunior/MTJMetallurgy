namespace MTJM.WebApp.MVC.Models;

public class CustomResponse
{
    public string Title { get; set; }
    public int Status {  get; set; }
    public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    public dynamic Result { get; set; }

    public CustomResponse WithError(string error)
    {
        Title = "Error occurred";
        Status = 400;
        Errors.Add("Messages", [error]);
        Result = null;
        return this;
    }

    public CustomResponse WithErrors(CustomResponse customResponse)
    {
        Title = customResponse.Title;
        Status = customResponse.Status;
        Errors = customResponse.Errors;
        Result = customResponse.Result;
        return this;
    }

    public CustomResponse WithSuccess(dynamic obj = null)
    {
        Title = "Success";
        Status = 200;
        Result = obj;
        return this;
    }
}

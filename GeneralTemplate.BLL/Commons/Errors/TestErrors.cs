namespace GeneralTemplate.BLL.Commons.Errors;
public record TestErrors
{
    public static readonly Error InvalidCredentials =
        new("Test.InvalidCredentials", "Invalid email/password", 404);

}
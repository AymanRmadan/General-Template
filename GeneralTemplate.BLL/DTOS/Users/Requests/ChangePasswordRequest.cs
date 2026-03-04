namespace GeneralTemplate.BLL;
public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword
    );



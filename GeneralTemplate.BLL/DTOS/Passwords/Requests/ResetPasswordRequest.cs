namespace GeneralTemplate.BLL.DTOS.Passwords.Requests;

public record ResetPasswordRequest(
    string Email,
    string Code,
    string NewPassword
);
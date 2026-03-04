namespace GeneralTemplate.BLL;

public record ResetPasswordRequest(
    string Email,
    string Code,
    string NewPassword
);
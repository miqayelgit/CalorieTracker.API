
using CalorieTracker.Dtos.Auth;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Application.Contracts.Services.User;

public interface IAuthenticationService
{
    public Task<SignInResponseDto> SignInUser(SignInDto dto);
    public Task<string> ForgotPassword(ForgotPasswordDto dto);
    public Task ResetPassword(ResetPasswordDto dto);
}

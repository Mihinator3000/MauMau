using MauMau.Core.Identity;

namespace MauMau.Abstractions.Application.Factories;

public interface IAccessTokenFactory
{
    AccessToken Create(User user);
}
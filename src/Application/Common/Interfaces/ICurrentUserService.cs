﻿namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        string RoleName { get; set; }
    }
}
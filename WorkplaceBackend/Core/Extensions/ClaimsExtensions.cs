﻿using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsExtensions
    {
        public static void AddId(this ICollection<Claim> claims, int id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(roles => claims.Add(new Claim(ClaimTypes.Role, roles)));
        }
    }
}

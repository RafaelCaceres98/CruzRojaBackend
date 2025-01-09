using Backend_CruzRoja.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public static class JwtTokenGenerator
{
    private static readonly string Key = "AquíVaTuClaveSecretaDe256Bitsghjhgkjhgkjhgkjhgkjhgjhgkjhgkhgfhgfjgfjfjfjgj";

    public static string GenerateJwtToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
               new Claim("user_Id", usuario.Id.ToString()),
               new Claim("user_state", usuario.EstadoUsuarioId.ToString()),
               new Claim(ClaimTypes.Role, usuario.RolUsuarioId.ToString()),
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

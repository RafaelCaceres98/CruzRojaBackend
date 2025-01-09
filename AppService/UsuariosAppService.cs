using AutoMapper;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_CruzRoja.Utilidades;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO.TipoMantenimientoDTO;
using MimeKit;

using MailKit.Net.Smtp;


namespace Backend_CruzRoja.AppService
{
    public class UsuariosAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<IEnumerable<UsuarioCreacionDTO>> Get()
        {
            return await context.Usuarios

                .ProjectTo<UsuarioCreacionDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //Creando un nuevo registro
        public async Task<ResponseDTO> Post(UsuarioCreacionDTO usuarioCreacionDTO)
        {
            var responseDTO = new ResponseDTO();

            if (await context.Usuarios.AnyAsync(c => c.NombreUsuario == usuarioCreacionDTO.NombreUsuario || c.clave == usuarioCreacionDTO.clave))
            {
                responseDTO.Mensaje = "No se permiten usuarios duplicados";
            }
            else
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuarioCreacionDTO.clave);

                Usuario usuario = new Usuario
                {
                    NombreUsuario = usuarioCreacionDTO.NombreUsuario,
                    clave = hashedPassword, //clave enciptada
                    RolUsuarioId = usuarioCreacionDTO.RolUsuarioId,
                    EstadoUsuarioId = usuarioCreacionDTO.EstadoUsuarioId,
                    CorreoElectronico=usuarioCreacionDTO.CorreoElectronico
                };

                context.Add(usuario);
                await context.SaveChangesAsync();

                responseDTO.Data = mapper.Map<UsuarioCreacionDTO>(usuario);
                responseDTO.Mensaje = "Usuario creado con éxito.";
            }

            return responseDTO;
        }

        //actualiza un registro con su ID 
        public async Task<ResponseDTO> Put(int id, UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var usuario = await context.Usuarios.FindAsync(id);


            if (usuario == null)
            {
                return new ResponseDTO
                {
                    Mensaje = "El ID del usuario no existe"
                };
            }

            // Verificar si existe otro usuario con la misma clave o nombre de usuario (distinto del usuario actual)
            if (await context.Usuarios.AnyAsync(c => (c.clave == usuarioUpdateDTO.clave || c.NombreUsuario == usuarioUpdateDTO.NombreUsuario) && c.Id != id))
            {
                return new ResponseDTO
                {
                    Mensaje = "NO se permiten usuario duplicados"
                };
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuarioUpdateDTO.clave);

            usuario.NombreUsuario = usuarioUpdateDTO.NombreUsuario;
            usuario.clave = hashedPassword; //clave enciptada
            usuario.RolUsuarioId = usuarioUpdateDTO.RolUsuarioId;
            usuario.EstadoUsuarioId = usuarioUpdateDTO.EstadoUsuarioId;
            usuario.CorreoElectronico = usuarioUpdateDTO.CorreoElectronico;

            context.Update(usuario);
            await context.SaveChangesAsync();

            return new ResponseDTO
            {
                Data = usuarioUpdateDTO
            };
        }

        //login
        public async Task<ResponseDTO> Authenticate(LoginDTO loginDTO)
        {
 
            var usuario = await context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == loginDTO.NombreUsuario);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Clave, usuario.clave))
            {
                return new ResponseDTO
                {
                    Mensaje = "Credenciales inválidas",
                };
            }
            //arreglar el else 
            if (usuario.EstadoUsuarioId == 2) // Verifica si el EstadoId es 2 (inactivo)
            {
                return new ResponseDTO
                {
                    Mensaje = "El usuario está inactivo",
                };
            }
            var token = JwtTokenGenerator.GenerateJwtToken(usuario);

            return new ResponseDTO
            {
                Mensaje = "Autenticación exitosa",
                //Data = loginDTO,
                Token = token
            };
        }

        //        // desde aqui se agregala logica de recuperar contraseña
        public async Task<ResponseDTO> RecuperarContrasena(RecuperarContrasenaDTO recuperarContrasenaDTO)
        {
            var responseDTO = new ResponseDTO();

            // Buscar al usuario por correo electrónico
            var usuario = await context.Usuarios
                .FirstOrDefaultAsync(u => u.CorreoElectronico == recuperarContrasenaDTO.CorreoElectronico);

            if (usuario == null)
            {
                responseDTO.Mensaje = "El correo electrónico no está asociado a ningún usuario.";
                return responseDTO;
            }

            // Generar un token
            string token = Guid.NewGuid().ToString();

            // Guardar el token en la base de datos
            await SaveTokenAsync(usuario.Id, token);

            // Enviar el correo electrónico con el token
            await EnviarCorreoDeRecuperacion(usuario.CorreoElectronico, token);

            responseDTO.Mensaje = "Se ha enviado un correo de recuperación.";
            return responseDTO;
        }

        private async Task SaveTokenAsync(int usuarioId, string token)
        {
            var tokenRecuperacion = new TokenRecuperacion
            {
                UsuarioId = usuarioId,
                Token = token,
                FechaCreacion = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddHours(1) // Token válido por 1 hora
            };

            context.TokensRecuperacion.Add(tokenRecuperacion);
            await context.SaveChangesAsync();
        }




        private async Task EnviarCorreoDeRecuperacion(string correoElectronico, string token)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Cruz Roja", "rafaelricardo1435@gmail.com")); // Cambia el nombre y el correo
            message.To.Add(new MailboxAddress("", correoElectronico));
            message.Subject = "Recuperación de Contraseña";

            string enlaceRecuperacion = $"http://localhost:4200//restablecer-contrasena?token={token}"; // Cambia el dominio

            message.Body = new TextPart("html")
            {
                Text = $"<p>Para restablecer tu contraseña, haz clic en el siguiente enlace:</p><p><a href='{enlaceRecuperacion}'>Restablecer Contraseña</a></p>"
            };

            using (var client = new SmtpClient())
            {
                // Conectar al servidor SMTP
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls); // Cambia la configuración SMTP
                await client.AuthenticateAsync("rafaelricardo1435@gmail.com", "vsbuirlzmgdxujsu"); // Cambia las credenciales

                // Enviar el correo
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }


        public async Task<ResponseDTO> CambiarContrasena(CambiarContrasenaDTO cambiarContrasenaDTO)
        {
            var responseDTO = new ResponseDTO();

            // Verificar el token
            var tokenRecuperacion = await context.TokensRecuperacion
                .FirstOrDefaultAsync(t => t.Token == cambiarContrasenaDTO.Token && t.FechaExpiracion > DateTime.UtcNow);

            if (tokenRecuperacion == null)
            {
                responseDTO.Mensaje = "El token es inválido o ha expirado.";
                return responseDTO;
            }

            // Obtener el usuario
            var usuario = await context.Usuarios.FindAsync(tokenRecuperacion.UsuarioId);
            if (usuario == null)
            {
                responseDTO.Mensaje = "Usuario no encontrado.";
                return responseDTO;
            }

            // Actualizar la contraseña
            usuario.clave = BCrypt.Net.BCrypt.HashPassword(cambiarContrasenaDTO.NuevaContrasena);

            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();

            // Eliminar el token después de usarlo (opcional)
            context.TokensRecuperacion.Remove(tokenRecuperacion);
            await context.SaveChangesAsync();

            responseDTO.Mensaje = "Contraseña cambiada con éxito.";
            return responseDTO;
        }





    }
}

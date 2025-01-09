using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.DetallePeriocidadDTO;
using Backend_CruzRoja.DTO.MantenimientoDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class MantenimientoAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MantenimientoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //consulta todos los registros
        public async Task<ResponseDTO> Get()
        {
            var responseDTO = new ResponseDTO();

            var hoy = DateTime.Today;

            var mantenimientos = await context.Mantenimientos
                .Select(m => new MantenimientoDTO
                {
                    Id = m.Id,
                    VehiculoId = m.VehiculoId,
                    DetallePeriodicidadId = m.DetallePeriodicidadId,
                    FechaSolicitud = m.FechaSolicitud,
                    FechaVencimiento = m.FechaVencimiento,
                    KilometrajeActual = m.KilometrajeActual,
                    TiempoDias = m.TiempoDias,
                    PeriodicidadKilometraje = m.PeriodicidadKilometraje,
                    KilometrajeParaMantenimiento = m.KilometrajeParaMantenimiento,
                    PeriodicidadXTiempo = m.PeriodicidadXTiempo,
                    PorcentajeVencimiento = (double?)(hoy - m.FechaSolicitud).TotalDays / (m.FechaVencimiento - m.FechaSolicitud).TotalDays,
                    ConductorId = m.ConductorId

                })
                .ToListAsync();

            // Aplicar el redondeo y cálculo del porcentaje para cada mantenimiento encontrado
            mantenimientos.ForEach(m =>
            {
                if (m.PorcentajeVencimiento.HasValue)
                {
                    m.PorcentajeVencimiento *= 100;
                    m.PorcentajeVencimiento = Math.Round(m.PorcentajeVencimiento.Value, 2);
                }
            });

            if (mantenimientos.Any())
            {
                responseDTO.Data = mantenimientos;
                responseDTO.Mensaje = "Mantenimientos encontrados";
            }
            else
            {
                responseDTO.Mensaje = "No se encontraron mantenimientos";
            }

            return responseDTO;
        }


        public async Task<ResponseDTO> Post(MantenimientoDTO CreacionDTO)
        {
            var responseDTO = new ResponseDTO();

            // Crear una nueva instancia de Mantenimiento con los datos proporcionados
            Mantenimiento detalle = new Mantenimiento
            {
                VehiculoId = CreacionDTO.VehiculoId,
                DetallePeriodicidadId = CreacionDTO.DetallePeriodicidadId,
                FechaSolicitud = DateTime.Now, // O DateTime.UtcNow para UTC
                FechaVencimiento = CreacionDTO.FechaVencimiento,
                KilometrajeActual = CreacionDTO.KilometrajeActual,
                PeriodicidadKilometraje = CreacionDTO.PeriodicidadKilometraje,
                KilometrajeParaMantenimiento = CreacionDTO.KilometrajeActual + CreacionDTO.PeriodicidadKilometraje,
                PeriodicidadXTiempo = CreacionDTO.PeriodicidadXTiempo,
                ConductorId = CreacionDTO.ConductorId

            };

            // Calcular la cantidad de días restantes para el nuevo mantenimiento
            var diasRestantes = (detalle.FechaVencimiento - detalle.FechaSolicitud).Days;
            detalle.TiempoDias = diasRestantes;

            // Agregar el detalle a la base de datos y guardar los cambios
            context.Add(detalle);
            await context.SaveChangesAsync();

            // Mapear el objeto detalle a MantenimientoDTO y asignar el mensaje de respuesta
            var mantenimientoDTO = mapper.Map<MantenimientoDTO>(detalle);

            responseDTO.Data = mantenimientoDTO;
            responseDTO.Mensaje = "Se Creo el Registro";

            return responseDTO;
        }



        public async Task<ResponseDTO> Actualizar(int id, MantenimientoUpdateDTO ActualizacionDTO)
        {
            var responseDTO = new ResponseDTO();

            var Encontrado = await context.Mantenimientos.FindAsync(id);
            if (Encontrado == null)
            {
                responseDTO.Mensaje = "Registro no encontrado.";
                return responseDTO;
            }

            // Actualizar los campos del registro encontrado
            Encontrado.VehiculoId = ActualizacionDTO.VehiculoId;
            Encontrado.DetallePeriodicidadId = ActualizacionDTO.DetallePeriodicidadId;
            Encontrado.FechaVencimiento = ActualizacionDTO.FechaVencimiento;
            Encontrado.KilometrajeActual = ActualizacionDTO.KilometrajeActual;
            Encontrado.PeriodicidadKilometraje = ActualizacionDTO.PeriodicidadKilometraje;
            Encontrado.KilometrajeParaMantenimiento = ActualizacionDTO.KilometrajeActual + ActualizacionDTO.PeriodicidadKilometraje;
            Encontrado.PeriodicidadXTiempo = ActualizacionDTO.PeriodicidadXTiempo;


            // Calcular la cantidad de días restantes para el nuevo mantenimiento
            var diasRestantes = (Encontrado.FechaVencimiento - Encontrado.FechaSolicitud).Days;
            Encontrado.TiempoDias = diasRestantes;

            // Actualizar el registro en la base de datos y guardar los cambios
            context.Mantenimientos.Update(Encontrado);
            await context.SaveChangesAsync();

            responseDTO.Mensaje = "Registro actualizado correctamente.";

            return responseDTO;
        }



        public async Task<ResponseDTO> GetMantenimientoByIdSelective(int id)
        {
            var responseDTO = new ResponseDTO();

            var hoy = DateTime.Today;

            var mantenimiento = await context.Mantenimientos
                .Where(m => m.Id == id)
                .Select(m => new MantenimientoDTO
                {
                    Id = m.Id,
                    VehiculoId = m.VehiculoId,
                    DetallePeriodicidadId = m.DetallePeriodicidadId,
                    FechaSolicitud = m.FechaSolicitud,
                    FechaVencimiento = m.FechaVencimiento,
                    KilometrajeActual = m.KilometrajeActual,
                    PeriodicidadKilometraje = m.PeriodicidadKilometraje,
                    KilometrajeParaMantenimiento = m.KilometrajeParaMantenimiento,
                    PeriodicidadXTiempo = m.PeriodicidadXTiempo,
                    PorcentajeVencimiento = (double?)(hoy - m.FechaSolicitud).TotalDays / (m.FechaVencimiento - m.FechaSolicitud).TotalDays

                })
                .FirstOrDefaultAsync();

            if (mantenimiento != null)
            {
                // Redondea el porcentaje de vencimiento a dos decimales y multiplica por 100 para obtener un porcentaje
                mantenimiento.PorcentajeVencimiento *= 100;
                mantenimiento.PorcentajeVencimiento = Math.Round(mantenimiento.PorcentajeVencimiento.Value, 2);

                responseDTO.Data = mantenimiento;
                responseDTO.Mensaje = "Mantenimiento encontrado";
            }
            else
            {
                responseDTO.Mensaje = "Mantenimiento no encontrado";
            }

            return responseDTO;
        }


        public async Task<ResponseDTO> Eliminar(int id)
        {
            var responseDTO = new ResponseDTO();


            var datelle = await context.Mantenimientos.FindAsync(id);
            if (datelle == null)
            {
                responseDTO.Mensaje = "ID no encontrado.";
                return responseDTO;
            }

            context.Mantenimientos.Remove(datelle);
            await context.SaveChangesAsync();

            responseDTO.Mensaje = "eliminado correctamente.";
            return responseDTO;
        }



        // Consultar el vehículo con más mantenimientos por mes
        public async Task<ResponseDTO> GetVehiculoConMasMantenimientosPorMes(int mes, int anio)
        {
            var responseDTO = new ResponseDTO();

            var resultado = await context.Mantenimientos
                .Where(m => m.FechaSolicitud.Month == mes && m.FechaSolicitud.Year == anio)
                .GroupBy(m => m.VehiculoId)
                .Select(group => new
                {
                    VehiculoId = group.Key,
                    TotalMantenimientos = group.Count()
                })
                .OrderByDescending(g => g.TotalMantenimientos)
                .FirstOrDefaultAsync();

            if (resultado == null)
            {
                responseDTO.Mensaje = "No se encontraron mantenimientos para el mes especificado.";
                return responseDTO;
            }

            var vehiculo = await context.Vehiculos
                .Where(v => v.Id == resultado.VehiculoId)
                .Select(v => new VehiculoDTO
                {
                    Id = v.Id,
                    Placa = v.Placa,
                    Marca = v.MarcaVehiculo.Descripcion,
                    Modelo = v.ModeloVehiculo.Descripcion
                })
                .FirstOrDefaultAsync();

            if (vehiculo == null)
            {
                responseDTO.Mensaje = "No se encontró el vehículo.";
                return responseDTO;
            }

            responseDTO.Data = new
            {
                Vehiculo = vehiculo,
                TotalMantenimientos = resultado.TotalMantenimientos
            };
            responseDTO.Mensaje = "Vehículo con más mantenimientos encontrado.";

            return responseDTO;
        }

        public async Task<ResponseDTO> GetMantenimientosPorConductor()
        {
            var responseDTO = new ResponseDTO();

            var resultados = await context.Mantenimientos
                .Include(m => m.Conductor) // Asegúrate de incluir la entidad Conductor
                .GroupBy(m => new { m.ConductorId, m.Conductor.Nombres }) // Agrupamos por el ID y nombre del conductor
                .Select(group => new
                {
                    ConductorId = group.Key.ConductorId,
                    NombreConductor = group.Key.Nombres, // Obtenemos el nombre del conductor
                    TotalMantenimientos = group.Count()
                })
                .ToListAsync();

            if (resultados.Any())
            {
                responseDTO.Data = resultados;
                responseDTO.Mensaje = "Mantenimientos por conductor encontrados.";
            }
            else
            {
                responseDTO.Mensaje = "No se encontraron mantenimientos por conductor.";
            }

            return responseDTO;
        }




    }


}



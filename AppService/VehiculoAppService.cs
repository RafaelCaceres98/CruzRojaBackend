using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Backend_CruzRoja.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CruzRoja.AppService
{
    public class VehiculoAppService : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VehiculoAppService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        //consulta todos los registros
        public async Task<IEnumerable<ConsultaVehiculoDTO>> Get()
        {
            return await context.Vehiculos

                .ProjectTo<ConsultaVehiculoDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //Creando un nuevo registro
        public async Task<ResponseDTO> Post(CrearVehiculoDTO  crearVehiculoDTO)
        {
            var responseDTO = new ResponseDTO();

            if (await context.Vehiculos.AnyAsync(c => c.Placa == crearVehiculoDTO.Placa))
            {
                responseDTO.Mensaje = "Ya existe un Vehiculo con la misma placa";
            }
            else
            {

                Vehiculo vehiculo = new Vehiculo
                {
                    Placa = crearVehiculoDTO.Placa,
                    anio = crearVehiculoDTO.anio,
                    Chasis = crearVehiculoDTO.Chasis,
                    Motor = crearVehiculoDTO.Motor,
                    NumMovil = crearVehiculoDTO.NumMovil,
                    Propiedad = crearVehiculoDTO.Propiedad,
                    anioRecibidoVehiculo = crearVehiculoDTO.anioRecibidoVehiculo,
                    Ubicacion = crearVehiculoDTO.Ubicacion,
                    Esactivo = crearVehiculoDTO.Esactivo,
                    MarcaVehiculoId = crearVehiculoDTO.MarcaVehiculoId,
                    ModeloVehiculoId = crearVehiculoDTO.ModeloVehiculoId,
                    TipoVehiculoId = crearVehiculoDTO.TipoVehiculoId,
                    LatoneriaId = crearVehiculoDTO.LatoneriaId,
                    MecanicaId = crearVehiculoDTO.MecanicaId,
                };

                context.Add(vehiculo);
                await context.SaveChangesAsync();

                responseDTO.Data = mapper.Map<CrearVehiculoDTO>(vehiculo);
                responseDTO.Mensaje = "Vehiculo creado con éxito.";
            }

            return responseDTO;
        }

        //para hacer busquedas desde la caja de texto del formulario empresa
        public async Task<IEnumerable<CrearVehiculoDTO>> Buscar(string busqueda)
        {
            busqueda = busqueda.ToLower();

            return await context.Vehiculos
                .Where(s =>
                    s.Placa.ToLower().Contains(busqueda))
                .Select(perfilempresaDTO => new CrearVehiculoDTO
                {
                     Id = perfilempresaDTO.Id,
                    Placa = perfilempresaDTO.Placa,
                    MarcaVehiculoId = perfilempresaDTO.MarcaVehiculoId,
                    ModeloVehiculoId = perfilempresaDTO.ModeloVehiculoId,
                    anio = perfilempresaDTO.anio,
                    Chasis = perfilempresaDTO.Chasis,
                    Motor = perfilempresaDTO.Motor,
                    NumMovil = perfilempresaDTO.NumMovil,
                    Propiedad = perfilempresaDTO.Propiedad,
                    anioRecibidoVehiculo = perfilempresaDTO.anioRecibidoVehiculo,
                    Ubicacion = perfilempresaDTO.Ubicacion,
                    Esactivo = perfilempresaDTO.Esactivo,
                    LatoneriaId = perfilempresaDTO.LatoneriaId,
                    MecanicaId = perfilempresaDTO.MecanicaId,
                    TipoVehiculoId =  perfilempresaDTO.TipoVehiculoId,
                })
                .ToListAsync();
        }

        //actualiza un registro con su ID 
        public async Task<ResponseDTO> Put(int id, ConsultaVehiculoDTO  consultaVehiculoDTO)
        {
            var vehiculo = await context.Vehiculos.FindAsync(id);


            if (vehiculo == null)
            {
                return new ResponseDTO
                {
                    Mensaje = "El ID del vehiculo no existe"
                };
            }

            // Verificar si existe otro vehiculo con la misma placa antes de actualizar)
            var existeVehiculo = await context.Vehiculos.FirstOrDefaultAsync(c => c.Id != id && c.Placa == consultaVehiculoDTO.Placa);
            if (existeVehiculo != null)
            {
                return new ResponseDTO
                {
                    Mensaje = "La placa ya esta en uso"
                };
            }

            vehiculo.Placa = consultaVehiculoDTO.Placa;
            vehiculo.anio = consultaVehiculoDTO.anio;
            vehiculo.Chasis = consultaVehiculoDTO.Chasis;
            vehiculo.Motor = consultaVehiculoDTO.Motor;
            vehiculo.NumMovil = consultaVehiculoDTO.NumMovil;
            vehiculo.Propiedad = consultaVehiculoDTO.Propiedad;
            vehiculo.anioRecibidoVehiculo = consultaVehiculoDTO.anioRecibidoVehiculo;
            vehiculo.Ubicacion = consultaVehiculoDTO.Ubicacion;
            vehiculo.Esactivo = consultaVehiculoDTO.Esactivo;
            vehiculo.MarcaVehiculoId = consultaVehiculoDTO.MarcaVehiculoId;
            vehiculo.ModeloVehiculoId = consultaVehiculoDTO.ModeloVehiculoId;
            vehiculo.LatoneriaId = consultaVehiculoDTO.LatoneriaId;
            vehiculo.MecanicaId = consultaVehiculoDTO.MecanicaId;
            vehiculo.TipoVehiculoId = consultaVehiculoDTO.TipoVehiculoId;

            context.Update(vehiculo);
            await context.SaveChangesAsync();

            return new ResponseDTO
            {
                Data = consultaVehiculoDTO
            };
        }

    }
}

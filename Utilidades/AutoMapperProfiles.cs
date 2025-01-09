using AutoMapper;
using Backend_CruzRoja.DTO;
using Backend_CruzRoja.DTO.CategoComprasYServiciosDTO;
using Backend_CruzRoja.DTO.ConductorDTO;
using Backend_CruzRoja.DTO.DetallePeriocidadDTO;
using Backend_CruzRoja.DTO.EstadoconductoresDTO;
using Backend_CruzRoja.DTO.EstadousuarioDTO;
using Backend_CruzRoja.DTO.HojaDeVidaDTO;
using Backend_CruzRoja.DTO.LatoneriaDTO;
using Backend_CruzRoja.DTO.MantenimientoDTO;
using Backend_CruzRoja.DTO.MarcaVehiculoDTO;
using Backend_CruzRoja.DTO.MecanicaDTO;
using Backend_CruzRoja.DTO.ModeloVehiculoDTO;
using Backend_CruzRoja.DTO.ProyectoDTO;
using Backend_CruzRoja.DTO.RegKilometrajeDTO;
using Backend_CruzRoja.DTO.RolUsuarioDTO;
using Backend_CruzRoja.DTO.SOAT_TECNO;
using Backend_CruzRoja.DTO.SOAtDTO;
using Backend_CruzRoja.DTO.TecnoMecanicaDTO;
using Backend_CruzRoja.DTO.TipoMantenimientoDTO;
using Backend_CruzRoja.DTO.TipoRecorrido.DTO;
using Backend_CruzRoja.DTO.TipoVehiculoDTO;
using Backend_CruzRoja.DTO.UsuariosDTO;
using Backend_CruzRoja.DTO.VehiculoDTO;
using Backend_CruzRoja.Entidades;

namespace Backend_CruzRoja.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioCreacionDTO>();
            CreateMap<Usuario, UsuarioUpdateDTO>();
            CreateMap<Usuario, LoginDTO>();
            CreateMap<TipoMantenimiento, ConsultaTipoMantenimientoDTO>();
            CreateMap<TipoVehiculo, ConsultaTipoVehiculoDTO>();
            CreateMap<MarcaVehiculo, MarcaVehiculoConsultaDTO>();
            CreateMap<ModeloVehiculo, ModeloVehiculoDTO>();
            CreateMap<Latoneria, LatoneriaConsultaDTO>();
            CreateMap<Mecanica, MecanicaConsultaDTO>();
            CreateMap<Vehiculo, ConsultaVehiculoDTO>();
            CreateMap<Vehiculo, CrearVehiculoDTO>();
            CreateMap<EstadoUsuario, EstadoUsuarioConsultaDTO>();
            CreateMap<RolUsuario, ConsultaRolUsuarioDTO>();
            CreateMap<Conductor, ConductorConsultaDTO>();
            CreateMap<HojadeVida, HojadeVidaDTO>();
            CreateMap<CategoriaComprasYServicios, CategoComprasYServiciosDTO>();
            CreateMap<TECNOMECANICA, TecnoMecanicaConsultaDTO>();
            CreateMap<SOAT, SOATConsultaDTO>();
            CreateMap<SOAT_TECNO, SOAtTECNOCreacionDTO>();
            CreateMap<DetallePeriodicidad, DetallePericiodiadDTO>();
            CreateMap<Mantenimiento, MantenimientoDTO>();
            CreateMap<Mantenimiento, MantenimientoUpdateDTO>();
            CreateMap<RegKilometraje, ConsultarKilometrajeDTO>();
            CreateMap<RegKilometraje, CrearKilometrajeDTO>();
            CreateMap<RegKilometraje, ConsultarKilometrajeDTO1>();
            CreateMap<Proyecto, ConsultaProyectoDTO>();
            CreateMap<TipoRecorrido, ConsultaTipoRecorridoDTO>();
            CreateMap<EstadoConductor, EstadoConductoresConsultaDTO>();


        }
    }
}

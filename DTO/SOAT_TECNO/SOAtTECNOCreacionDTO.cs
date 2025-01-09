using Backend_CruzRoja.DTO.SOAtDTO;
using Backend_CruzRoja.DTO.TecnoMecanicaDTO;
using Backend_CruzRoja.Entidades;

namespace Backend_CruzRoja.DTO.SOAT_TECNO
{
    public class SOAtTECNOCreacionDTO
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = default!;

        public int VehiculoId { get; set; }

        public List<SOATConsultaDTO> SOATs { get; set; } = new List<SOATConsultaDTO>();
        public List<TecnoMecanicaConsultaDTO> TECNOMECANICAs { get; set; } = new List<TecnoMecanicaConsultaDTO>();
    }
}

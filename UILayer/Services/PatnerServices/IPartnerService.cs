using UILayer.Dtos.PartnerDtos;

namespace UILayer.Services.PatnerServices
{
	public interface IPartnerService
	{
		Task<List<ResultPartnerDto>> GetAllPartnerAsync();
		Task<string> CreatePartnerAsync(CreatePartnerDto createPartnerDto);
		Task<string> DeletePartnerAsync(int PartnerId);
		Task<UpdatePartnerDto> GetByIdAsync(int id);
		Task<bool> UpdatePartnerAsync(UpdatePartnerDto updatePartnerDto);
	}
}

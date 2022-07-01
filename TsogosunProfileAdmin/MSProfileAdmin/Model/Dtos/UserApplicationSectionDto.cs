
using System.Collections.Generic;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class UserApplicationSectionDto : UserRightsSectionDto
    {
        public UserDto UserDto { get; set; }
        public List<ApplicationDto> Applications { get; set; }
    }
}

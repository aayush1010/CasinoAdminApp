using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.DTOModel
{
    [ViewModelMapping("Casino.AdminPortal.Web.Models.UserModel", MappingType.TotalExplicit)]
    [EntityMapping("Casino.AdminPortal.EntityDataModel.EntityModel.Player", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase, IUserDTO
    {
        public UserDTO() : base(DTOType.UserDTO)
        {

        }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "PlayerId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "PlayerId")]
        public int PlayerId { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Name")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ContactNumber")]
        [EntityPropertyMapping(MappingDirectionType.Both, "ContactNumber")]
        public string ContactNumber { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "EmailId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "EmailId")]
        public string EmailId { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DateOfBirth")]
        [EntityPropertyMapping(MappingDirectionType.Both, "DateOfBirth")]
        public System.DateTime DateOfBirth { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        [EntityPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        public decimal AccountBalance { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IdentityProof")]
        [EntityPropertyMapping(MappingDirectionType.Both, "IdentityProof")]
        public byte[] IdentityProof { get; set; }
        [ViewModelPropertyMapping(MappingDirectionType.Both, "BlockedAmount")]
        [EntityPropertyMapping(MappingDirectionType.Both, "BlockedAmount")]
        public int BlockedAmount { get; set; }
    }
}

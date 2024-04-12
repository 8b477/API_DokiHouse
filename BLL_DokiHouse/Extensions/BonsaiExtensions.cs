using BLL_DokiHouse.Models.Bonsai.View;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Extensions
{
    static class BonsaiExtensions
    {
        public static BonsaiView BLLToView(this Bonsai model, int idBonsai, int idUser)
        {
            return new BonsaiView(idBonsai,model.Name,model.Description,model.CreateAt,model.ModifiedAt, idUser);
        }

    }
}

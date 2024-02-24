using BLL_DokiHouse.Models.User.View;
using Entities_DokiHouse.Entities;


namespace BLL_DokiHouse.Extensions
{
    static class UserExtensions
    {
        public static UserView BLLToView(this User model)
        {
            return new UserView(model.Id, model.Name, model.Role, model.CreateAt, model.ModifiedAt);
        }

        public static UserView BLLToView(this User model, int id)
        {
            return new UserView(id, model.Name, model.Role, model.CreateAt, model.ModifiedAt);
        }
    }
}

using RecordStore.Core.DTOs.Artist;
using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;
using RecordStore.Core.Entities.Identity;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.ViewModels.Record;
using RecordStore.Core.ViewModels.Role;
using RecordStore.Core.ViewModels.User;

namespace RecordStore.Core.Extensions
{
    public static class Mapper
    {
        public static GetArtistDTO AsDTO(this Artist artist)
        {
            return new GetArtistDTO { Id = artist.Id, Name = artist.Name, Description = artist.Description };
        }

        public static GetCategoryDTO AsDTO(this Category category)
        {
            return new GetCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Position = category.Position,
                ParentCategory = category.ParentCategory is not null ? new GetCategoryDTO
                {
                    Id = category.ParentCategory.Id,
                    Name = category.ParentCategory.Name,
                    Position = category.ParentCategory.Position,
                    ParentCategory = null
                } : null
            };
        }

        public static GetConditionDTO AsDTO(this Condition condition)
        {
            return new GetConditionDTO { Id = condition.Id, Name = condition.Name };
        }

        public static GetFormatDTO AsDTO(this Format format)
        {
            return new GetFormatDTO { Id = format.Id, Name = format.Name };
        }

        public static GetGenreDTO AsDTO(this Genre genre)
        {
            return new GetGenreDTO { Id = genre.Id, Name = genre.Name };
        }

        public static GetRecordViewModel AsViewModel(this Record record)
        {
            return new GetRecordViewModel
            {
                Id = record.Id,
                Title = record.Title,
                Year = record.Year,
                Price = record.Price,
                Description = record.Description,
                //Format= u.Format,
                //Release = u.Release,
                //RecordCondition = u.RecordCondition,
                //Genres = u.Genres,
                //Styles = u.Styles,
                //Categories = u.Categories
            };
        }

        public static GetReleaseDTO AsDTO(this Release release)
        {
            return new GetReleaseDTO { Id = release.Id, Name = release.Name };
        }

        public static GetStyleDTO AsDTO(this Style style)
        {
            return new GetStyleDTO { Id = style.Id, Name = style.Name };
        }

        public static GetUserViewModel AsViewModel(this ApplicationUser user)
        {
            return new GetUserViewModel { Id = user.Id, Email = user.Email, Username = user.UserName, IsLockedout = user.LockoutEnd is not null };
        }

        public static RoleViewModel AsViewModel(this Role role, bool isSelected = false)
        {
            return new RoleViewModel { Id = role.Id, Name = role.Name, IsSelected = isSelected };
        }

    }
}

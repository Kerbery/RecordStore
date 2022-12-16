using RecordStore.Core.DTOs.Artist;
using RecordStore.Core.DTOs.Category;
using RecordStore.Core.DTOs.Condition;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.DTOs.Genre;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.DTOs.Style;
using RecordStore.Core.Entities.Identity;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.ViewModels.Category;
using RecordStore.Core.ViewModels.Genre;
using RecordStore.Core.ViewModels.Record;
using RecordStore.Core.ViewModels.Role;
using RecordStore.Core.ViewModels.Style;
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
                ParentCategoryId = category.ParentCategoryId
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
                CreateDate = record.CreateDate,
                Title = record.Title,
                Year = record.Year,
                Price = record.Price,
                Description = record.Description,
                Format = record.Format.AsDTO(),
                Release = record.Release.AsDTO(),
                RecordCondition = record.RecordCondition.AsDTO(),
                Genres = record.Genres.Select(g => g.AsDTO()),
                Styles = record.Styles.Select(s => s.AsDTO()),
                Categories = record.Categories.Select(c => c.AsDTO()),
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

        public static GenreViewModel AsViewModel(this Genre genre, bool isSelected = false)
        {
            return new GenreViewModel { Id = genre.Id, Name = genre.Name, IsSelected = isSelected };
        }

        public static StyleViewModel AsViewModel(this Style style, bool isSelected = false)
        {
            return new StyleViewModel { Id = style.Id, Name = style.Name, IsSelected = isSelected };
        }

        public static CategoryViewModel AsViewModel(this Category category, bool isSelected = false)
        {
            return new CategoryViewModel { Id = category.Id, Name = category.Name, IsSelected = isSelected };
        }
    }
}

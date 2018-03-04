using System;
using System.Collections.Generic;
using System.Text;
using TDList.Data;
using TDList.Models;

namespace TDList.BL.Converters
{
    public class TagConverter : IModelEntityConverter<TagModel, Tag>
    {
        public Tag GetEntityByModel(TagModel model)
        {
            return new Tag
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public TagModel GetModelByEntity(Tag entity)
        {
            return new TagModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}

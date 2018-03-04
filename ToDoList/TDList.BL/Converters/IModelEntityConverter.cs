using System;
using System.Collections.Generic;
using System.Text;

namespace TDList.BL.Converters
{
   public interface  IModelEntityConverter<TM, TE>
    {
        TM GetModelByEntity(TE entity);
        TE GetEntityByModel(TM model);
    }
}

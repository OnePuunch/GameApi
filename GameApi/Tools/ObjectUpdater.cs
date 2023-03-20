using GameApi.Models;
using System.Collections.Generic;

namespace GameApi.Tools
{
    public static class ObjectUpdater
    {
        public static void UpdateObject<T>(T currentObject, T update) where T : class, new ()
        {
            var objType = currentObject.GetType();
            var currentObjectColumns = currentObject.GetType().GetProperties();
            var updateColumns = update.GetType().GetProperties();

            for (var col=0; col< currentObjectColumns.Length; col++)
            {
                if (!Comparer.IsEqualOrEmpty(updateColumns[col].GetValue(update), currentObjectColumns[col].GetValue(currentObject)))
                {
                    currentObjectColumns[col].SetValue(currentObject, updateColumns[col].GetValue(update), null);
                }
            }
        }
    }
}

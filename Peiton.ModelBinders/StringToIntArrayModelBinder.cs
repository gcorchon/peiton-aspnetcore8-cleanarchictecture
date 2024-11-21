

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Peiton.ModelBinders;

public class StringToIntArrayModelBinder : IModelBinder
{
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        throw new NotImplementedException();
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {

        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        var modelName = bindingContext.ModelName;

        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }
        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        var value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        var values = value.Split(',');
        var valuesAreNotPositiveIntegers = values.Any(value =>
        {
            return !int.TryParse(value, out var id) || id <= 0;
        });

        if (valuesAreNotPositiveIntegers)
        {
            bindingContext.ModelState.TryAddModelError(
                modelName, "Some value is not a positive integer");

            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(values.Select(v => Convert.ToInt32(v)).ToArray());
        return Task.CompletedTask;
    }
}

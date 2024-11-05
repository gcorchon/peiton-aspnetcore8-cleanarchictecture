
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Test;

[Injectable]
public class TestHandler(ITuteladoRepository tuteladoRepository, IWordService wordService, IRazorService razorService)
{
    public async Task<byte[]> HandleAsync()
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(1);
        return await wordService.RenderRazorAsync("App_Data\\test.docx", tutelado);
    }

    public async Task<string> HandleTemplateAsync()
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(1);

        var template = @"@using RazorLight;
@using System;
@inherits TemplatePage<Peiton.Core.Entities.Tutelado>

@Model.Nombre @Model.Apellidos

@foreach(var contacto in Model.Contactos){
    <text>@contacto.Nombre</text>
}
";
        return await razorService.RenderTemplateAsync(template, tutelado);


    }
}